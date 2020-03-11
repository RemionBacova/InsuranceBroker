<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Broker.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="tplButton" runat="server" Text="TPL" OnClick="tplButton_Click" />
        <asp:Button ID="kartonButton" runat="server" Text="Karton" OnClick="kartonButton_Click" />
        <asp:Button ID="kufitareButton" runat="server" Text="Kufitare" OnClick="kufitareButton_Click" />
    </form>
</body>
</html>
