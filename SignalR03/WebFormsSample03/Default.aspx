<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsSample03.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-3.3.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.signalR-2.2.3.min.js" type="text/javascript"></script>
    <script type="text/javascript" src='<%= ResolveClientUrl("~/signalr/hubs") %>'></script>

    <link href="Content/gauge-bar.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/simple-gauge-bar.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input id="txtUrl" value="http://www.site.com/file.rar" type="text" />
        <input id="send" type="button" value="start download ..." />
        <br />
        <div id="bar" style="border: #000 1px solid; width:300px;"></div>
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $.connection.hub.logging = true; //اطلاعات بيشتري را در جاوا اسكريپت كنسول مرورگر لاگ مي‌كند
            var progressHub = $.connection.progressHub; //اين نام مستعار پيشتر توسط ويژگي نام هاب تنظيم شده است
            progressHub.client.updateProgressBar = function (value) {
                //متدي كه در اينجا تعريف شده دقيقا مطابق نام متد پويايي است كه در هاب تعريف شده است
                //به اين ترتيب سرور مي‌تواند كلاينت را فراخواني كند
                $("#bar").html(GaugeBar.generate(value));
            };
            $.connection.hub.start() // فاز اوليه ارتباط را آغاز مي‌كند
            .done(function () {
                $("#send").click(function () {
                    $("#send").attr('disabled', 'disabled');
                    var myClientId = $.connection.hub.id;
                    // اكنون اتصال برقرار است به سرور
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "/api/Downloader",
                        data: JSON.stringify({ Url: $("#txtUrl").val(), ConnectionId: myClientId }),
                        success: function () {
                            $("#send").removeAttr('disabled');
                        },
                        error: function () {

                        }
                    });
                });
            });
        });
    </script>
</body>
</html>
