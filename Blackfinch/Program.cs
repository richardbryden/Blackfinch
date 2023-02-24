
int loanAmountInput = 0; int assetValue = 0; int creditScore = 0;


Console.WriteLine("Lending Platform");

Console.WriteLine("Please input loan amount in £");
loanAmountInput = Convert.ToInt32(Console.ReadLine());

if (loanAmountInput > 1500000)
{
    Console.WriteLine("Application Declined");
}

if (loanAmountInput < 100000)
{
    Console.WriteLine("Application Declined");
}

Console.WriteLine("Please input the Asset value");
assetValue = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Please input the Asset value");
creditScore = Convert.ToInt32(Console.ReadLine());

double ltv = (assetValue / loanAmountInput);

if (loanAmountInput > 1000000)
{
    if (ltv < 0.6 && creditScore > 950)
    {
        Console.WriteLine("Application Declined");
    }
}
else
{
    if (ltv > 0.9)
    {
        Console.WriteLine("Application Declined");
    }

    if (ltv < 0.9 && creditScore < 900)
    {
        Console.WriteLine("Application Declined");
    }

    if (ltv < 0.8 && creditScore < 800)
    {
        Console.WriteLine("Application Declined");
    }

    if (ltv < 0.6 && creditScore < 750)
    {
        Console.WriteLine("Application Declined");
    }



}

