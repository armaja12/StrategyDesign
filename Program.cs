using AssessmentConsoleApplication.Context;
using AssessmentConsoleApplication.Enums;
using AssessmentConsoleApplication.Strategies;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the vehicle class (1, 2, 3):");
        VehicleClass vehicleClass = (VehicleClass)int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the distance travel (in km):");
        decimal distance = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Is ETC payment mode (Cash/ETC):");
        string paymentMode = Console.ReadLine().Trim().ToLower();

        bool isETCPayment = paymentMode == "etc";

        ITollFeeStrategy tollFeeStrategy = GetTollFeeStrategy(vehicleClass);
        TollFeeContext tollFeeContext = new TollFeeContext(tollFeeStrategy, isETCPayment);

        decimal tollFee = tollFeeContext.CalculateTollFee(distance);
        Console.WriteLine($"Toll fee is : {tollFee:F2} PHP");
    }

    static ITollFeeStrategy GetTollFeeStrategy(VehicleClass vehicleClass)
    {
        return vehicleClass switch
        {
            VehicleClass.Class1 => new GenericTollFeeStrategy(1.0m),
            VehicleClass.Class2 => new GenericTollFeeStrategy(2.0m),
            VehicleClass.Class3 => new GenericTollFeeStrategy(3.0m),
            _ => throw new ArgumentException(nameof(vehicleClass),"Invalid vehicle class")
        };
    }
}
