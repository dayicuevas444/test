public enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}

public static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        string level = logLine.Substring(1, 3);

        switch (level)
        {
            case "TRC":
                return LogLevel.Trace;

            case "DBG":
                return LogLevel.Debug;

            case "INF":
                return LogLevel.Info;

            case "WRN":
                return LogLevel.Warning;

            case "ERR":
                return LogLevel.Error;

            case "FTL":
                return LogLevel.Fatal;

            default:
                return LogLevel.Unknown;
        }
    }

    public static string OutputForShortLog(LogLevel level, string message)
    {
        return $"{(int)level}:{message}";
    }
    public static void Main(string[] args)
    {
        string logLine = "[INF] Application started";
        LogLevel level = ParseLogLevel(logLine);
        string message = logLine.Substring(6); // Extract the message part

        string output = OutputForShortLog(level, message);
        Console.WriteLine(output);
    }
}
