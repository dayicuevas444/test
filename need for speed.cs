public class RemoteControlCar
{
    private int _speed;
    private int _batteryDrain;
    private int _batteryPercentage;
    private int _distanceDriven;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
        _batteryPercentage = 100;
        _distanceDriven = 0;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            _distanceDriven += _speed;
            _batteryPercentage -= _batteryDrain;
        }
    }

    public int DistanceDriven()
    {
        return _distanceDriven;
    }

    public bool BatteryDrained()
    {
        return _batteryPercentage < _batteryDrain;
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

public class RaceTrack
{
    private int _distance;

    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        int maxDistance =
            (100 / carBatteryDrain(car)) * carSpeed(car);

        return maxDistance >= _distance;
    }

    private int carSpeed(RemoteControlCar car)
    {
        var speedField = typeof(RemoteControlCar)
            .GetField("_speed",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);

        return (int)speedField.GetValue(car);
    }

    private int carBatteryDrain(RemoteControlCar car)
    {
        var drainField = typeof(RemoteControlCar)
            .GetField("_batteryDrain",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);

        return (int)drainField.GetValue(car);
    }
    public static void Main(string[] args)
    {
        RemoteControlCar car = new RemoteControlCar(20, 2);
        RaceTrack track = new RaceTrack(100);

        Console.WriteLine($"Can the car finish the track? {track.TryFinishTrack(car)}");

        car.Drive();
        Console.WriteLine($"Distance driven: {car.DistanceDriven()} meters");
        Console.WriteLine($"Is battery drained? {car.BatteryDrained()}");

        RemoteControlCar nitroCar = RemoteControlCar.Nitro();
        RaceTrack longTrack = new RaceTrack(200);

        Console.WriteLine($"Can the nitro car finish the long track? {longTrack.TryFinishTrack(nitroCar)}");
    }
}
