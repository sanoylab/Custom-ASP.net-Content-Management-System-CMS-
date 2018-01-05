<%@ Page Language="C#" MasterPageFile="~/MasterPages/Addis.master" AutoEventWireup="true"
    CodeFile="AddisTower.aspx.cs" Inherits="Pages_MFA" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="99%">
    <tr><td>
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr><td style="background: #E5E5E5"><img src="../images/spacer.gif" width="1" height="1" border="0" alt=""></td></tr>
			   	<tr>
			   		<td height="24"><img src="../images/spacer.gif" width="13" height="1" border="0" alt=""><img src="../images/ico1.gif" width="19" height="19" border="0" alt="">&nbsp;
			   		<b><font style="font-size: 12px;" color="#D78E37">
                    <asp:Literal ID="litContentTitle" runat="server"></asp:Literal>
                </font></b>
			   		</td>
			   	</tr>
				<tr><td style="background: #E5E5E5"><img src="../images/spacer.gif" width="1" height="1" border="0" alt=""></td></tr>
			</table></td></tr>
     <tr>
            <td style="text-align: justify">
            <asp:Panel ID="panMotorcycle" runat="server" Visible="false">
            <table>
            <tr><td colspan="2">Search Motorcycles</td></tr>
            <tr><td>Category: </td><td><asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList></td></tr>
            <tr><td>Name: </td><td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td></tr>
            <tr><td colspan="2"><asp:Button ID="btnSearch" Text="Search" runat="server" /></td></tr>
            </table>
            
            </asp:Panel>
            <asp:Panel ID="panSparepart" runat="server" Visible="false">
            <table>
            <tr><td colspan="2">Search Sparepart</td></tr>
            <tr><td>Category: </td><td><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></td></tr>
            <tr><td>Name: </td><td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td></tr>
            <tr><td colspan="2"><asp:Button ID="Button1" Text="Search" runat="server" /></td></tr>
            </table>
            
            </asp:Panel>
            </td>
        </tr>
     <tr>
            <td style="text-align: justify">
                <asp:Literal ID="litContent" runat="server">
                </asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
