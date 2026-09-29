public static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string dept = department?.ToUpper() ?? "OWNER";

        if (id == null)
        {
            return $"{name} - {dept}";
        }

        return $"[{id}] - {name} - {dept}";
    }
    public static void Main(string[] args)
    {
        int? id = 123;
        string name = "Josefa equis";
        string? department = null;

        string badge = Print(id, name, department);
        Console.WriteLine(badge);
    }
}
