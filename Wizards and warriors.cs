using System;

public class Character
{
    public string Class { get; set; }
    public int Level { get; set; }
    public int HitPoints { get; set; }
}

public class Destination
{
    public string Name { get; set; }
    public int Inhabitants { get; set; }
}

public enum TravelMethod
{
    Walking,
    Horseback
}

public static class GameMaster
{
    public static string Describe(Character character) =>
        $"You're a level {character.Level} {character.Class} with {character.HitPoints} hit points.";

    public static string Describe(Destination destination) =>
        $"You've arrived at {destination.Name}, which has {destination.Inhabitants} inhabitants.";

    public static string Describe(TravelMethod travelMethod) =>
        travelMethod switch
        {
            TravelMethod.Walking => "You're traveling to your destination by walking.",
            TravelMethod.Horseback => "You're traveling to your destination on horseback.",
            _ => throw new ArgumentOutOfRangeException(nameof(travelMethod))
        };

    public static string Describe(Character character, Destination destination, TravelMethod travelMethod) =>
        $"{Describe(character)} {Describe(travelMethod)} {Describe(destination)}";

    public static string Describe(Character character, Destination destination) =>
        Describe(character, destination, TravelMethod.Walking);
       public static void Main(string[] args)
    {
        Character character = new Character { Class = "Wizard", Level = 5, HitPoints = 30 };
        Destination destination = new Destination { Name = "Mystic Forest", Inhabitants = 100 };
        TravelMethod travelMethod = TravelMethod.Horseback;

        string description1 = Describe(character);
        string description2 = Describe(destination);
        string description3 = Describe(travelMethod);
        string description4 = Describe(character, destination, travelMethod);
        string description5 = Describe(character, destination);

        Console.WriteLine(description1);
        Console.WriteLine(description2);
        Console.WriteLine(description3);
        Console.WriteLine(description4);
        Console.WriteLine(description5);
    } 
}
