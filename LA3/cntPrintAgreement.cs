using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using LA3.Model;
using LA3.Properties;
using LA3.Reports;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LA3
{
    public partial class CntPrintAgreement : UserControl
    {
        private readonly LA_Entities _db = new LA_Entities();

        public CntPrintAgreement()
        {
            InitializeComponent();
            PopulateFields();
        }

        private void PopulateFields()
        {
            lstAccounts.ValueMember = "Id";
            lstAccounts.DisplayMember = "AccountDetailLine";
            lstAccounts.DataSource = (from a in _db.Accounts where !a.PrintedForm select a).ToList();
        }

        private void cntPrintAgreement_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            foreach (Account acc in lstAccounts.SelectedItems)
            {
                var period = acc.PayMonthly ? "month" : "week";
                var numOfPayments = acc.PlannedNumberOfPayments * acc.PaymentPeriod;
                var durationText =
                    $"The agreement will have a minimum duration of {numOfPayments.ToString(CultureInfo.InvariantCulture)} {period}s";

                //Loans paid off
                double paidOffAmount = 0;
                var lpoText = "";
                var paymentsPaidByThisAccount = (from p in _db.Payments where p.PaidByAccountId == acc.Id select p).ToList();
                if (paymentsPaidByThisAccount.Count > 0)
                {
                    lpoText += "(";
                    foreach (var p in paymentsPaidByThisAccount)
                    {
                        paidOffAmount += p.Amount;
                        lpoText += p.Account.InvoiceCode + ", ";
                    }
                    lpoText = lpoText.Substring(0, lpoText.Length - 2) + ")";
                }

                var repayablePeriod = "The loan will be repayable in " + acc.PlannedNumberOfPayments.ToString(CultureInfo.InvariantCulture) + " installments and each subsequent " + period + "ly payment will be due on the same day each succeeding " + period;
                var repaymentText = "Your " + period + "ly repayment will be";

                //Generate PDF
                var headerFont = FontFactory.GetFont("Arial", 10);
                var normalFont = FontFactory.GetFont("Arial", 8);
                var smallFont = FontFactory.GetFont("Arial", 7);
                var document = new Document(PageSize.A4, 25, 25, 30, 30);
                var pdfPath = ReportHelper.CreateDoc(ref document);
                document.Open();

                //.HorizontalAlignment = ?; 0=Left, 1=Centre, 2=Right
                var tHeader = new PdfPTable(1);
                tHeader.AddCell(new PdfPCell( new Phrase("Pre Contract Fixed Sum Loan Agreement regulated by the Consumer Credit Act 1974", headerFont)){HorizontalAlignment = 1});
                document.Add(tHeader);

                var widths = new[] { 1f, 2f, 1f, 2f };
                var tAddresses = new PdfPTable(4);
                tAddresses.SetWidths(widths);
                var phLenders = new Phrase("R & M Donaldson" + Environment.NewLine + "P.O. Box 11, Heaton, NE7 7YW" + Environment.NewLine + "Telephone 0191 2811112", normalFont);
                var phBorrower = new Phrase(acc.Customer.FullName + Environment.NewLine +
                    acc.Customer.Address + Environment.NewLine +
                    "Tel. " + acc.Customer.PhoneNumber, normalFont);
                tAddresses.AddCell(new Phrase("The Lenders", normalFont));
                tAddresses.AddCell(phLenders);
                tAddresses.AddCell(new Phrase("The Borrowers", normalFont));
                tAddresses.AddCell(phBorrower);
                document.Add(tAddresses);

                widths = new[] { 1f, 1f, 2f };
                var tMain = new PdfPTable(3);
                tMain.SetWidths(widths);
                tMain.AddCell(new PdfPCell(new Phrase("Key Financial Information", headerFont)) { Colspan = 2 });
                tMain.AddCell(new Phrase("Terms and Conditions", headerFont));

                var tDetails = new PdfPTable(2);
                tDetails.AddCell(new Phrase("Amount of Loan", normalFont));
                tDetails.AddCell(new PdfPCell(new Phrase(acc.NetValue.ToString("C0"), normalFont)) { HorizontalAlignment = 2 });
                tDetails.AddCell(new Phrase("Duration", normalFont));
                tDetails.AddCell(new PdfPCell(new Phrase(durationText, normalFont)) { HorizontalAlignment = 2 });
                tDetails.AddCell(new Phrase("Total amount now payable (loan + interest)", normalFont));
                tDetails.AddCell(new PdfPCell(new Phrase(acc.GrossValue.ToString("C0"), normalFont)) { HorizontalAlignment = 2 });
                tDetails.AddCell(new Phrase("Repayments are to commence", normalFont));
                tDetails.AddCell(new PdfPCell(new Phrase(acc.FirstPayment.ToString("dd/MMM/yyyy"), normalFont)) { HorizontalAlignment = 2 });
                tDetails.AddCell(new PdfPCell(new Phrase(repayablePeriod, normalFont)) { Colspan = 2 });
                tDetails.AddCell(new Phrase(repaymentText, normalFont));
                tDetails.AddCell(new PdfPCell(new Phrase(acc.Payment.ToString("C0"), normalFont)) { HorizontalAlignment = 2 });
                tDetails.AddCell(new Phrase("Personal APR", normalFont));
                tDetails.AddCell(new PdfPCell(new Phrase(acc.PersonalApr.ToString("0.0") + "%", normalFont)) { HorizontalAlignment = 2 });
                tDetails.AddCell(new Phrase("Typical APR", normalFont));
                tDetails.AddCell(new PdfPCell(new Phrase(acc.TypicalApr.ToString("0.0") + "%", normalFont)) { HorizontalAlignment = 2 });
                tDetails.AddCell(new PdfPCell(new Phrase("Other Financial Infomation", normalFont)) { Colspan = 2 });
                tDetails.AddCell(new Phrase("Total amount interest charged on this loan", normalFont));
                tDetails.AddCell(new PdfPCell(new Phrase((acc.GrossValue - acc.NetValue).ToString("C0"), normalFont)) { HorizontalAlignment = 2 });
                tDetails.AddCell(new Phrase("Amount required to settle existing loan(s)", normalFont));
                tDetails.AddCell(new PdfPCell(new Phrase(paidOffAmount.ToString("C0"), normalFont)) { HorizontalAlignment = 2 });
                tDetails.AddCell(new PdfPCell(new Phrase(lpoText, normalFont)) { Colspan = 2 });
                tDetails.AddCell(new Phrase("Cash now required", normalFont));
                tDetails.AddCell(new PdfPCell(new Phrase((acc.NetValue - paidOffAmount).ToString("C0"), normalFont)) { HorizontalAlignment = 2 });

                tDetails.AddCell(new PdfPCell(new Phrase(Resources.Agreement_Comment01, smallFont)) { Colspan = 2 });
                tDetails.AddCell(new PdfPCell(new Phrase("Key Information", headerFont)) { Colspan = 2 });
                tDetails.AddCell(new PdfPCell(new Phrase(Resources.Agreement_Comment02, smallFont)) { Colspan = 2 });
                tMain.AddCell(new PdfPCell(tDetails) { Colspan = 2 });

                tMain.AddCell(new Paragraph(Resources.Agreement_Terms_and_Conditions, smallFont));
                document.Add(tMain);
                document.Close();

                ////todo: replace this with auto printing code
                //var copies = Settings.Default.AgreementsToPrint;
                //Process.Start(pdfPath);

                var onScreen = Settings.Default.AgreementsToScreen;
                if (onScreen)
                    Process.Start(pdfPath);
                else
                    Pdf.PrintPdf(pdfPath);
            }

            if (MessageBox.Show(@"Did the Agreements print correctly?", @"Confirm Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                foreach (Account acc in lstAccounts.SelectedItems)
                    acc.PrintedForm = true;
                _db.SaveChanges();
            }

            PopulateFields();
        }
    }
}
