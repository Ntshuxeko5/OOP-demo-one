class Vehicle  // base class (parent) 
{

    //for each vehicle we need Make, Model and Year.
    public string Make { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }

    public virtual string GetDescription()
    {
        return $"{Year} {Make} {Model}"; //retuens the Year, Make and Model of the vehicle
    }
}

class Car : Vehicle  // derived class (child) Car extends Vehicle
{
    public int DoorCount { get; set; }

    public override string GetDescription()
    {
        return$"{base.GetDescription()} - {DoorCount} doors"; //Description plus the number of doors
    }
}

class Truck : Vehicle  // derived class (child) Truck extends Vehicle
{
    public double PayloadTons { get; set; }

    public override string GetDescription()
    {
        return $"{base.GetDescription()} - {PayloadTons} tons payload"; //Description with the Payload Tons
    }
}

// sealed — prevents further inheritance. Used when a class is complete
// and extending it further would break its intended behaviour.
sealed class ElectricCar : Car  // Extends Car
{
    public int BatteryRangeKm { get; set; }

    public override string GetDescription()
    {
        return $"{base.GetDescription()} - {BatteryRangeKm}Km battery Range"; // Description with Battery Range
    }
}



class Program
{
    static void Main(string[] args)
    {
        List<Vehicle> fleet = new List<Vehicle>
    {
        new Car { Make = "Ford", Model = "Mustang", Year = "2022 ", DoorCount = 2 },
        new Truck { Make = "Toyota", Model = "Hilux", Year = "2021 ", PayloadTons = 1.5 },
        new ElectricCar { Make = "Tesla", Model = "Model 3", Year = "2023 ", DoorCount = 4, BatteryRangeKm = 500 }
    };

        foreach (var vehicle in fleet)
        {
            Console.WriteLine(vehicle.GetDescription());
        }
    }
}