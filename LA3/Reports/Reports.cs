using System;
using System.Globalization;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

using LA3.Model;

namespace LA3.Reports
{
    public class Reports
    {
        readonly LA_Entities _db = new LA_Entities();

        public string MonthAudit(DateTime selectedMonth)
        {
            var document = new Document();

            var pdfPath = ReportHelper.CreateDoc(ref document);
            document.Open();

            //Define Fonts
            var fontReportHeader = FontFactory.GetFont(FontFactory.HELVETICA, 18, Font.BOLD);
            var fontColumnHeader = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD);
            var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 6, Font.NORMAL);

            //Adds content to the document:
            ReportHelper.AddLine(document, fontReportHeader, "Business By Month - " + selectedMonth.ToString("MM yyyy"));

            //Define Table
            var tbl = new PdfPTable(5);

            //Table Headers
            ReportHelper.AddCell(tbl, "Account Status Changes", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 5, 10);
            ReportHelper.AddCell(tbl, "Customer", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Account", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Net Value", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Status", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Date", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);

            //Get Accounts that have changed status within month
            foreach (var account in _db.Accounts)
            {
                var latestStatusChange = account.LatestStatusChange;
                if (latestStatusChange.Timestamp.Month != selectedMonth.Month || latestStatusChange.Timestamp.Year != selectedMonth.Year) continue;

                ReportHelper.AddCell(tbl, account.Customer.FullName, 1, Element.ALIGN_LEFT, fontNormal, Rectangle.BOTTOM_BORDER, 1, 10);
                ReportHelper.AddCell(tbl, account.InvoiceCode, 1, Element.ALIGN_LEFT, fontNormal, Rectangle.BOTTOM_BORDER, 1, 10);
                ReportHelper.AddCell(tbl, account.NetValue.ToString("C2"), 1, Element.ALIGN_LEFT, fontNormal, Rectangle.BOTTOM_BORDER, 1, 10);
                ReportHelper.AddCell(tbl, account.CurrentStatus.Status, 1, Element.ALIGN_LEFT, fontNormal, Rectangle.BOTTOM_BORDER, 1, 10);
                ReportHelper.AddCell(tbl, account.LatestStatusChange.Timestamp.ToString("dd/MMM/yyyy"), 1, Element.ALIGN_LEFT, fontNormal, Rectangle.BOTTOM_BORDER, 1, 10);
            }
            document.Add(tbl);

            //Payments made this month
            tbl = new PdfPTable(5);

            //Table Headers
            ReportHelper.AddCell(tbl, "Payments", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 5, 10);
            ReportHelper.AddCell(tbl, "Customer", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Account", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Date", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Amount", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Sundry", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);

            //Get Accounts that have changed status within month
            var payments =
                (from p in _db.Payments
                 where p.Timestamp.Month == selectedMonth.Month && p.Timestamp.Year == selectedMonth.Year
                 select p).ToList();
            var orderedPayments = (from p in payments orderby p.Account.Customer.Surname, p.Account.Customer_Id, p.Account.InvoiceCode, p.Timestamp ascending select p).ToList();
            foreach (var payment in orderedPayments)
            {
                ReportHelper.AddCell(tbl, payment.Account.Customer.FullName, 1, Element.ALIGN_LEFT, fontNormal, Rectangle.BOTTOM_BORDER, 1, 10);
                ReportHelper.AddCell(tbl, payment.Account.InvoiceCode, 1, Element.ALIGN_LEFT, fontNormal, Rectangle.BOTTOM_BORDER, 1, 10);
                ReportHelper.AddCell(tbl, payment.Timestamp.ToString("dd/MMM/yyyy"), 1, Element.ALIGN_LEFT, fontNormal, Rectangle.BOTTOM_BORDER, 1, 10);
                ReportHelper.AddCell(tbl, payment.Amount.ToString("C2"), 1, Element.ALIGN_LEFT, fontNormal, Rectangle.BOTTOM_BORDER, 1, 10);
                ReportHelper.AddCell(tbl, payment.IsSundry ? "Yes" : "No", 1, Element.ALIGN_LEFT, fontNormal, Rectangle.BOTTOM_BORDER, 1, 10);
            }
            document.Add(tbl);
            document.Close();
            return pdfPath;
        }

        //private static void showAccountEvent(Account a, int maxPayments, Font fontColumnHeader,
        //    Table tbl, List<Account> accountEvents, Payment p, string textLabel)
        //{
        //    foreach (Account acc in accountEvents)
        //    {
        //        if (acc.AccountID == p.AccountID)
        //        {
        //            ReportHelper.addCell(tbl, textLabel + ": " + a.InvoiceCode, 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.NO_BORDER, 10);
        //            for (int i = 0; i < (maxPayments + 3); i++)
        //                ReportHelper.addCell(tbl, "", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.NO_BORDER, 10);
        //            acc.AccountID = 0;
        //        }
        //    }
        //}

        //private static void checkAccountList(int maxPayments, Font fontColumnHeader, Font fontNormal,
        //    Table tbl, List<Account> accountList, string textLabel)
        //{
        //    foreach (Account acc in accountList)
        //    {
        //        if (acc.AccountID > 0)
        //        {
        //            ReportHelper.addCell(tbl, textLabel + ": " + acc.InvoiceCode, 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.NO_BORDER, 10);
        //            for (int i = 0; i < (maxPayments + 3); i++)
        //                ReportHelper.addCell(tbl, "", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.NO_BORDER, 10);
        //            acc.AccountID = 0;

        //            ReportHelper.addCell(tbl, acc.Customer.FullName, 1, Element.ALIGN_CENTER, fontNormal, Rectangle.NO_BORDER, 10);
        //            ReportHelper.addCell(tbl, acc.Customer.AddressFirstLine, 1, Element.ALIGN_CENTER, fontNormal, Rectangle.NO_BORDER, 10);
        //            ReportHelper.addCell(tbl, acc.InvoiceCode, 1, Element.ALIGN_CENTER, fontNormal, Rectangle.NO_BORDER, 10);
        //            ReportHelper.addCell(tbl, acc.NetValue.ToString("C2"), 1, Element.ALIGN_CENTER, fontNormal, Rectangle.NO_BORDER, 10);

        //            for (int i = 0; i < maxPayments; i++)
        //                ReportHelper.addCell(tbl, "-", 1, Element.ALIGN_CENTER, fontNormal, Rectangle.NO_BORDER, 10);
        //        }
        //    }
        //}
        public string ByDebt(int debt)
        {
            var document = new Document();
            var pdfPath = ReportHelper.CreateDoc(ref document);
            document.Open();

            //Define Fonts
            var fontReportHeader = FontFactory.GetFont(FontFactory.HELVETICA, 18, Font.BOLD);
            var fontColumnHeader = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD);
            var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 6, Font.NORMAL);
            var fontTotal = FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD);

            //Adds content to the document:
            ReportHelper.AddLine(document, fontReportHeader, "By Debt - " + debt.ToString("£0.00"));

            //Define Table
            var tbl = new PdfPTable(5);
            //tbl.BorderWidth = 0;
            //tbl.Cellpadding = 2;
            //tbl.Border = Rectangle.NO_BORDER;
            //tbl.AutoFillEmptyCells = true;

            //Table Headers
            ReportHelper.AddCell(tbl, "Customer", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Account", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Net Value", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Overdue", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Outstanding", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);

            //Get Data
            var db = new LA_Entities();
            var customerIds = db.Report_ByDebt(debt);
            foreach (var customerId in customerIds)
            {
                if (customerId == null) continue;
                var customer = db.Customers.Find(customerId);
                if (customer == null) continue;

                ReportHelper.AddCell(tbl, customer.FullName, 1, Element.ALIGN_LEFT, fontNormal, Rectangle.BOTTOM_BORDER, 2, 10);
                ReportHelper.AddCell(tbl, customer.AddressFirstLine, 1, Element.ALIGN_LEFT, fontNormal, Rectangle.BOTTOM_BORDER, 3, 10);

                //Account Info
                double totalOutstanding = 0;
                foreach (Account account in customer.Accounts)
                {
                    if (!account.CurrentStatus.IsCreated) continue;

                    ReportHelper.AddCell(tbl, "", 1, Element.ALIGN_CENTER, fontNormal, Rectangle.RIGHT_BORDER, 10);
                    ReportHelper.AddCell(tbl, account.InvoiceCode, 1, Element.ALIGN_LEFT, fontNormal, Rectangle.RIGHT_BORDER, 10);
                    ReportHelper.AddCell(tbl, account.NetValue.ToString("£0.00"), 1, Element.ALIGN_RIGHT, fontNormal, Rectangle.RIGHT_BORDER, 10);
                    ReportHelper.AddCell(tbl, account.Overdue.ToString("£0.00"), 1, Element.ALIGN_RIGHT, fontNormal, Rectangle.RIGHT_BORDER, 10);
                    ReportHelper.AddCell(tbl, account.Outstanding.ToString("£0.00"), 1, Element.ALIGN_RIGHT, fontNormal, Rectangle.NO_BORDER, 10);
                    totalOutstanding += account.Outstanding;
                }
                ReportHelper.AddCell(tbl, "Total:", 1, Element.ALIGN_RIGHT, fontTotal, Rectangle.NO_BORDER, 4, 10);
                ReportHelper.AddCell(tbl, totalOutstanding.ToString("£0.00"), 1, Element.ALIGN_RIGHT, fontTotal, Rectangle.BOTTOM_BORDER, 10);
            }

            document.Add(tbl);
            document.Close();

            return pdfPath;
        }
        public string NotPaid(int weeks)
        {
            var document = new Document();
            var pdfPath = ReportHelper.CreateDoc(ref document);
            document.Open();

            //Define Fonts
            var fontReportHeader = FontFactory.GetFont(FontFactory.HELVETICA, 18, Font.BOLD);
            var fontColumnHeader = FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD);
            var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 6, Font.NORMAL);

            //Adds content to the document:
            ReportHelper.AddLine(document, fontReportHeader, "Not Paid - " + weeks.ToString(CultureInfo.InvariantCulture) + " Weeks");

            //Define Table
            var tbl = new PdfPTable(6);
            //tbl.BorderWidth = 0;
            //tbl.Cellpadding = 2;
            //tbl.Border = Rectangle.NO_BORDER;
            //tbl.AutoFillEmptyCells = true;

            //Column Widths
            //tbl.Widths = headerwidths;

            //Table Headers
            ReportHelper.AddCell(tbl, "Account Code", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Loan Value", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Outstanding", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Customer", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Last Payment Paid", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Next Payment Due", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);

            //Data
            var results = _db.Report_NotPaid(weeks).ToList();
            //List<Account> badAccounts = (from a in db.Accounts where a.NextPaymentDate < cutoff orderby a.NextPaymentDate ascending select a).ToList();
            foreach (var result in results)
            {
                if (result == null) continue;
                if (result.LastPayment == null) continue;
                if (result.NextPaymentWasDue == null) continue;

                var account = (from a in _db.Accounts where a.Id == result.Account_Id select a).FirstOrDefault();
                if (account == null) throw new Exception("Can't find Account");
                if (account.CurrentStatus.Status != "Created") continue;

                //DateTime dt = DateTime.Parse(dr["LastPayment"].ToString());
                ReportHelper.AddCell(tbl, account.InvoiceCode, 1, Element.ALIGN_LEFT, fontNormal, Rectangle.RIGHT_BORDER, 10);
                ReportHelper.AddCell(tbl, account.NetValue.ToString("£0.00"), 1, Element.ALIGN_RIGHT, fontNormal, Rectangle.RIGHT_BORDER, 10);
                ReportHelper.AddCell(tbl, account.Outstanding.ToString("£0.00"), 1, Element.ALIGN_RIGHT, fontNormal, Rectangle.RIGHT_BORDER, 10);
                ReportHelper.AddCell(tbl, account.Customer.FullName, 1, Element.ALIGN_LEFT, fontNormal, Rectangle.RIGHT_BORDER, 10);
                ReportHelper.AddCell(tbl, ((DateTime)result.LastPayment).ToString("dd/MMM/yyyy"), 1, Element.ALIGN_CENTER, fontNormal, Rectangle.NO_BORDER, 10);
                ReportHelper.AddCell(tbl, ((DateTime)result.NextPaymentWasDue).ToString("dd/MMM/yyyy"), 1, Element.ALIGN_CENTER, fontNormal, Rectangle.NO_BORDER, 10);
            }

            document.Add(tbl);
            document.Close();

            return pdfPath;
        }
        public string PaymentsTaken(int collectorId, DateTime collectionDay, double collected)
        {
            var document = new Document();

            //Get Collector
            var collector = _db.Collectors.Find(collectorId);
            if (collector == null) throw new Exception("Cannot find Collector");

            var pdfPath = ReportHelper.CreateDoc(ref document);
            document.Open();

            //Define Fonts
            var fontReportHeader = FontFactory.GetFont(FontFactory.HELVETICA, 18, Font.BOLD);
            var fontColumnHeader = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD);
            var fontNormal = FontFactory.GetFont(FontFactory.COURIER, 8, Font.NORMAL);

            //Adds content to the document:
            ReportHelper.AddLine(document, fontReportHeader, "Payments Taken");
            ReportHelper.AddLine(document, fontReportHeader, collector.CollectorName + ": " + collectionDay.ToString("ddd, dd/MMM/yyyy"));

            //Define Table
            var tbl = new PdfPTable(5);
            //tbl.Border = Rectangle.NO_BORDER;
            //tbl.AutoFillEmptyCells = true;
            //tbl.Cellpadding = 1;

            //Set widths
            int[] widths = new int[5];
            widths[0] = 1;
            widths[1] = 3;
            widths[2] = 3;
            widths[3] = 1;
            widths[4] = 1;
            tbl.SetWidths(widths);

            //Table Headers
            ReportHelper.AddCell(tbl, "Account", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Customer", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Address", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Expected", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Actual", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);

            //Get Payments
            const int leading = 0;
            double total = 0;
            var accountsForCollection = collector.GetAccountsForCollection(collectionDay);
            foreach (var account in accountsForCollection)
            {
                //Invoice Code
                AddCell(fontNormal, tbl, leading, account.InvoiceCode);

                //Customer Name
                AddCell(fontNormal, tbl, leading, account.Customer.FullName);

                //Address
                AddCell(fontNormal, tbl, leading, account.Customer.AddressFirstLine);

                //Expected
                AddCell(fontNormal, tbl, leading, account.Payment.ToString("C2"));

                //todo: get only the latest payment
                //Actual

                var payment = (from p in account.Payments
                               where !p.IsSundry
                               && p.Timestamp.Year == collectionDay.Year
                               && p.Timestamp.Month == collectionDay.Month
                               && p.Timestamp.Day == collectionDay.Day
                               select p).FirstOrDefault();
                double paymentAmount = 0;
                if (payment != null)
                    paymentAmount = Convert.ToDouble(payment.Amount);
                AddCell(fontNormal, tbl, leading, paymentAmount.ToString("C2"));

                total += paymentAmount;
            }

            //Total
            AddCell(fontColumnHeader, tbl, leading, "");
            AddCell(fontColumnHeader, tbl, leading, "Total:");
            AddCell(fontColumnHeader, tbl, leading, total.ToString("C2"));
            AddCell(fontColumnHeader, tbl, leading, "");
            AddCell(fontColumnHeader, tbl, leading, "");

            //Collected
            AddCell(fontColumnHeader, tbl, leading, "");
            AddCell(fontColumnHeader, tbl, leading, "Collected:");
            AddCell(fontColumnHeader, tbl, leading, collected.ToString("C2"));
            AddCell(fontColumnHeader, tbl, leading, "");
            AddCell(fontColumnHeader, tbl, leading, "");

            //Final Summary
            AddCell(fontColumnHeader, tbl, leading, "");
            if (total == collected)
            {
                AddCell(fontColumnHeader, tbl, leading, "Exact Match");
                AddCell(fontColumnHeader, tbl, leading, "");
            }
            if (total > collected)
            {
                AddCell(fontColumnHeader, tbl, leading, "Shortfall:");
                AddCell(fontColumnHeader, tbl, leading, "(" + (total - collected).ToString("C2") + ")");
            }
            if (total < collected)
            {
                AddCell(fontColumnHeader, tbl, leading, "Surplus:");
                AddCell(fontColumnHeader, tbl, leading, (collected - total).ToString("C2"));
            }
            AddCell(fontColumnHeader, tbl, leading, "");
            AddCell(fontColumnHeader, tbl, leading, "");

            document.Add(tbl);
            document.Close();

            return pdfPath;
        }

        private static void AddCell(Font font, PdfPTable tbl, int leading, string value)
        {
            var phrase = new Phrase { Leading = leading };
            var chunk = new Chunk(value, font);
            phrase.Add(chunk);
            var cell = new PdfPCell(phrase) { HorizontalAlignment = Element.ALIGN_LEFT, Border = Rectangle.NO_BORDER };
            tbl.AddCell(cell);
        }

        public string OwingByCollector()
        {
            var document = new Document();
            var pdfPath = ReportHelper.CreateDoc(ref document);

            //Define Fonts
            var fontReportHeader = FontFactory.GetFont(FontFactory.HELVETICA, 18, Font.BOLD);
            var fontColumnHeader = FontFactory.GetFont(FontFactory.HELVETICA, 14, Font.BOLD);
            var fontNormal = FontFactory.GetFont(FontFactory.COURIER, 12, Font.NORMAL);

            //Adds content to the document:
            ReportHelper.AddLine(document, fontReportHeader, "Owing By Collector");

            //Define Table
            var tbl = new PdfPTable(3);
            //tbl.BorderWidth = 0;
            //tbl.Border = Rectangle.NO_BORDER;
            //tbl.AutoFillEmptyCells = true;
            //tbl.Cellpadding = 1;

            //Table Headers
            ReportHelper.AddCell(tbl, "Collector", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Owing", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);
            ReportHelper.AddCell(tbl, "Customers", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 10);

            //Get Collectors
            var totalOwing = 0.0;
            var totalCustomers = 0;
            const int leading = 0;

            foreach (var c in _db.Collectors.ToList())
            {
                var owing = c.TotalAmountOwed;
                var customers = c.CustomersWithAccountsCount;

                var phrase = new Phrase { Leading = leading };
                var chunk = new Chunk(c.CollectorName, fontNormal);
                phrase.Add(chunk);
                var cell = new PdfPCell();
                cell.AddElement(chunk);
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = Rectangle.NO_BORDER;
                tbl.AddCell(cell);

                phrase = new Phrase { Leading = leading };
                chunk = new Chunk(ReportHelper.ShowCurrency(owing), fontNormal);
                phrase.Add(chunk);
                cell = new PdfPCell();
                cell.AddElement(chunk);
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.Border = Rectangle.NO_BORDER;
                tbl.AddCell(cell);

                phrase = new Phrase { Leading = leading };
                chunk = new Chunk(customers.ToString(CultureInfo.InvariantCulture), fontNormal);
                phrase.Add(chunk);
                cell = new PdfPCell();
                cell.AddElement(chunk);
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.Border = Rectangle.NO_BORDER;
                tbl.AddCell(cell);

                //ReportHelper.addCell(tbl, c.CollectorName, Element.ALIGN_LEFT, fontNormal, Rectangle.BOTTOM_BORDER);
                //ReportHelper.addCell(tbl, String.Format("{0:£0,0}", owing), Element.ALIGN_RIGHT, fontNormal, Rectangle.BOTTOM_BORDER);
                //ReportHelper.addCell(tbl, customers.ToString(), Element.ALIGN_RIGHT, fontNormal, Rectangle.BOTTOM_BORDER);
                totalOwing += owing;
                totalCustomers += customers;
            }

            //Totals
            ReportHelper.AddCell(tbl, "", 1, Element.ALIGN_LEFT, fontNormal, Rectangle.NO_BORDER, 10);
            ReportHelper.AddCell(tbl, ReportHelper.ShowCurrency(totalOwing), 1, Element.ALIGN_RIGHT, fontColumnHeader, Rectangle.NO_BORDER, 10);
            ReportHelper.AddCell(tbl, totalCustomers.ToString(CultureInfo.InvariantCulture), 1, Element.ALIGN_RIGHT, fontColumnHeader, Rectangle.NO_BORDER, 10);

            document.Add(tbl);
            document.Close();

            return pdfPath;
        }

        /*
                public string Agreement(int accountID)
                {
                    string pdfPath = "";

                    var document = new Document();
                    try
                    {
                        var nl = Environment.NewLine;
                        pdfPath = ReportHelper.CreateDoc(ref document, false);
                        document.Open();

                        //Define Fonts
                        var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL);
                        var fontNormalBold = FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD);
                        var fontSmall = FontFactory.GetFont(FontFactory.HELVETICA, 6, Font.NORMAL);

                        var account = _db.Accounts.Find(accountID);
                        if (account == null) throw new Exception("Can't find Account");

                        //Pages
                        for (var page = 1; page <= 2; page++)
                        {
                            ReportHelper.AddLine(document, fontNormal, "Pre Contract Fixed Sum Loan Agreement regulated by the Consumer Credit Act 1974");

                            //Define Table
                            var tblTop = new PdfPTable(4);
                            //tblTop.BorderWidth = 0;
                            //tblTop.Border = Rectangle.NO_BORDER;
                            //tblTop.AutoFillEmptyCells = true;
                            //tblTop.Cellpadding = 1;

                            float[] headerwidths = { 5, 10, 5, 10 };
                            tblTop.SetWidths(headerwidths);

                            const string c1 = "The Lenders";
                            var c2 = "R & M Donaldson" + Environment.NewLine + "P.O. Box 11, Heaton, NE7 7YW" + nl + "Telephone 0191 2811112";
                            var c3 = "The Borrower" + nl + "Address";
                            var c4 = account.Customer.FullName + nl + account.Customer.Address;

                            ReportHelper.AddCell(tblTop, c1, 1, Element.ALIGN_RIGHT, fontNormalBold, Rectangle.NO_BORDER, 8);
                            ReportHelper.AddCell(tblTop, c2, 1, Element.ALIGN_LEFT, fontNormal, Rectangle.NO_BORDER, 8);
                            ReportHelper.AddCell(tblTop, c3, 1, Element.ALIGN_RIGHT, fontNormalBold, Rectangle.NO_BORDER, 8);
                            ReportHelper.AddCell(tblTop, c4, 1, Element.ALIGN_LEFT, fontNormal, Rectangle.NO_BORDER, 8);

                            ReportHelper.AddCell(tblTop, "", 1, Element.ALIGN_RIGHT, fontNormal, Rectangle.NO_BORDER, 8);
                            ReportHelper.AddCell(tblTop, "", 1, Element.ALIGN_LEFT, fontNormal, Rectangle.NO_BORDER, 8);
                            ReportHelper.AddCell(tblTop, "Telephone", 1, Element.ALIGN_RIGHT, fontNormalBold, Rectangle.NO_BORDER, 8);
                            ReportHelper.AddCell(tblTop, account.Customer.PhoneNumber, 1, Element.ALIGN_LEFT, fontNormal, Rectangle.NO_BORDER, 8);

                            //Define Table
                            var tblBody = new PdfPTable(2);
                            //tblBody.BorderWidth = 0;
                            //tblBody.Border = Rectangle.NO_BORDER;
                            //tblBody.AutoFillEmptyCells = false;
                            //tblBody.Cellpadding = 1;

                            ReportHelper.AddCell(tblBody, "Key Financial Information", 1, Element.ALIGN_LEFT, fontNormalBold, Rectangle.RECTANGLE, 6);
                            ReportHelper.AddCell(tblBody, "Terms and Conditions", 1, Element.ALIGN_LEFT, fontNormalBold, Rectangle.RECTANGLE, 6);

                            //Define Table
                            var tblLeft = new PdfPTable(2);
                            //tblLeft.BorderWidth = 0;
                            //tblLeft.Border = Rectangle.NO_BORDER;
                            //tblLeft.AutoFillEmptyCells = true;
                            //tblLeft.Cellpadding = 0;
                            //tblLeft.Cellpadding = 0;

                            var period = "";
                            period = account.PayMonthly ? "month" : "week";
                            var numOfPayments = (account.PlannedNumberOfPayments * account.PaymentPeriod);

                            //Loans paid off
                            var lpoText = "Amount required to settle existing loan(s)";
                            double paidOffAmount = 0;
                            var paidOffLoans = account.GetPayOffPayments();
                            if (paidOffLoans.Count > 0)
                            {
                                lpoText += nl + "(";
                                foreach (var p in paidOffLoans)
                                {
                                    lpoText += p.Account.InvoiceCode + ", ";
                                    paidOffAmount += p.Amount;
                                }
                                lpoText = lpoText.Substring(0, lpoText.Length - 2);
                                lpoText += ")";
                            }

                            ReportHelper.AddCell(tblLeft, "Amount of Loan", 1, Element.ALIGN_LEFT, fontSmall, Rectangle.NO_BORDER, 6);
                            ReportHelper.AddCell(tblLeft, ReportHelper.ShowCurrency(account.NetValue), 1, Element.ALIGN_RIGHT, fontSmall, Rectangle.NO_BORDER, 6);

                            ReportHelper.AddCell(tblLeft, "The agreement will have a minimum duration of " + numOfPayments + " " + period + "s", 1, Element.ALIGN_LEFT, fontSmall, Rectangle.NO_BORDER, 2, 6);

                            ReportHelper.AddCell(tblLeft, "Total amount now payable (loan + interest)", 1, Element.ALIGN_LEFT, fontSmall, Rectangle.NO_BORDER, 6);
                            ReportHelper.AddCell(tblLeft, ReportHelper.ShowCurrency(account.GrossValue), 1, Element.ALIGN_RIGHT, fontSmall, Rectangle.NO_BORDER, 6);

                            ReportHelper.AddCell(tblLeft, "Repayments are to commence", 1, Element.ALIGN_LEFT, fontSmall, Rectangle.NO_BORDER, 6);
                            ReportHelper.AddCell(tblLeft, account.StartDate.ToString("dd/MMM/yyyy"), 1, Element.ALIGN_RIGHT, fontSmall, Rectangle.NO_BORDER, 6);

                            var paragraph = "The loan will be repayable in " + numOfPayments + " installments and each subsequent " + period + "ly payment will be due on the same day each succeeding " + period;
                            ReportHelper.AddCell(tblLeft, paragraph, 1, Element.ALIGN_LEFT, fontSmall, Rectangle.NO_BORDER, 2, 6);

                            ReportHelper.AddCell(tblLeft, "Your " + period + "ly repayment will be", 1, Element.ALIGN_LEFT, fontSmall, Rectangle.NO_BORDER, 6);
                            ReportHelper.AddCell(tblLeft, ReportHelper.ShowCurrency(account.Payment), 1, Element.ALIGN_RIGHT, fontSmall, Rectangle.NO_BORDER, 6);

                            ReportHelper.AddCell(tblLeft, "Rate of interest per annum is", 1, Element.ALIGN_LEFT, fontSmall, Rectangle.NO_BORDER, 6);
                            ReportHelper.AddCell(tblLeft, "XXX%", 1, Element.ALIGN_RIGHT, fontSmall, Rectangle.NO_BORDER, 6);

                            ReportHelper.AddCell(tblLeft, "The APR applicable to this agreement is", 1, Element.ALIGN_LEFT, fontSmall, Rectangle.NO_BORDER, 6);
                            ReportHelper.AddCell(tblLeft, account.TypicalApr.ToString("0.0") + "%", 1, Element.ALIGN_RIGHT, fontSmall, Rectangle.NO_BORDER, 6);

                            ReportHelper.AddCell(tblLeft, "Other Financial Infomation", 1, Element.ALIGN_LEFT, fontSmall, Rectangle.NO_BORDER, 2, 6);

                            ReportHelper.AddCell(tblLeft, "Total amount interest charged on this loan", 1, Element.ALIGN_LEFT, fontSmall, Rectangle.NO_BORDER, 6);
                            ReportHelper.AddCell(tblLeft, ReportHelper.ShowCurrency(account.Interest), 1, Element.ALIGN_RIGHT, fontSmall, Rectangle.NO_BORDER, 6);

                            ReportHelper.AddCell(tblLeft, lpoText, 1, Element.ALIGN_LEFT, fontSmall, Rectangle.NO_BORDER, 6);
                            ReportHelper.AddCell(tblLeft, ReportHelper.ShowCurrency(paidOffAmount), 1, Element.ALIGN_RIGHT, fontSmall, Rectangle.NO_BORDER, 6);

                            ReportHelper.AddCell(tblLeft, "Cash now required", 1, Element.ALIGN_LEFT, fontSmall, Rectangle.NO_BORDER, 6);
                            ReportHelper.AddCell(tblLeft, ReportHelper.ShowCurrency(account.NetValue - paidOffAmount), 1, Element.ALIGN_RIGHT, fontSmall, Rectangle.NO_BORDER, 6);

                            paragraph = "The total interest due under this agreement is calculated and added to the sum due at the commencement of this agreement";
                            ReportHelper.AddCell(tblLeft, paragraph, 1, Element.ALIGN_LEFT, fontSmall, Rectangle.NO_BORDER, 2, 6);

                            string text1 = "We have the right to charge interest at the annual percentage rate shown above, on the overdue amounts " +
                                "(including any balance which may become payable under clause 3) and which remains unpaid at the date for the last " +
                                "payment under this agreement.  The interest will be charged on a daily basis from the date the amount falls due " +
                                "until it is received and will run both before and after any Judgement.  We may also charge you for any legal costs " +
                                "and other expenses incurred by us in obtaining payment by you of any sum overdue.  We may also demand immediate " +
                                "repayment of the entire sum due to us in accordance with clause 3." + nl +
                                "You have the right to pay off the balance of this agreement before the date of which the final payment falls due.  " +
                                "Based on a £100 loan over one year at the same rate of interest as this account" + nl +
                                "If paid in full after three months an interest rate of £18.81 will be due." + nl +
                                "If paid in full after six months an interest rate of £8.19 will be due." + nl +
                                "If paid in full after nine months an interest rate of £1.62 will be due." + nl +
                                "These figures are for illustration only as they take no account of any variation that may be made to this agreement." + nl + nl +
                                "MISSING PAYMENTS" + nl +
                                "Missing payments could have severe consequences and make obtaining credit more difficult." + nl + nl +
                                "IMPORTANT-READ THIS CAREFULLY TO FIND OUT ABOUT YOUR RIGHTS" + nl +
                                "The Consumer Act 1974 lays down certain requirements for your protection, which should have been complied with when " +
                                "this agreement was made.  If they are not, the creditor cannot enforce this agreement without getting a court order." + nl +
                                "The Act also gives you a number of rights.  You can settle this agreement at anytime by giving notice in writing " +
                                "and paying off the amount you owe under te agreement which may be reduced by a rebate.  Examples indicating the " +
                                "amount you have to pay appear in this agreement." + nl + nl +
                                "If you would like to know more about your rights under the Act, contact either your local Trading Standards " +
                                "Department or your nearest Citizens Advice Bureau." + nl + nl +
                                "YOUR RIGHT TO CANCEL" + nl +
                                "Once you've signed this agreement, you will have a short time in which you can cancel it.  The Creditor will send " +
                                "you exact details of how and when you can do this.";
                            ReportHelper.AddCell(tblLeft, "Key Information", 1, Element.ALIGN_LEFT, fontNormalBold, Rectangle.RECTANGLE, 2, 6);
                            ReportHelper.AddCell(tblLeft, text1, 1, Element.ALIGN_JUSTIFIED, fontSmall, Rectangle.NO_BORDER, 2, 6);

                            //Define Table
                            var tblRight = new PdfPTable(1);
                            //tblLeft.BorderWidth = 0;
                            //tblLeft.Border = Rectangle.NO_BORDER;
                            //tblLeft.AutoFillEmptyCells = true;
                            //tblLeft.Cellpadding = 0;

                            var text2 = "1. PAYMENT" + nl +
                                "By signing this agreement you agree to repay the loan plus the interest by the payments set out, by their " +
                                "specified dates.  Payments must be made to us at the address shown, or to any person or address notified by us in " +
                                "writing.  Punctual payment is essential.  If you pay by post you do so at your own risk.  If you already have a loan " +
                                "account with us, the appropriate part of the new loan will be applied in paying off the existing loan, and only the " +
                                "remaining balance will be paid to you." + nl + nl +
                                "2. FAILURE TO PAY ON TIME" + nl +
                                "We have the right to charge interest at the annual percentage rate shown (less the part attributed to any " +
                                "documentation fee) on all overdue amounts including any balance which may become payable under clause 3 and which remains " +
                                "unpaid on the date for the last payment under this agreement.  This interest will be calculated on a daily basis from " +
                                "the date the amount falls due until it is received and will run both before and after any Judgement.  We may also " +
                                "charge you for any legal costs and other expenses incurred by us in obtaining payment by you of any sum overdue." + nl + nl +
                                "3. RIGHT TO DEMAND EARLIER REPAYMENT" + nl +
                                "IF:" + nl +
                                "(a) Any amount payable by you is overdue for more than fourteen days, or " + nl +
                                "(b) Any statement made by you in the course of obtaining this loan is found to be untrue, or " + nl +
                                "(c) You have an interim or bankruptcy order made against you or you petition for your own bankruptcy, or you are served " +
                                "with a creditors demand under the Insolvency Act 1986 or the Banckruptcy (Scotland) Act 1985. Or make a formal " +
                                "composition or scheme with your creditors or call a meeting with them.  We have the right to demand earlier payment " +
                                "of the balance of the loan and the interest by sending you a default notice under the COnsumer Credit Act.  If you " +
                                "fail to take the action required by this notice within the time specified, the whole of the balance remaining unpaid " +
                                "on the agreement shall become payable immediately.  You will become entitled to a rebate of part of the interest if you " +
                                "pay that balance before it would have become due had we not demanded earlier payment." + nl + nl +
                                "4. EARLIER REPAYMENT BY YOU" + nl +
                                "If you pay off the balance of this agreement before the date of which the final payment falls due you will usually " +
                                "be entitled to a rebate of part of the interest." + nl + nl +
                                "5. GENERAL PROVISIONS" + nl +
                                "(d) No XXXXXXX or indulgence, which we may extend to you, shall affect our strict rights under this agreement. " +
                                "(e) We may transfer our rights under this agreement.  (f) You must notify us in writing within seven days of any " +
                                "change of address.  (g) Where two or more of you are named as the borrower you jointly and XXXXXX accept the " +
                                "obligations under this Agreement.  That means that each of you could be held fully responsible under this agreement." + nl + nl +
                                "6. WHEN THIS AGREEMENT TAKES EFFECT" + nl +
                                "This Agreement will only take effect if and when it is signed by us or our authorised representative." + nl + nl +
                                "This is a credit agreement regulated by the Customer Credit Act 1974.  Sign only if you want to be bound legally by " +
                                "its terms." + nl + nl + nl + nl +
                                "Signature(s) of Borrower(s)" + nl + nl + nl + nl +
                                "Name(s) of Borrower(s).  Please Print" + nl + nl + nl + nl +
                                "Date of Signature(s)" + nl + nl;
                            if (page == 1)
                                text2 +=
                                    "YOUR RIGHT TO CANCEL" + nl +
                                    "Once you have signed you will have, for a short time, a right to cancel this Agreement. You can do this by sending " +
                                    "or taking a WRITTEN notice of cancellation to Kay Donaldson at R & M Donaldson P.O. Box 11 Heaton Newcastle Upon " +
                                    "Tyne NE7 7YW." + nl +
                                    "If you cancel this agreement you must repay all monies lent to you by the lender under this Agreement." + nl + nl +
                                    "IMPORTANT" + nl +
                                    "Terms and conditions governing this Agreement are printed above.  By signing this Agreement you confirm " +
                                    "that you have read, understood and agree to be bound by those terms and conditions.";
                            else
                                text2 +=
                                    nl + nl + nl + nl + nl +
                                    "Signature(s) of Lenders" + nl + nl + nl +
                                    "Date of Signature(s)" + nl + nl + nl;
                            text2 +=
                                "IMPORTANT" + nl +
                                "Terms and conditions governing this Agreement are printed above.  By signing this Agreement you confirm " +
                                "that you have read, understood and agree to be bound by those terms and conditions.";

                            ReportHelper.AddCell(tblRight, text2, 15, Element.ALIGN_JUSTIFIED, fontSmall, Rectangle.NO_BORDER, 6);

                            //tblBody.InsertTable(tblLeft);
                            //tblBody.InsertTable(tblRight);
                            tblBody.AddCell(tblLeft);
                            tblBody.AddCell(tblRight);

                            document.Add(tblTop);
                            document.Add(tblBody);

                            if (page < 2) document.NewPage();
                        }
                    }
                    catch (Exception ex)
                    {
                        pdfPath = "";
                    }
                    finally
                    {
                        document.Close();
                    }


                    return pdfPath;
                }
        */

        public static string Sundries(DateTime dateTime)
        {
            var document = new Document();
            var db = new LA_Entities();

            dateTime = dateTime.Date;
            var pdfPath = ReportHelper.CreateDoc(ref document);
            document.Open();

            //Define Fonts
            var fontReportHeader = FontFactory.GetFont(FontFactory.HELVETICA, 18, Font.BOLD);
            var fontColumnHeader = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD);
            var fontNormal = FontFactory.GetFont(FontFactory.COURIER, 8, Font.NORMAL);

            //Adds content to the document:
            ReportHelper.AddLine(document, fontReportHeader, "Sundries Since " + dateTime.ToString("dd MMM yyyy"));

            //Define Table
            var tbl = new PdfPTable(4) { TotalWidth = PageSize.A4.Width };
            //tbl.BorderWidth = 0;
            //tbl.Border = Rectangle.NO_BORDER;
            //tbl.AutoFillEmptyCells = true;
            //tbl.Cellpadding = 1;

            //Table Headers
            ReportHelper.AddCell(tbl, "Customer", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 5);
            ReportHelper.AddCell(tbl, "Account", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 5);
            ReportHelper.AddCell(tbl, "Date", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 5);
            ReportHelper.AddCell(tbl, "Payment", 1, Element.ALIGN_CENTER, fontColumnHeader, Rectangle.BOTTOM_BORDER, 5);

            //Get Payments
            const int leading = 0;
            var sundries = Payment.GetSundryPaymentsFromDate(dateTime);
            foreach (var p in sundries)
            {
                var account = db.Accounts.Find(p.Account_Id);
                if (account == null) throw new Exception("Cannot find account");

                var phrase = new Phrase { Leading = leading };
                var chunk = new Chunk(account.Customer.FullName, fontNormal);
                phrase.Add(chunk);
                var cell = new PdfPCell();
                cell.AddElement(chunk);
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                //cell.Border = Rectangle.NO_BORDER;
                tbl.AddCell(cell);

                phrase = new Phrase { Leading = leading };
                chunk = new Chunk(account.InvoiceCode, fontNormal);
                phrase.Add(chunk);
                cell = new PdfPCell();
                cell.AddElement(chunk);
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                //cell.Border = Rectangle.NO_BORDER;
                tbl.AddCell(cell);

                phrase = new Phrase { Leading = leading };
                chunk = new Chunk(p.Timestamp.ToString("dd MMM yyyy"), fontNormal);
                phrase.Add(chunk);
                cell = new PdfPCell();
                cell.AddElement(chunk);
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                //cell.Border = Rectangle.NO_BORDER;
                tbl.AddCell(cell);

                phrase = new Phrase { Leading = leading };
                chunk = new Chunk(p.Amount.ToString("£0.00"), fontNormal);
                phrase.Add(chunk);
                cell = new PdfPCell();
                cell.AddElement(chunk);
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                //cell.Border = Rectangle.NO_BORDER;
                tbl.AddCell(cell);

            }
            document.Add(tbl);
            document.Close();

            return pdfPath;
        }
    }
}
