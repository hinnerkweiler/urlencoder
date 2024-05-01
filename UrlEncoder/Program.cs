
using TextCopy;
using System.Net;
using Spectre.Console;

string input = "";

if (args.Length == 0)
{
    AnsiConsole.MarkupLine("[red]No arguments provided, trying clipboard content[/]");

    try
    {
        input = ClipboardService.GetText() ?? "";
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new Exception("No content in clipboard");
        }
    }
    catch (Exception e)
    {
        AnsiConsole.WriteException(e);
        throw;
    }
}
else
{
    input = args[0];
    for (int i = 1; i < args.Length; i++)
    {
        input = $"{input} {args[i]}";
    }
}

string encoded = WebUtility.UrlEncode(input);
ClipboardService.SetText(encoded);
AnsiConsole.MarkupLine($"\n\n[yellow]{encoded}[/]\n\n");

AnsiConsole.MarkupLine("[gray]Encoded string copied to clipboard[/]");
