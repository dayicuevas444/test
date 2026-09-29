using System;

public class WeighingMachine
{

    public int Precision { get; }

    
    private double _weight;
    public double Weight
    {
        get => _weight;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Weight cannot be negative.");
            }
            _weight = value;
        }
    }

    public double TareAdjustment { get; set; } = 5.0;

  
    {
        get
        {
            double adjustedWeight = Weight - TareAdjustment;
            return $"{adjustedWeight.ToString($"F{Precision}")} kg";
        }
    }

    
    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
    public static void Main(string[] args)
    {
       
        WeighingMachine machine = new WeighingMachine(2);
        machine.Weight = 10.5678;
        Console.WriteLine($"Precision: {machine.Precision}");
        Console.WriteLine($"Weight: {machine.Weight}");
        Console.WriteLine($"Tare Adjustment: {machine.TareAdjustment}");
        Console.WriteLine($"Display Weight: {machine.DisplayWeight}");
    }
}
