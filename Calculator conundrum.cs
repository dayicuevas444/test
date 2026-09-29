using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        int result;

        switch (operation)
        {
            case "+":
                result = SimpleOperation.Addition(operand1, operand2);
                break;
            case "*":
                result = SimpleOperation.Multiplication(operand1, operand2);
                break;
            case "/":
                try
                {
                    result = SimpleOperation.Division(operand1, operand2);
                }
                catch (DivideByZeroException)
                {
                    return "Division by zero is not allowed.";
                }
                break;
            case null:
                throw new ArgumentNullException(nameof(operation));
            case "":
                throw new ArgumentException("Operation cannot be empty.", nameof(operation));
            default:
                throw new ArgumentOutOfRangeException(nameof(operation), $"Operation '{operation}' is not supported.");
        }

        return $"{operand1} {operation} {operand2} = {result}";
    }
    public static void Main(string[] args)
    {
        int operand1 = 10;
        int operand2 = 5;
        string operation = "+";

        string result = Calculate(operand1, operand2, operation);
        Console.WriteLine(result);
    }
}
