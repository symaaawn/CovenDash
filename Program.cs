using System;
using Spectre.Console;
using CovenDash.Dashboard;
using CovenDash.Services;
using CovenDash.Widgets;

var moonService = new MoonPhaseService();
var systemInfoService = new SystemInfoService();
var tarotService = new TarotService();

var widgets = new List<IDashboardWidget>
{
    new MoonWidget(moonService),
    new SystemInfoWidget(systemInfoService),
    new TarotWidget(tarotService)
};

var dashboard = new DashboardApp(widgets);

dashboard.Render();
