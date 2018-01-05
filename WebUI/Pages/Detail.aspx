<%@ Page Language="C#" MasterPageFile="~/MasterPages/Addis.master" AutoEventWireup="true"
    CodeFile="Detail.aspx.cs" Inherits="Pages_Detail" Title="News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <table border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr><td style="background: #E5E5E5"><img src="../images/spacer.gif" width="1" height="1" border="0" alt=""></td></tr>
			   	<tr>
			   		<td height="24"><img src="../images/spacer.gif" width="13" height="1" border="0" alt=""><img src="../images/ico1.gif" width="19" height="19" border="0" alt="">&nbsp;
			   		<b><font style="font-size: 12px;" color="#D78E37">
                    <b><font style="font-size: 12px;" color="#D78E37">
        News</font></b>
                </font></b>
			   		</td>
			   	</tr>
				<tr><td style="background: #E5E5E5"><img src="../images/spacer.gif" width="1" height="1" border="0" alt=""></td></tr>
			</table>
    <div>
        <table>
            <tr>
                <td style="width: 592px; text-align: justify;">
                    <asp:Repeater ID="rptContent" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                        
                        
                            <b><%# DataBinder.Eval(Container.DataItem,"Title","{0:}")%></b><br />
                            <br />
                            <%# DataBinder.Eval(Container.DataItem,"Body","{0:}")%>
                        </ItemTemplate>
                        <FooterTemplate>+
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
