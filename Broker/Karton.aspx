<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Karton.aspx.cs" Inherits="Broker.Karton" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
   Produkti Karton Jeshil
    </div>
        <div>    <asp:Label ID="textComentLabelTPL" runat="server" Text="Vendosni Targen :"></asp:Label> </div>
           <div> <asp:TextBox ID="targaTXT" runat="server"></asp:TextBox>  </div>
           <div> <asp:Button ID="kontrolloBTN" runat="server" Text="Kontrollo" OnClick="kontrolloBTN_Click" /> </div>

        <div>
            <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        </div>
    </form>
</body>
</html>
