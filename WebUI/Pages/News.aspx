<%@ Page Language="C#" MasterPageFile="~/MasterPages/Addis.master" AutoEventWireup="true"
    CodeFile="News.aspx.cs" Inherits="Pages_News" Title="News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="90%">
        <tr>
            <td>
                 <table border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr><td style="background: #E5E5E5"><img src="../images/spacer.gif" width="1" height="1" border="0" alt=""></td></tr>
			   	<tr>
			   		<td height="24"><img src="../images/spacer.gif" width="13" height="1" border="0" alt=""><img src="../images/ico1.gif" width="19" height="19" border="0" alt="">&nbsp;
			   		<b><font style="font-size: 12px;" color="#D78E37">
                    News
                </font></b>
			   		</td>
			   	</tr>
				<tr><td style="background: #E5E5E5"><img src="../images/spacer.gif" width="1" height="1" border="0" alt=""></td></tr>
			</table>
            </td>
        </tr>
        <tr>
            <td style="text-align: justify">
                <asp:GridView ID="GridView1" runat="server" PagerStyle-ForeColor="#666" PagerStyle-Font-Size="X-Small"
                    PagerStyle-Font-Bold="false" PagerSettings-PreviousPageText="Previous" PagerSettings-NextPageText="Next"
                    PagerSettings-LastPageText="Last" PagerSettings-FirstPageText="First" PagerSettings-Mode="NextPreviousFirstLast"
                    PagerSettings-Position="TopAndBottom" RowStyle-HorizontalAlign="NotSet" PagerStyle-HorizontalAlign="Center"
                    PageSize="4" ShowHeader="false" Width="100%" PageIndex="0" AllowPaging="True"
                    AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" CellPadding="4"
                    DataSourceID="objNews">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table align="center" width="100%">
                                    <tr>
                                        <td>
                                           <img src="../images/arrow.gif" /> <a href='Detail.aspx?nid=<%# DataBinder.Eval(Container.DataItem,"Id")%>'>
                                                <%# DataBinder.Eval(Container.DataItem, "Title")%>
                                            </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p>
                                                <%# DataBinder.Eval(Container.DataItem, "HomePageSummary")%>
                                            </p>
                                        </td>
                                    </tr>
                                    <tr align="right" valign="top">
                                        <td valign="top" align="right">
                                            <a href='Detail.aspx?nid=<%# DataBinder.Eval(Container.DataItem,"Id")%>' class="detail_a">
                                                View Details </a>
                                        </td>
                                    </tr>
                                    <tr><td><hr /></td></tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                        NextPageText="Next" Position="TopAndBottom" PreviousPageText="Previous" />
                    <PagerStyle Font-Bold="False" Font-Size="X-Small" ForeColor="#000666" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="objNews" runat="server" TypeName="Sanoy.AddisTower.DA.News"
        SelectMethod="ShowNews"></asp:ObjectDataSource>
</asp:Content>
