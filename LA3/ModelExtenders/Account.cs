using System;
using System.Collections.Generic;
using System.Linq;

namespace LA3.Model
{
    partial class Account
    {
        public Payment LastPayment
        {
            get
            {
                if (Payments.Count == 0) return null;

                var lastPayment =
                    (from p in Payments orderby p.Timestamp descending select p).FirstOrDefault();

                return lastPayment;
            }
        }
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
                        throw new Exception($"Bad Period Frequency [{PaymentPeriod}]");
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
                return payment?.Timestamp ?? NextPaymentDate;
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
        //public string AccountDetailLine
        //{
        //    get
        //    {
        //        var rv = string.Format("{0}: {1}. {2}", NetValue.ToString("C0"), Customer.FullName, Customer.AddressFirstLine);
        //        return rv;
        //    }
        //}

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
                if (PaymentPeriod == 0) throw new Exception("Payment Period is zero!");

                //How much should have been paid?
                var plannedPayments = 0;
                var rollingDate = StartDate;
                while (rollingDate < DateTime.Today)
                {
                    if (rollingDate > StartDate) plannedPayments++;

                    rollingDate = PayMonthly ? rollingDate.AddMonths(PaymentPeriod) : rollingDate.AddDays(PaymentPeriod * 7);
                }

                //Amount that should have been paid
                var plannedAmountPaid = Payment * plannedPayments;

                //How much has been paid?
                var actualAmountPaid = Payments.Aggregate<Payment, double>(0, (current, p) => current + p.Amount);

                return plannedAmountPaid - actualAmountPaid;
            }
        }
        public double Outstanding => GrossValue - AmountPaid;

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
                //  Dim dCharge As Double
                //  Dim dSettlement As Double
                //  Dim TotalTheoreticalPayments As Integer

                //No Payments = No Rebate
                if (Payments.Count == 0) return 0;

                //Project finish date
                //var paymentPeriod = PayMonthly ? "m" : "ww";

                //How many payments should there be?
                //TotalTheoreticalPayments = CInt(Me.TotalAmount / Me.Payment)
                var totalPayments = (int)(GrossValue / Payment);

                //When should the loan be paid off?
                //  dFinish = DateAdd(PaymentPeriod, TotalTheoreticalPayments * Me.Period, Me.Payments(1).PaymentDate)
                DateTime finishDate;
                if (PayMonthly)
                    finishDate = FirstPayment.AddMonths(totalPayments);
                else
                    finishDate = FirstPayment.AddDays(totalPayments * 7);
                //DateTime x = PlannedFinishDate;

                //  'Number of payments left
                //  lPaymentsToGo = DateDiff(PaymentPeriod, Date, dFinish)
                //  lPaymentsToGo = lPaymentsToGo / Me.Period
                var paymentsRemainig = (int)(Outstanding / Payment);

                //  'Charge for loan
                //  dCharge = Me.TotalAmount - Me.RetailPrice

                //  'Final Rebate
                //  If Me.Monthly Then
                //    dSettlement = CInt(2 / Me.Period)
                //  Else
                //    dSettlement = CInt(8 / Me.Period)
                //  End If
                var settlement = 0;
                if (PayMonthly)
                    settlement = (int)(2 / PaymentPeriod);
                else
                    settlement = (int)(8 / PaymentPeriod);

                //  lPaymentsToGo = lPaymentsToGo - dSettlement
                paymentsRemainig = paymentsRemainig - settlement;
                if (paymentsRemainig <= 0) return 0;
                //  If lPaymentsToGo > 0 Then
                //    Rebate = ((lPaymentsToGo * (lPaymentsToGo + 1)) / (TotalTheoreticalPayments * (TotalTheoreticalPayments + 1))) * dCharge
                //  Else
                //    Rebate = 0
                //  End If
                var rv = ((paymentsRemainig*(paymentsRemainig + 1))/(totalPayments*(totalPayments + 1)))*Interest;
                if (rv <= 0) return 0;

                //  'Round
                //  If Rebate > 0 Then
                //    Rebate = Rebate * 100
                //    Rebate = CLng(Rebate)
                //    Rebate = Rebate / 100
                //  End If
                

                return (int)rv;
            }
        }

        private static DateTime PlannedFinishDate => DateTime.Today;

        //public List<Payment> GetPayOffPayments()
        //{
        //    var db = new LA_Entities();
        //    var payOffPayments = (from p in db.Payments where p.PaidByAccountId == Id select p).ToList();
        //    return payOffPayments;
        //}
    }
}
