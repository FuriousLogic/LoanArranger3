using System;
using System.Collections.Generic;
using System.Linq;

namespace LA3.Model
{
    partial class Account
    {
        public double TypicalApr
        {
            get
            {
                Finance.InstalmentFrequency instalmentFrequency;

                //Change to PayMonthly!!!!!!!!!!!

                switch (PaymentPeriod)
                {
                    case 0:
                        instalmentFrequency = Finance.InstalmentFrequency.Monthly;
                        break;
                    case 1:
                        instalmentFrequency = Finance.InstalmentFrequency.Weekly;
                        break;
                    default:
                        throw new Exception(string.Format("Bad Period Frequency [{0}]", PaymentPeriod));
                }

                var aprCalculator = new Finance.AprCalculator(NetValue);
                aprCalculator.AddRegularInstalments(Payment, PlannedNumberOfPayments, instalmentFrequency);

                var apr = aprCalculator.Calculate();

                return apr;
            }
        }
        public double PersonalApr
        {
            get
            {
                var ratio = Interest / NetValue;
                return ratio * 100.0;
            }
        }
        public DateTime FirstPayment
        {
            get
            {
                var payment = (from p in Payments orderby p.Timestamp descending select p).FirstOrDefault();
                if (payment == null)
                    return NextPaymentDate;
                return payment.Timestamp;
            }
        }
        public int PlannedNumberOfPayments
        {
            get
            {
                var rv = (int)(NetValue / Payment);
                if ((Payment * rv) < NetValue) rv++;
                return rv;
            }
        }
        public string AccountDetailLine
        {
            get
            {
                var rv = string.Format("{0}: {1}. {2}", NetValue.ToString("C0"), Customer.FullName, Customer.AddressFirstLine);
                return rv;
            }
        }

        public AccountStatusChange LatestStatusChange
        {
            get
            {
                return
                    (from astc in AccountStatusChanges orderby astc.Timestamp descending select astc).FirstOrDefault();
            }
        }
        public AccountStatus CurrentStatus
        {
            get
            {
                if (AccountStatusChanges.Count == 0) return null;

                return (from sc in AccountStatusChanges orderby sc.Timestamp descending select sc.AccountStatus).FirstOrDefault();
            }
        }
        public double Interest
        {
            get
            {
                return GrossValue - NetValue;
            }
        }
        public string InvoiceCode
        {
            get
            {
                return "L" + StartDate.ToString("yy") + "/" + InvoiceNumber.ToString("0000");
            }
        }
        public double Overdue
        {
            get
            {
                if (Id == 0) return 0;

                //todo: get universal error handling sorted
                if(PaymentPeriod==0)throw new Exception("Payment Period is zero!");

                //How much should have been paid?
                int plannedPayments = 0;
                DateTime rollingDate = StartDate;
                while (rollingDate < DateTime.Today)
                {
                    if (rollingDate > StartDate) plannedPayments++;

                    rollingDate = PayMonthly ? rollingDate.AddMonths(PaymentPeriod) : rollingDate.AddDays(PaymentPeriod * 7);
                }

                //Amount that should have been paid
                var plannedAmountPaid = Payment * plannedPayments;

                //How much has been paid?
                double actualAmountPaid = Payments.Aggregate<Payment, double>(0, (current, p) => current + p.Amount);

                return plannedAmountPaid - actualAmountPaid;
            }
        }
        public double Outstanding
        {
            get
            {
                return GrossValue - AmountPaid;
            }
        }

        private double AmountPaid
        {
            get
            {
                //How much has been paid?
                return Payments.Aggregate<Payment, double>(0, (current, p) => current + p.Amount);
            }
        }
        public double Rebate
        {
            get
            {
                //  Dim dFinish As Date
                //  Dim lPaymentsToGo As Long
                //  Dim PaymentPeriod As String
                //  Dim dCharge As Double
                //  Dim dSettlement As Double
                //  Dim TotalTheoreticalPayments As Integer

                //No Payments = No Rebate
                if (Payments.Count == 0) return 0;

                //  'Project finish date
                //  If Me.Monthly Then
                //    PaymentPeriod = "m"
                //  Else
                //    PaymentPeriod = "ww"
                //  End If

                //  'How many payments should there be?
                //  TotalTheoreticalPayments = CInt(Me.TotalAmount / Me.Payment)

                //  'When should the loan be paid off?
                //  dFinish = DateAdd(PaymentPeriod, TotalTheoreticalPayments * Me.Period, Me.Payments(1).PaymentDate)
                DateTime x = this.PlannedFinishDate;

                //  'Number of payments left
                //  lPaymentsToGo = DateDiff(PaymentPeriod, Date, dFinish)
                //  lPaymentsToGo = lPaymentsToGo / Me.Period

                //  'Charge for loan
                //  dCharge = Me.TotalAmount - Me.RetailPrice

                //  'Final Rebate
                //  If Me.Monthly Then
                //    dSettlement = CInt(2 / Me.Period)
                //  Else
                //    dSettlement = CInt(8 / Me.Period)
                //  End If

                //  lPaymentsToGo = lPaymentsToGo - dSettlement
                //  If lPaymentsToGo > 0 Then
                //    Rebate = ((lPaymentsToGo * (lPaymentsToGo + 1)) / (TotalTheoreticalPayments * (TotalTheoreticalPayments + 1))) * dCharge
                //  Else
                //    Rebate = 0
                //  End If

                //  'Round
                //  If Rebate > 0 Then
                //    Rebate = Rebate * 100
                //    Rebate = CLng(Rebate)
                //    Rebate = Rebate / 100
                //  End If

                return -1;
            }
        }

        public DateTime PlannedFinishDate
        {
            get
            {

                return DateTime.Today;
            }
        }

        public List<Payment> GetPayOffPayments()
        {
            var db = new LA_Entities();
            var payOffPayments = (from p in db.Payments where p.PaidByAccountId == Id select p).ToList();
            return payOffPayments;
        }
    }
}
