using Spectre.Console;

namespace CalculatorLibrary;

public class Calculator
{
    private int _num1;
    private int _num2;
    private string? _operation;
    private double _result;
    private string[]? _operationList;

    private static void Quit()
    {
        AnsiConsole.MarkupLine("[bold blue]Goodbye![/]");
        Environment.Exit(0);
    }

    public void Run()
    {
        AnsiConsole.MarkupLine("[bold blue]============================[/]");
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
        ZeroDivisionProtection();

        var prompt = new SelectionPrompt<string>()
            .Title("[bold blue]Select an operation[/]");
        foreach (var op in _operationList)
        {
            prompt.AddChoices(op);
        }

        _operation = AnsiConsole.Prompt(prompt);

        Calculate();
    }

    private void ZeroDivisionProtection()
    {
        _operationList = _num2 == 0
            ? new[] { "Add", "Subtract", "Multiply", "Quit" }
            : new[] { "Add", "Subtract", "Multiply", "Divide", "Quit" };
    }

    private void Calculate()
    {
        if (_operation == "Quit")
        {
            Quit();
        }

        _result = _operation switch
        {
            "Add" => _num1 + _num2,
            "Subtract" => _num1 - _num2,
            "Multiply" => _num1 * _num2,
            "Divide" => _num2 > 0 ? Convert.ToDouble(_num1) / _num2 : 0,
            _ => throw new ArgumentOutOfRangeException()
        };
        DisplayResult();
    }

    private void DisplayResult()
    {
        AnsiConsole.MarkupLine($"[bold blue]Result:[/] {_result}");
        Run();
    }
}