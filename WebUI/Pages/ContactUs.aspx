<%@ Page Language="C#" MasterPageFile="~/MasterPages/Addis.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="Pages_ContactUs" Title="Contact Us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 
                    <table align="center" border="0" style="text-align: justify; width: 86%;">
                        <tr>
                            <td class="style1">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr><td style="background: #E5E5E5"><img src="../images/spacer.gif" width="1" height="1" border="0" alt=""></td></tr>
			   	<tr>
			   		<td height="24"><img src="../images/spacer.gif" width="13" height="1" border="0" alt=""><img src="../images/ico1.gif" width="19" height="19" border="0" alt="">&nbsp;
			   		<b><font style="font-size: 12px;" color="#D78E37">
                    <b><font style="font-size: 12px;" color="#D78E37">
        Contact Us</font></b>
                </font></b>
			   		</td>
			   	</tr>
				<tr><td style="background: #E5E5E5"><img src="../images/spacer.gif" width="1" height="1" border="0" alt=""></td></tr>
			</table>
                                 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Repeater ID="rptDAGSecretariatStaff" runat="server">
    <ItemTemplate>
  <span style='font-size:10.0pt;font-family:Verdana;  font-weight:bold; text-align:center';> <center>  <%# DataBinder.Eval(Container.DataItem, "Post")%> </center></span>
 <table>
 <tr>
 <td width='25%' align="left" valign="top"> <img width="65px" height="60px" style="border: 1px solid #999999;" src='../ContactUs/<%# DataBinder.Eval(Container.DataItem, "Language") %>' /> </td>
 <td width='75%' align="left">
   <table>
    <tr>
    <td> <%# (DataBinder.Eval(Container.DataItem, "ContactName", "{0:}").Length > 0 ? (  "Name:")  : "")%>
    </td>
    <td>
    <td> <%# DataBinder.Eval(Container.DataItem, "ContactName") %>
    </td>
    
    </tr> 
     <tr>
    <td> <%# (DataBinder.Eval(Container.DataItem, "Tel", "{0:}").Length > 0 ? ( "Tel:") : "")%>
    </td>
    <td>
    <td> <%# DataBinder.Eval(Container.DataItem, "Tel")%>
    </td>
    
    </tr> 
      <tr>
    <td> <%# (DataBinder.Eval(Container.DataItem, "Fax", "{0:}").Length > 0 ? ("Fax:") : "")%>
    </td>
    <td>
    <td> <%# DataBinder.Eval(Container.DataItem, "Fax")%>
    </td>
    
    </tr> 
      <tr>
    <td> <%# (DataBinder.Eval(Container.DataItem, "Email", "{0:}").Length > 0 ? ( "Email") : "")%> 
    </td>
    <td>
    <td><a href='mailto:<%# DataBinder.Eval(Container.DataItem, "Email")%>' > <%# DataBinder.Eval(Container.DataItem, "Email")%></a><br />
    </td>
    
    </tr> 
    </table></td>
 </tr>
 </table>
  
    
     
    </ItemTemplate>
    <SeparatorTemplate>
    <hr style="width:40%" /><br />
    </SeparatorTemplate>
    </asp:Repeater><br />
                                        
                            </td>
                        </tr>
                    </table>
                   
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
            width: 393px;
        }
    </style>

</asp:Content>


