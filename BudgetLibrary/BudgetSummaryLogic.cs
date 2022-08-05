using BudgetLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLibrary
{
    public static class BudgetSummaryLogic
    {
        public static List<List<string>> BuildSummaryTable(List<TransactionModel> budget)
        {
            int year = DateTime.Now.Year;
            List<List<string>> testList = new List<List<string>>();
            List<string> months = new List<string> { "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"};
            List<DateTime> monthIntervals = new List<DateTime>
            {
                new DateTime(year, 1, 1),
                new DateTime(year, 2, 1),
                new DateTime(year, 3, 1),
                new DateTime(year, 4, 1),
                new DateTime(year, 5, 1),
                new DateTime(year, 6, 1),
                new DateTime(year, 7, 1),
                new DateTime(year, 8, 1),
                new DateTime(year, 9, 1),
                new DateTime(year, 10, 1),
                new DateTime(year, 11, 1),
                new DateTime(year, 12, 1),
                new DateTime(year, 12, 31)
            };

            decimal credit = 0;
            decimal debit = 0;
            decimal margin = 0;
            decimal totalCredits = 0;
            decimal totalDebits = 0;

            foreach(string month in months)
            {
                if (month == "January")
                {
                    credit = 0;
                    debit = 0;
                    margin = 0;

                    foreach (TransactionModel transaction in budget)
                    {
                        decimal currentAmount = 0;

                        // Credits (credit/debit is equal to 1)
                        if (transaction.CreditOrDebit == 1 && (transaction.DateOfTransaction >= monthIntervals[0] && transaction.DateOfTransaction < monthIntervals[1]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            credit += currentAmount;
                        }

                        // Debits (credit/debit is equal to -11)
                        if (transaction.CreditOrDebit == -1 && (transaction.DateOfTransaction >= monthIntervals[0] && transaction.DateOfTransaction < monthIntervals[1]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            debit += currentAmount;
                        }
                    }

                    margin = credit + debit;

                    testList.Add(new List<string>
                    {
                        month,
                        Convert.ToDecimal(string.Format("{0:0.00}", credit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", debit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", margin)).ToString()
                    });

                    totalCredits += credit;
                    totalDebits += debit;
                }

                if (month == "February")
                {
                    credit = 0;
                    debit = 0;
                    margin = 0;

                    foreach (TransactionModel transaction in budget)
                    {
                        decimal currentAmount = 0;

                        // Credits (credit/debit is equal to 1)
                        if (transaction.CreditOrDebit == 1 && (transaction.DateOfTransaction >= monthIntervals[1] && transaction.DateOfTransaction < monthIntervals[2]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            credit += currentAmount;
                        }

                        // Debits (credit/debit is equal to -11)
                        if (transaction.CreditOrDebit == -1 && (transaction.DateOfTransaction >= monthIntervals[1] && transaction.DateOfTransaction < monthIntervals[2]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            debit += currentAmount;
                        }
                    }

                    margin = credit + debit;

                    testList.Add(new List<string>
                    {
                        month,
                        Convert.ToDecimal(string.Format("{0:0.00}", credit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", debit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", margin)).ToString()
                    });

                    totalCredits += credit;
                    totalDebits += debit;
                }

                if (month == "March")
                {
                    credit = 0;
                    debit = 0;
                    margin = 0;

                    foreach (TransactionModel transaction in budget)
                    {
                        decimal currentAmount = 0;

                        // Credits (credit/debit is equal to 1)
                        if (transaction.CreditOrDebit == 1 && (transaction.DateOfTransaction >= monthIntervals[2] && transaction.DateOfTransaction < monthIntervals[3]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            credit += currentAmount;
                        }

                        // Debits (credit/debit is equal to -11)
                        if (transaction.CreditOrDebit == -1 && (transaction.DateOfTransaction >= monthIntervals[2] && transaction.DateOfTransaction < monthIntervals[3]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            debit += currentAmount;
                        }
                    }

                    margin = credit + debit;

                    testList.Add(new List<string>
                    {
                        month,
                        Convert.ToDecimal(string.Format("{0:0.00}", credit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", debit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", margin)).ToString()
                    });

                    totalCredits += credit;
                    totalDebits += debit;
                }

                if (month == "April")
                {
                    credit = 0;
                    debit = 0;
                    margin = 0;

                    foreach (TransactionModel transaction in budget)
                    {
                        decimal currentAmount = 0;

                        // Credits (credit/debit is equal to 1)
                        if (transaction.CreditOrDebit == 1 && (transaction.DateOfTransaction >= monthIntervals[3] && transaction.DateOfTransaction < monthIntervals[4]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            credit += currentAmount;
                        }

                        // Debits (credit/debit is equal to -11)
                        if (transaction.CreditOrDebit == -1 && (transaction.DateOfTransaction >= monthIntervals[3] && transaction.DateOfTransaction < monthIntervals[4]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            debit += currentAmount;
                        }
                    }

                    margin = credit + debit;

                    testList.Add(new List<string>
                    {
                        month,
                        Convert.ToDecimal(string.Format("{0:0.00}", credit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", debit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", margin)).ToString()
                    });

                    totalCredits += credit;
                    totalDebits += debit;
                }

                if (month == "May")
                {
                    credit = 0;
                    debit = 0;
                    margin = 0;

                    foreach (TransactionModel transaction in budget)
                    {
                        decimal currentAmount = 0;

                        // Credits (credit/debit is equal to 1)
                        if (transaction.CreditOrDebit == 1 && (transaction.DateOfTransaction >= monthIntervals[4] && transaction.DateOfTransaction < monthIntervals[5]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            credit += currentAmount;
                        }

                        // Debits (credit/debit is equal to -11)
                        if (transaction.CreditOrDebit == -1 && (transaction.DateOfTransaction >= monthIntervals[4] && transaction.DateOfTransaction < monthIntervals[5]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            debit += currentAmount;
                        }
                    }

                    margin = credit + debit;

                    testList.Add(new List<string>
                    {
                        month,
                        Convert.ToDecimal(string.Format("{0:0.00}", credit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", debit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", margin)).ToString()
                    });

                    totalCredits += credit;
                    totalDebits += debit;
                }

                if (month == "June")
                {
                    credit = 0;
                    debit = 0;
                    margin = 0;

                    foreach (TransactionModel transaction in budget)
                    {
                        decimal currentAmount = 0;

                        // Credits (credit/debit is equal to 1)
                        if (transaction.CreditOrDebit == 1 && (transaction.DateOfTransaction >= monthIntervals[5] && transaction.DateOfTransaction < monthIntervals[6]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            credit += currentAmount;
                        }

                        // Debits (credit/debit is equal to -11)
                        if (transaction.CreditOrDebit == -1 && (transaction.DateOfTransaction >= monthIntervals[5] && transaction.DateOfTransaction < monthIntervals[6]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            debit += currentAmount;
                        }
                    }

                    margin = credit + debit;

                    testList.Add(new List<string>
                    {
                        month,
                        Convert.ToDecimal(string.Format("{0:0.00}", credit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", debit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", margin)).ToString()
                    });

                    totalCredits += credit;
                    totalDebits += debit;
                }

                if (month == "July")
                {
                    credit = 0;
                    debit = 0;
                    margin = 0;

                    foreach (TransactionModel transaction in budget)
                    {
                        decimal currentAmount = 0;

                        // Credits (credit/debit is equal to 1)
                        if (transaction.CreditOrDebit == 1 && (transaction.DateOfTransaction >= monthIntervals[6] && transaction.DateOfTransaction < monthIntervals[7]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            credit += currentAmount;
                        }

                        // Debits (credit/debit is equal to -11)
                        if (transaction.CreditOrDebit == -1 && (transaction.DateOfTransaction >= monthIntervals[6] && transaction.DateOfTransaction < monthIntervals[7]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            debit += currentAmount;
                        }
                    }

                    margin = credit + debit;

                    testList.Add(new List<string>
                    {
                        month,
                        Convert.ToDecimal(string.Format("{0:0.00}", credit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", debit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", margin)).ToString()
                    });

                    totalCredits += credit;
                    totalDebits += debit;
                }

                if (month == "August")
                {
                    credit = 0;
                    debit = 0;
                    margin = 0;

                    foreach (TransactionModel transaction in budget)
                    {
                        decimal currentAmount = 0;

                        // Credits (credit/debit is equal to 1)
                        if (transaction.CreditOrDebit == 1 && (transaction.DateOfTransaction >= monthIntervals[7] && transaction.DateOfTransaction < monthIntervals[8]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            credit += currentAmount;
                        }

                        // Debits (credit/debit is equal to -11)
                        if (transaction.CreditOrDebit == -1 && (transaction.DateOfTransaction >= monthIntervals[7] && transaction.DateOfTransaction < monthIntervals[8]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            debit += currentAmount;
                        }
                    }

                    margin = credit + debit;

                    testList.Add(new List<string>
                    {
                        month,
                        Convert.ToDecimal(string.Format("{0:0.00}", credit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", debit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", margin)).ToString()
                    });

                    totalCredits += credit;
                    totalDebits += debit;
                }

                if (month == "September")
                {
                    credit = 0;
                    debit = 0;
                    margin = 0;

                    foreach (TransactionModel transaction in budget)
                    {
                        decimal currentAmount = 0;

                        // Credits (credit/debit is equal to 1)
                        if (transaction.CreditOrDebit == 1 && (transaction.DateOfTransaction >= monthIntervals[8] && transaction.DateOfTransaction < monthIntervals[9]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            credit += currentAmount;
                        }

                        // Debits (credit/debit is equal to -11)
                        if (transaction.CreditOrDebit == -1 && (transaction.DateOfTransaction >= monthIntervals[8] && transaction.DateOfTransaction < monthIntervals[9]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            debit += currentAmount;
                        }
                    }

                    margin = credit + debit;

                    testList.Add(new List<string>
                    {
                        month,
                        Convert.ToDecimal(string.Format("{0:0.00}", credit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", debit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", margin)).ToString()
                    });

                    totalCredits += credit;
                    totalDebits += debit;
                }

                if (month == "October")
                {
                    credit = 0;
                    debit = 0;
                    margin = 0;

                    foreach (TransactionModel transaction in budget)
                    {
                        decimal currentAmount = 0;

                        // Credits (credit/debit is equal to 1)
                        if (transaction.CreditOrDebit == 1 && (transaction.DateOfTransaction >= monthIntervals[9] && transaction.DateOfTransaction < monthIntervals[10]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            credit += currentAmount;
                        }

                        // Debits (credit/debit is equal to -11)
                        if (transaction.CreditOrDebit == -1 && (transaction.DateOfTransaction >= monthIntervals[9] && transaction.DateOfTransaction < monthIntervals[10]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            debit += currentAmount;
                        }
                    }

                    margin = credit + debit;

                    testList.Add(new List<string>
                    {
                        month,
                        Convert.ToDecimal(string.Format("{0:0.00}", credit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", debit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", margin)).ToString()
                    });

                    totalCredits += credit;
                    totalDebits += debit;
                }

                if (month == "November")
                {
                    credit = 0;
                    debit = 0;
                    margin = 0;

                    foreach (TransactionModel transaction in budget)
                    {
                        decimal currentAmount = 0;

                        // Credits (credit/debit is equal to 1)
                        if (transaction.CreditOrDebit == 1 && (transaction.DateOfTransaction >= monthIntervals[10] && transaction.DateOfTransaction < monthIntervals[11]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            credit += currentAmount;
                        }

                        // Debits (credit/debit is equal to -11)
                        if (transaction.CreditOrDebit == -1 && (transaction.DateOfTransaction >= monthIntervals[10] && transaction.DateOfTransaction < monthIntervals[11]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            debit += currentAmount;
                        }
                    }

                    margin = credit + debit;

                    testList.Add(new List<string>
                    {
                        month,
                        Convert.ToDecimal(string.Format("{0:0.00}", credit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", debit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", margin)).ToString()
                    });

                    totalCredits += credit;
                    totalDebits += debit;
                }

                if (month == "December")
                {
                    credit = 0;
                    debit = 0;
                    margin = 0;

                    foreach (TransactionModel transaction in budget)
                    {
                        decimal currentAmount = 0;

                        // Credits (credit/debit is equal to 1)
                        if (transaction.CreditOrDebit == 1 && (transaction.DateOfTransaction >= monthIntervals[11] && transaction.DateOfTransaction < monthIntervals[12]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            credit += currentAmount;
                        }

                        // Debits (credit/debit is equal to -11)
                        if (transaction.CreditOrDebit == -1 && (transaction.DateOfTransaction >= monthIntervals[11] && transaction.DateOfTransaction < monthIntervals[12]))
                        {
                            currentAmount = transaction.AmountOfTransaction * transaction.CreditOrDebit;
                            debit += currentAmount;
                        }
                    }

                    margin = credit + debit;

                    testList.Add(new List<string>
                    {
                        month,
                        Convert.ToDecimal(string.Format("{0:0.00}", credit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", debit)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", margin)).ToString()
                    });

                    totalCredits += credit;
                    totalDebits += debit;
                }
            }

            decimal totalMargin = totalCredits + totalDebits;

            testList.Add(new List<string>
                    {
                        "Totals",
                        Convert.ToDecimal(string.Format("{0:0.00}", totalCredits)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", totalDebits)).ToString(),
                        Convert.ToDecimal(string.Format("{0:0.00}", totalMargin)).ToString()
                    });

            return testList;
        }
    }
}