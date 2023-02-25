using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackfinch
{
    public class Platform
    {
        public static void Run()
        {
            bool endApp = false;
            Console.WriteLine("Lending Platform\r");
            //global variables used for tracking stats
            double loanTotal = 0;
            int succesfulApplications = 0;
            int unsuccesfulApplications = 0;
            int applications = 0;
            double averageLTV = 0;
            while (!endApp)
            {
                // Varables reset for each request
                double loanAmountInput = 0;
                double assetValue = 0;
                int creditScore = 0;

                //input request, loops till inputs are in correct format, improvment would be to allow individual to exit part way through a loan request
                while (loanAmountInput == 0)
                {
                    Console.WriteLine("Please input loan amount in £");
                    double.TryParse(Console.ReadLine(), out loanAmountInput);
                }

                while (assetValue == 0)
                {
                    Console.WriteLine("Please input the Asset value");
                    double.TryParse(Console.ReadLine(), out assetValue);
                }

                while (creditScore == 0)
                {
                    Console.WriteLine("Please input the credit score");
                    int.TryParse(Console.ReadLine(), out creditScore);
                }

                while (creditScore < 1 || creditScore > 999)
                {
                    Console.WriteLine("Credit score invalid, please input a vaild credit score");
                    int.TryParse(Console.ReadLine(), out creditScore);
                }

                applications++;

                // LTV calc
                var ltv = loanAmountInput / assetValue;

                // Check for application status
                var applicationStatus = CheckApplication(loanAmountInput, creditScore, ltv);

                // Assumes only loans that are accepted are added to the loan total
                if (applicationStatus)
                {
                    succesfulApplications++;
                    loanTotal += loanAmountInput;
                }
                else
                {
                    unsuccesfulApplications++;
                }

                // calculating average LTV of all loan requests
                averageLTV = (averageLTV * (applications - 1) + ltv) / applications;

                //output loan status
                if (applicationStatus)
                {
                    Console.WriteLine("Application Accepted");
                }
                else
                {
                    Console.WriteLine("Application Declined");
                }
                //output all loan stats so far
                Console.WriteLine("Applications: " + (applications).ToString());
                Console.WriteLine("Successful applications: " + succesfulApplications.ToString());
                Console.WriteLine("Unsuccessful applications: " + unsuccesfulApplications.ToString());
                Console.WriteLine("Value of loans written " + loanTotal.ToString());
                Console.WriteLine("Average LTV of all applications " + averageLTV.ToString());
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
        }

        public static bool CheckApplication(double loanAmountInput, int creditScore, double ltv)
        {
            //reject any loans below 100k and over 1.5m
            if (loanAmountInput > 1500000 || loanAmountInput < 100000)
            {
                return false;
            }
            else
            {
                //handling loans over 1m
                if (loanAmountInput >= 1000000)
                {
                    if (ltv >= 0.6 || creditScore < 950)
                    {
                        return false;
                    }
                }
                // Checking loans between 1m and 100k
                else
                {
                    if (ltv >= 0.9 ||
                        (ltv < 0.9 && ltv >= 0.8 && creditScore < 900) ||
                        (ltv < 0.8 && ltv >= 0.6 && creditScore < 800) ||
                        (ltv < 0.6 && creditScore < 750))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
