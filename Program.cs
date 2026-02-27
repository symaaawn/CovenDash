using System;
using Spectre.Console;
using CovenDash.Dashboard;
using CovenDash.Services;
using CovenDash.Widgets;

var moonService = new MoonPhaseService();

var widgets = new List<IDashboardWidget>
{
    new MoonWidget(moonService)
};

var dashboard = new DashboardApp(widgets);

dashboard.Render();
