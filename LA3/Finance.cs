using System;
using System.Collections.Generic;
using System.Linq;

namespace LA3
{
    internal static class Finance
    {
        public enum InstalmentFrequency
        {
            Daily = 0,
            Weekly = 1,
            Fortnightly = 2,
            FourWeekly = 3,
            Monthly = 4,
            Quarterly = 5,
            Annually = 6
        }

        public enum InstalmentType
        {
            Payment = 0,
            Advance = 1
        }
        
        internal class Instalment
        {
            public double Amount { get; set; }
            public double DaysAfterFirstAdvance { private get; set; }

            internal double Calculate(double apr)
            {
                double divisor = Math.Pow(1 + apr, DaysToYears);
                var sum = Amount / divisor;
                return sum;
            }

            private double DaysToYears
            {
                get
                {
                    return DaysAfterFirstAdvance / 365.25d;
                }
            }
        }
        public class AprCalculator
        {
            public AprCalculator(double firstAdvance)
                : this(firstAdvance, new List<Instalment>(), new List<Instalment>())
            {
            }

            private AprCalculator(double firstAdvance, List<Instalment> advances, List<Instalment> payments)
            {
                _advances = advances;
                _payments = payments;
                _advances.Add(new Instalment { Amount = firstAdvance, DaysAfterFirstAdvance = 0 });
            }

            public double SinglePaymentCalculation(double payment, int daysAfterAdvance)
            {
                return Math.Round((Math.Pow(_advances[0].Amount / payment, (-365.25 / daysAfterAdvance)) - 1) * 100, 1, MidpointRounding.AwayFromZero);
            }

            public double Calculate(double guess = 0)
            {
                double rateToTry = guess / 100;
                double difference = 1;
                double amountToAdd = 0.0001d;

                while (difference != 0)
                {
                    double advances = _advances.Sum(a => a.Calculate(rateToTry));
                    double payments = _payments.Sum(p => p.Calculate(rateToTry));

                    difference = payments - advances;

                    if (difference <= 0.0000001 && difference >= -0.0000001)
                    {
                        break;
                    }

                    if (difference > 0)
                    {
                        amountToAdd = amountToAdd * 2;
                        rateToTry = rateToTry + amountToAdd;
                    }

                    else
                    {
                        amountToAdd = amountToAdd / 2;
                        rateToTry = rateToTry - amountToAdd;
                    }
                }

                return Math.Round(rateToTry * 100, 1, MidpointRounding.AwayFromZero);
            }

            public void AddInstalment(double amount, double daysAfterFirstAdvance, InstalmentType instalmentType = InstalmentType.Payment)
            {
                var instalment = new Instalment { Amount = amount, DaysAfterFirstAdvance = daysAfterFirstAdvance };
                switch (instalmentType)
                {
                    case InstalmentType.Payment:
                        _payments.Add(instalment);
                        break;
                    case InstalmentType.Advance:
                        _advances.Add(instalment);
                        break;
                }
            }

            private static double GetDaysBewteenInstalments(InstalmentFrequency instalmentFrequency)
            {
                switch (instalmentFrequency)
                {
                    case InstalmentFrequency.Daily:
                        return 1;
                    case InstalmentFrequency.Weekly:
                        return 7;
                    case InstalmentFrequency.Fortnightly:
                        return 14;
                    case InstalmentFrequency.FourWeekly:
                        return 28;
                    case InstalmentFrequency.Monthly:
                        return 365.25 / 12;
                    case InstalmentFrequency.Quarterly:
                        return 365.25 / 4;
                    case InstalmentFrequency.Annually:
                        return 365.25;
                }
                return 1;
            }

            public void AddRegularInstalments(double amount, int numberOfInstalments, InstalmentFrequency instalmentFrequency, double daysAfterFirstAdvancefirstInstalment = 0)
            {
                double daysBetweenInstalments = GetDaysBewteenInstalments(instalmentFrequency);
                if (daysAfterFirstAdvancefirstInstalment == 0)
                {
                    daysAfterFirstAdvancefirstInstalment = daysBetweenInstalments;
                }
                for (int i = 0; i < numberOfInstalments; i++)
                {
                    _payments.Add(new Instalment { Amount = amount, DaysAfterFirstAdvance = daysAfterFirstAdvancefirstInstalment + (daysBetweenInstalments * i) });
                }
            }

            private readonly List<Instalment> _advances;
            private readonly List<Instalment> _payments;
        }
    }
}
