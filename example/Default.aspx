<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="example.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 900px;
            margin-right: 0px;
        }
        .style2
        {
            width: 633px;
            text-align: left;
        }
        .style3
        {
            width: 257px;
            text-align: center;
        }
        .style4
        {
            width: 185px;
            text-align: center;
        }
        .style6
        {
            width: 260px;
            text-align: left;
        }
        .style7
        {
            width: 427px;
            text-align: center;
        }
        .style8
        {
            width: 108px;
            text-align: center;
        }
        
    </style>
    
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">   
        <ContentTemplate>
            
            <table class="style1">

             <tr>
             <td class="style2">
                       <table class="style1">
                        <tr>
                            <td rowspan="2">
                            </td>
                        </tr>
                           <tr>
                               <td class="style3" rowspan="2">
                                   <asp:Image ID="Image5" runat="server" Height="67px" ImageUrl="~/Image/adtoc.ico" Width="80px" />
                                   <asp:LinkButton ID="btnShoppingCart" runat="server" height="67px" OnClick="btnShoppingCart_Click" width="50px">0</asp:LinkButton>
                               </td>
                           </tr>
                     </table>
             </td>
             </tr>

         


          <tr>  
              <td>
                  <table class="style1">
                  <tr>
                      <td class="style2">
                         <asp:Label ID="lblProducts" runat="server" Text="Products"></asp:Label> 
                      </td>
                          <td class="style3">
                           <asp:Label ID="lblCategoryName" runat="server" Text="Categories"></asp:Label>   
                          </td>
                      
                  </tr>
                      </table>
                  </td>
          </tr>



              <tr>
                  <td>
                      <table class="style1">

                          <tr>
                              <td class="style2">

                                  <asp:Panel ID="pnlProducts" runat="server" Height="600px" ScrollBars="Auto">
                                      <asp:DataList ID="dlProducts" runat="server" Font-Bold="false" RepeatColumns="3" Width="600px">

                                          <ItemTemplate>
                                              <div>
                                                  <table class="style4">

                                                      <tr>
                                                          <td>
                                                              <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                                          </td>
                                                      </tr>

                                                      <tr>
                                                          <td>
                                                              <asp:Image ID="ImageProductPhoto" runat="server" BorderStyle="Ridge" Height="160px" ImageUrl='<%# Eval("ImageUrl") %>' Width="173px" />
                                                          </td>
                                                      </tr>
                                                      
                                                          
                                                            
                                                       <tr>
                                                            <td>Price:
                                                                <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("ProductPrice") %>'></asp:Label>
                                                            </td>
                                                       </tr>
                                                      <tr>
                                                          <td>AvailableStock:
                                                          <asp:Label ID="lblAvailableStock" runat="server" Text='<%# Eval("AvailableStock") %>' ToolTip="Available Stock"></asp:Label>
                                                          <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                                                          </td>
                                                      </tr>
                                                       
                                                        <tr>
                                                              <td>
                                                              <asp:Button ID="btnAddToCart" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ProductID") %>' OnClick="btnAddToCart_click" Text="Add To Cart" Width="100%" />
                                                              </td>
                                                        </tr>
                                                     
                                                      
                                                  </table>
                                              </div>
                                          </ItemTemplate>
                                      </asp:DataList>
                                  </asp:Panel>


                  <asp:Panel ID="pnlMyCart" runat="server" Height="600px" ScrollBars="Auto" Visible="false">
                  <table>
                    <tr>
                     <td> 
                         <asp:Label ID="lblAvailableStockAlert" runat="server"></asp:Label>                                                                                  
                      <asp:DataList ID="dlCartProducts" runat="server" Height="600px" RepeatColumns="3" Width="600px" OnSelectedIndexChanged="dlCartProducts_SelectedIndexChanged">
                       <ItemTemplate>
                       <div>


                                                                          <table style="width: 172px;">
                                                                          <tr>
                                                                              <td>
                                                                                
                                                                                      <table style="text-align: center; width: 172px;">
                                                                                          <tr>
                                                                                              <td>
                                                                                                  <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                                                                              </td>
                                                                                          </tr>
                                                                                          <tr>
                                                                                             <td>
                                                              <asp:Image ID="ImageProductPhoto" runat="server" BorderStyle="Ridge" Height="160px" ImageUrl='<%# Eval("ImageUrl") %>' Width="173px" />
                                                          </td>
                                                                                          </tr>
                                                                                          <tr>
                                                                                              <td>AvailableStock:
                                                                                                  <asp:Label ID="lblAvailableStock" runat="server" Text='<%# Eval("AvailableStock") %>' ToolTip="Available Stock"></asp:Label>
                                                                                              </td>
                                                                                          </tr>
                                                                                          <tr>
                                                                                              <td>Price:
                                                                                                  <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("ProductPrice") %>'></asp:Label>
                                                                                              </td>
                                                                                          </tr>
                                                                                          <tr>
                                                                                              <td>
                                                                                                  <asp:TextBox ID="txtProductQuantity" runat="server" AutoPostBack="True" Height="10px" OnTextChanged="txtProductQuantity_TextChanged" Text='<%# Eval("ProductQuantity") %>' Width="10px"></asp:TextBox>
                                                                                              </td>
                                                                                          </tr>
                                                                                      </table>
                                                                                      <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                                                                                
                                                                              </td>
                                                                              <tr>
                                                                                  <td>
                                                                                      <asp:Button ID="btnRemoveFromCart" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ProductID") %>' OnClick="btnRemoveFromCart_Click" Text='Remove To Cart' />
                                                                                  </td>
                                                                              </tr>
                                                                          </tr>
                                                                      </table>
                                                                  </div>
                                                              </ItemTemplate>
                                                              <ItemStyle Width="30%" />
                                                          </asp:DataList>
                                                      
                                                 
                                              </td>
                                          </tr>
                                          
                                      </table>
                                  </asp:Panel>
                             </td>



          <td class="style3" valign="top">
           <asp:Panel ID="pnlCategories" runat="server" Height="600px" ScrollBars="Auto" style="margin-left: 29px">
                                      <asp:DataList ID="dlCategories" runat="server" Width="252px">
                                          <ItemTemplate>
                                              <asp:LinkButton ID="lbtnCategory" runat="server" Text='<%# Eval("CategoryName") %>' OnClick="lbtnCategory_Click" CommangArgument='<%# Eval("CategoryID") %>'></asp:LinkButton>
                                          </ItemTemplate>
                                      </asp:DataList>
                                  </asp:Panel>




                                  <asp:Panel ID="pnlCheckout" runat="server" Visible="false" ScrollBars="Auto">
                                      <table style="width: 258px;">
                                          <tr>
                                              <td class="style3">TotalProducts: </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:TextBox ID="txtTotalProducts" runat="server" ReadOnly="true" Width="231px"></asp:TextBox>
                                                  
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>TotalPrice: </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:TextBox ID="txtTotalPrice" runat="server" ReadOnly="true" Width="231px"></asp:TextBox>
                                                  
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>

                                                  &nbsp;</td>
                                          </tr>
                                      </table>
                                  </asp:Panel>
                              </td>
                          </tr>




                          <tr>
                              <td colspan="2">

                                  <asp:Panel ID="pnlEmptyCart" runat="server" Visible="false">
                                      <div style="text-align: center;">
                                          <br />
                                          <br />
                                          <asp:Image ID="Image4" runat="server" ImageUrl="~/Image/QVcartTrans.png" Width="500px" />
                                          <br />
                                          <br />
                                      </div>
                                  </asp:Panel>

                              </td>
                          </tr>
                      </table>
                  </td>
              </tr>
              
                </table>
            
    </ContentTemplate>
            </asp:UpdatePanel>
    
    </form>
</body>
</html>
