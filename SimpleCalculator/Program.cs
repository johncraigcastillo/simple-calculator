using Spectre.Console;

namespace SimpleCalculator;

public static class Program
{
    private static void Main(string[] args)
    {
        var calculator = new Calculator();
        calculator.Start();
    }
}

internal class Calculator
{
    private int _num1;
    private int _num2;
    private string? _operation;
    private int _result;

    public void Start()
    {
        AnsiConsole.MarkupLine("[bold blue]C# Command Line Calculator[/]");
        AnsiConsole.MarkupLine("[bold blue]============================[/]");
        SetNumbers();
    }

    private void SetNumbers()
    {
        _num1 = AnsiConsole.Ask<int>("Enter the [bold blue]first number[/]: ");
        _num2 = AnsiConsole.Ask<int>("Enter the [bold blue]second number[/]: ");
        SelectOperation();
    }

    private void SelectOperation()
    {
        _operation = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold blue]Select an operation[/]")
                .AddChoices(new[]
                {
                    "Add", "Subtract", "Multiply", "Divide"
                }));
        Calculate();
    }

    private void Calculate()
    {
        _result = _operation switch
        {
            "Add" => _num1 + _num2,
            "Subtract" => _num1 - _num2,
            "Multiply" => _num1 * _num2,
            "Divide" => _num1 / _num2,
            _ => throw new ArgumentOutOfRangeException()
        };
        DisplayResult();
    }

    private void DisplayResult()
    {
        AnsiConsole.MarkupLine($"[bold blue]Result:[/] {_result}");
    }
}