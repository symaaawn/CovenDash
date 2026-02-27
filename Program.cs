/**
 * Dashboard Program
 * Shows stuff when new console is opened 
 * dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true
 */
using Spectre.Console;

AnsiConsole.Clear();

AnsiConsole.Write(
    new Panel("[bold purple]C O V E N[/]")
      .Header("[yellow]Dashboard[/]")
      .Expand()
    );

// Time
var today = DateTime.Now;
AnsiConsole.MarkupLine($"[green]Date:[/]  {today:dddd, dd MMM yyyy}");

// System Info
AnsiConsole.MarkupLine("[bold]System[/]");
AnsiConsole.MarkupLine($"Machine: [yellow]{Environment.MachineName}[/]");
AnsiConsole.MarkupLine($"OS: [yellow]{Environment.OSVersion}[/]");
AnsiConsole.MarkupLine($"Uptime: [yellow]{GetUptime()}[/]");

AnsiConsole.WriteLine("");

static string GetUptime()
{
  try
  {
    var uptimeText = System.IO.File.ReadAllText("/proc/uptime");
    var seconds = double.Parse(uptimeText.Split(' ')[0]);
    var ts = TimeSpan.FromSeconds(seconds);
    return $"{(int)ts.TotalHours}h {ts.Minutes}m";
  }
  catch
  {
    return "Unknown";
  }
}
