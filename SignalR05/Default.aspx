<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SignalR05.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-2.1.3.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.signalR-2.2.0.min.js" type="text/javascript"></script>
    <script type="text/javascript" src='<%= ResolveClientUrl("~/signalr/hubs") %>'></script>
</head>
<body>
    <form id="form1" runat="server">
    online users count: <span id="usersCount"></span>
    </form>
    <script type="text/javascript">
        $(function () {
            $.connection.hub.logging = true;
            var onlineUsersHub = $.connection.onlineUsersHub;
            onlineUsersHub.client.updateUsersOnlineCount = function (count) {
                $('#usersCount').text(count);
            };
            $.connection.hub.start();
        });
    </script>
</body>
</html>
