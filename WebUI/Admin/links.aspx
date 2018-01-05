<%@ Page Language="C#" MasterPageFile="../MasterPages/AdminAddis.master" AutoEventWireup="true" CodeFile="links.aspx.cs" Inherits="Admin_links" Title="Useful Links" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table style="font-family:Verdana;font-weight:bold;font-size:10px;border:solid 0px;" >
     <tr><td class="messagetext" style="height: 50px; width: 618px;" valign="top">
         <span style="font-size: 16pt"><span style="color: #0000ff"><span>
             <span style="font-family: Tahoma"></span></span><span style="font-size: 14pt; font-family: Tahoma">
                 Useful Links</span></span></span>
         <hr />
         &nbsp;
         <asp:Label ID="lblUser" runat="server" Text="Label" Width="341px" Font-Bold="True" Font-Names="thahoma" Font-Size="10pt" ForeColor="Blue"></asp:Label></td></tr>
    <tr>
        <td class="messagetext" style="height: 12px; width: 618px;" valign="top">
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Red" Width="308px"/></td>
    </tr>
  
    <tr><td style="width: 618px; height: 19px;"> 
        <span style="font-size: 7pt; color: #000099">Select Link Create New : </span>
    </td></tr><tr>
    <td style="width: 618px; height: 14px;" valign="top">
        &nbsp;<asp:DropDownList ID= "ddListOperation" runat ="server" Width="278px" AutoPostBack="True" OnSelectedIndexChanged="ddListOperation_SelectedIndexChanged"  >   
     </asp:DropDownList>
        <br />
        </td>
    </tr>
    <tr>
        <td style="width: 618px; height: 12px" valign="top">
           
        </td>
    </tr>
    <tr><td style="width: 618px; height: 83px;" valign="bottom">
        <span style="font-size: 7pt; color: #000099">
            <table style="width: 573px">
                <tr>
                    <td colspan="2" style="height: 40px; width: 278px;" valign="bottom">
                        <asp:Label ID="lblStatus" runat="server" Font-Size="Large" Visible="False" Width="143px"></asp:Label><br />
                        <br />
                        Link Name :(80 Char Max) 
                    </td>
                    <td colspan="2" style="height: 40px; width: 149px;" valign="bottom">
                        Link URL :(80 Char Max)</td>
                </tr>
                <tr>
                    <td style="height: 22px; width: 278px;" colspan="2">
                        <asp:TextBox ID="txtTitle" runat="server" Width="234px"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle"
                          ErrorMessage="Link Name is Required !" ValidationGroup="contactUs" Width="174px"></asp:RequiredFieldValidator><br /><br />
                    </td>
                    <td style="height: 22px; width: 149px;" colspan="2">
                       <asp:TextBox ID="txtFileName" runat="server" Width="233px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFileName"
                            ErrorMessage="Url is not Valid !" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?" ValidationGroup="contactUs"></asp:RegularExpressionValidator>
                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFileName"
                        ErrorMessage="Link URL is  Required !" ValidationGroup="contactUs" Width="174px"></asp:RequiredFieldValidator></td>
                </tr>
            
                
            </table>
        </span>
    </td></tr><tr>
    <td style="width: 618px;" valign="top">
        &nbsp;
    </td>
    </tr>
    <tr><td style="width: 618px;">
        &nbsp;</td></tr>
     <tr><td style="width: 618px"><p class="main">Select one from the buttons below according to the actions you wish 
	(and have the permissions) to perform. <br /><br /></p>
    </td></tr>
    <tr> 
    <td style="width: 618px; height: 26px;"><asp:Button ID ="btnSave" Text ="Save" runat ="server" OnClick="btnSave_Click" ValidationGroup="contactUs"></asp:Button>&nbsp;<asp:Button ID ="btnApprove" Text ="Approve" runat ="server" OnClick="btnApprove_Click" ValidationGroup="contactUs"></asp:Button><asp:Button ID ="btnDelete" Text ="Delete" runat ="server" OnClick="btnDelete_Click" ></asp:Button>
    <asp:Button ID ="btnReset" Text ="Reset" runat ="server" OnClick="btnReset_Click"   ></asp:Button>
    </td>
    </tr>
    </table>
    
    </ContentTemplate>
    
    </asp:UpdatePanel>


</asp:Content>

