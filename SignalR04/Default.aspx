<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SignalR04.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-2.1.3.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.signalR-2.2.0.min.js" type="text/javascript"></script>
    <script type="text/javascript" src='<%= ResolveClientUrl("~/signalr/hubs") %>'></script>
    <script src="Scripts/smoothie.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <h2>Processor</h2>
                <canvas id="Processor" width="800" height="100"></canvas>
            </div>
            <div>
                <h2>Memory</h2>
                <canvas id="Memory" width="800" height="100"></canvas>
            </div>
            <div>
                <h2>PhysicalDisk</h2>
                <canvas id="PhysicalDisk" width="800" height="100"></canvas>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        var ChartEntry = function (name) {
            var self = this;
            self.name = name;
            self.chart = new SmoothieChart({ millisPerPixel: 50, labels: { fontSize: 15 } });
            self.timeSeries = new TimeSeries();
            self.chart.addTimeSeries(self.timeSeries, { lineWidth: 3, strokeStyle: "#00ff00" });
        };

        ChartEntry.prototype = {
            addValue: function (value) {
                var self = this;
                self.timeSeries.append(new Date().getTime(), value);
            },

            start: function () {
                var self = this;
                self.canvas = document.getElementById(self.name);
                self.chart.streamTo(self.canvas);
            }
        };

        $(function () {
            $.connection.hub.logging = true;
            var performanceCounterHub = $.connection.performanceCounterHub;
            var charts = [];
            performanceCounterHub.client.newCounters = function (updatedCounters) {
                $.each(updatedCounters, function (index, updateCounter) {
                    var entry;
                    $.each(charts, function (idx, chart) {
                        if (chart.name == updateCounter.Name) {
                            entry = chart;
                            return;
                        }
                    });

                    if (!entry) {
                        entry = new ChartEntry(updateCounter.Name);
                        charts.push(entry);
                        entry.start();
                    }
                    entry.addValue(updateCounter.Value);
                });
            };
            $.connection.hub.start();
        });
    </script>
</body>
</html>
