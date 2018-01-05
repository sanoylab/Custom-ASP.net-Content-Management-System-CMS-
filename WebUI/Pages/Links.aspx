<%@ Page Language="C#" MasterPageFile="~/MasterPages/Addis.master" AutoEventWireup="true" CodeFile="Links.aspx.cs" Inherits="Pages_Links" Title="Useful Links" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="ContentText" align="center" style="text-align: center">
    <table align="center" border="0" style="width: 90%; text-align: justify">
        <tr>
            <td>
               <h2>
                   Useful Links</h2>
            </td>
        </tr>
        <tr>
            <td>
                     <div class="content">
                       <asp:UpdatePanel ID="UpdatePanel1"  runat="server">
            <ContentTemplate>  
                            <asp:GridView ID="gvwLinks" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                CellPadding="4" DataSourceID="objLinks" ForeColor="#333333" GridLines="None"
                                Height="239px" PageIndex="0" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last"
                                PagerSettings-Mode="NextPreviousFirstLast" PagerSettings-NextPageText="Next"
                                PagerSettings-PreviousPageText="Previous" PagerStyle-Font-Bold="True" 
                                PagerStyle-ForeColor="#666" PagerStyle-HorizontalAlign="Center" PageSize="15"
                                RowStyle-HorizontalAlign="NotSet" ShowHeader="True" Width="294px" Font-Names="Calibri" Font-Size="12px">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                        <table>
                                        <tr><td><img src="../Images/arrow.gif" /></td><td><%# DataBinder.Eval(Container.DataItem, "UrlText")%></td></tr>
                                        <tr><td>&nbsp;</td><td><a href='<%# DataBinder.Eval(Container.DataItem,"Url")%>'  target="_blank"><%# DataBinder.Eval(Container.DataItem,"Url")%></a></td></tr>
                                        </table>
                                       
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" PreviousPageText="Previous" />
                                <PagerStyle Font-Bold="True"  HorizontalAlign="Center" />
                            </asp:GridView>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                           
                         </div>
                    
                    <asp:ObjectDataSource ID="objLinks" runat="server" SelectMethod="Show" TypeName="Sanoy.AddisTower.DA.Links">
                    </asp:ObjectDataSource>
               
            </td>
        </tr>
    </table>
</div>

</asp:Content>



