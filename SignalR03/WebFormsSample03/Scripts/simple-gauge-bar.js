var GaugeBar = GaugeBar || {};

GaugeBar.generate = function (percentage) {
    if (typeof (percentage) != "number")
        return;
    if (percentage > 100 || percentage < 0)
        return;

    var colspan = 1;
    var markup = "<table class='gauge-bar-table'><tr>" +
                 "<td style='width:" + percentage.toString() +
                 "%' class='gauge-bar-completed'></td>";
    if (percentage < 100) {
        markup += "<td class='gauge-bar-tobedone' style='width:" + (100 - percentage).toString() +
                  "%'></td>";
        colspan++;
    }

    markup += "</tr><tr class='gauge-bar-statusline'><td colspan='" +
              colspan.toString() +
              "'>" +
              percentage.toString() +
              "% completed</td></tr></table>";
    return markup;
}
