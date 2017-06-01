<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="AddNewProducts.aspx.cs" Inherits="example.Admin.AddNewProducts" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>


    <form id="form1" runat="server">
    <div>
    
       <h4>
        Add New Products</h4>
    </div>
         
    <table style="width:100%; height: 227px;";>
        <tr>
            <td style="width: 515px;" height: 60px;">
                ProductName :
                </td>
            <td style="width: 515px; height: 60px;">
                <asp:TextBox ID="TextBox1" runat="server" Width="212px"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
        <td style="width: 515px; height: 60px;">
            Product Category :
        </td>
        <td style="width: 515px; height: 60px;">

            <asp:DropDownList ID="ddlCategory" runat="server">
            </asp:DropDownList>

            <br />

        </td>
            </tr>
         <tr>
            <td style="width: 515px;"" height: 52px;">
                ImageUrl :
                </td>
            <td style="width: 50%; height: 52px;">
                <asp:FileUpload ID="uploadProductPhoto" runat="server" />

            </td>
        </tr>
        <tr>
         <td style="width: 515px; height: 36px;">
            Product Price :
        </td>
        <td style="width: 515px; height: 36px;">
            <asp:TextBox ID="TextBox2" runat="server" Width="212px"></asp:TextBox>
            </td>
    </tr>
        <tr>
            
         <td style="width: 515px": height: 60px;">
            Product Quantity :
        </td>
        <td style="width: 515px" height: 60px;">
            <asp:TextBox ID="TextBox3" runat="server" Width="212px"></asp:TextBox>
            </td>
    </tr>

        <tr>
            <td style="width: 515px" height: 60px;">
                 
        
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
  
            </td>
        </tr>
            </table>
       
        </form>
    </body>
    </html>
    

   
        
 
