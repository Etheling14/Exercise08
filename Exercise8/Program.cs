decimal pesoCommodity, valueCommodity, valueFee, valuePromotion, valuediscounts;
string IsMonday, paymentType;
Console.BackgroundColor = ConsoleColor.Cyan;
Console.ForegroundColor = ConsoleColor.White;
Console.Clear();

do
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("======================================");
    Console.ForegroundColor = ConsoleColor.White;
    RequestData(out pesoCommodity, out valueCommodity, out IsMonday, out paymentType);
    valueFee = CalculateFee(pesoCommodity);
    valuediscounts = CalculateDiscounts(valueCommodity, valueFee);
    valuePromotion = CalculatePromotion(IsMonday, paymentType, valueCommodity, valueFee);
    ShowResults(valueFee, valuediscounts, valuePromotion);

}while(true);   

 static void RequestData (out decimal pesoCommodity, out decimal valueCommodity, out string IsMonday, out string paymentType)
{
    Console.Write($"Peso Commodity.............");
    pesoCommodity = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine($"Value Commodity............");
    valueCommodity = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine($"Is Monday? [s]i, [n]o......");
    IsMonday = Console.ReadLine();
    Console.WriteLine($"Type to payment: [E]fectivo, [T]arjeta");
    paymentType = Console.ReadLine();
}

static decimal CalculateFee (decimal pesoCommodity)
{
    if (pesoCommodity <  100) return 20000;
    if (pesoCommodity <= 150) return 25000;
    if (pesoCommodity <= 200) return 30000;
    return 35000 + (pesoCommodity - 200) / 10 * 2000;
}

static decimal CalculateDiscounts(decimal valueCommodity, decimal valueFee)
{
    if (valueCommodity < 300000) return 0;
    if (valueCommodity <= 600000) return valueFee * 0.1M;
    if (valueCommodity <= 1000000) return valueFee * 0.2M;
    return valueFee * 0.3M;
}

static decimal CalculatePromotion(string IsMonday, string paymentType, decimal valueCommodity, decimal valueFee)
{
    if (IsMonday == "S" && paymentType == "S") return valueFee * 0.5M;
    if (paymentType == "E" && valueCommodity > 1000000) return valueFee * 0.4M;
    return 0;
}

static void ShowResults (decimal valueFee, decimal valuediscounts, decimal valuePromotion)
{
    decimal totalPay;
    Console.WriteLine("Fee:         ${0,12:N0}", valueFee);
    if (valuediscounts > valuePromotion)
    {
        Console.WriteLine("Discount:    ${0,12:N0}", valuediscounts);
        totalPay = valueFee - valuediscounts;
    }
    else
    {
        Console.WriteLine("Promotion:   ${0,12:N0}", valueFee);
        totalPay = valueFee - valuePromotion;
    }
    Console.WriteLine("Total to pay:${0,12:N0}", totalPay);
    Console.ReadKey();
}