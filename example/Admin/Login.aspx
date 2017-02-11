<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="example.Admin.Login" %>

<!DOCTYPE html>
<script runat="server">

    
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
            <strong>Grocery Online Shopping<br />
            </strong>
            <br />
            <strong>Loginid:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

            </strong><strong style="text-decoration: underline">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </strong><strong>
            <br />
            </strong><strong style="text-decoration: underline">
            <br />
            </strong><strong>Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            </strong> <strong ="text-decoration: underline"></strong>

            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Font-Bold="True" ForeColor="Black" OnClick="Button1_Click" Text="Login" style="height: 26px;" />
            <br />
            <br />
             <asp:Label ID="lblAlert" runat="server" Font-Names="Aharoni" ForeColor="Red" Text="lblAlert"></asp:Label>         

        </div>
    </form>
</body>
</html>
