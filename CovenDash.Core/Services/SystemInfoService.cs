namespace CovenDash.Core.Services;

public class SystemInfoService
{
    public string GetUptime()
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
}
