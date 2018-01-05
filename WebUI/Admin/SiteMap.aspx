<%@ Page Language="C#" MasterPageFile="../MasterPages/AdminAddis.master" AutoEventWireup="true" CodeFile="SiteMap.aspx.cs" Inherits="Admin_SiteMap" Title="SiteMap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:UpdatePanel ID="UpdatePanel1"  runat="server">
    <ContentTemplate>
    <table style="font-family:Verdana;font-weight:bold;font-size:10px;border:solid 0px;">
     <tr><td class="messagetext" style="height: 71px; width: 618px;" valign="top">
         <span style="font-size: 16pt"><span style="color: #0000ff"><span>
             <span style="font-family: Tahoma"></span></span><span>
                 </span><span style="font-size: 14pt; font-family: Tahoma">Site Map</span><br />
         </span></span>
         <hr />
         &nbsp;
         <asp:Label ID="lblUser" runat="server" Text="Label" Width="341px" Font-Bold="True" Font-Names="thahoma" Font-Size="10pt" ForeColor="Blue"></asp:Label></td></tr>
    <tr>
        <td class="messagetext" style="height: 36px; width: 618px;" valign="top">
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Red" Width="308px"/></td>
    </tr>
    <tr><td style="width: 618px; height: 19px;"> 
        <span style="font-size: 7pt; color: #000099">Select Content by the Title or Create New: </span>
    </td></tr><tr>
    <td style="width: 618px; height: 21px;" valign="top">
        &nbsp;<asp:DropDownList ID= "ddListOperation" runat ="server" Width="203px" AutoPostBack="True" OnSelectedIndexChanged="ddListOperation_SelectedIndexChanged" >   
     </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 618px; height: 45px" valign="top">
            &nbsp;
                            <asp:Label ID="Label1" runat="server" Font-Size="7pt" ForeColor="#000099" Text="Status:"></asp:Label>
                            <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Size="8pt" Width="53px"></asp:Label><br />
        </td>
    </tr>
    <tr>
    <td style=" height: 187px; width: 618px;" valign="top">
        <table style="width: 567px">
            <tr>
                <td style="width: 7px; height: 13px;" valign="top">
                    <asp:Label ID="Label2" runat="server" Font-Size="7pt" ForeColor="#000099" Text="LINK TEXT  : " Width="179px"></asp:Label>
                  
                </td>
            </tr>
            <tr>
                <td style="width: 7px; height: 4px" valign="top">
                    <asp:TextBox ID="txtLinkName" runat="server" Width="290px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLinkName"
                        ErrorMessage="Link Name  Required !" ValidationGroup="contactUs" Width="174px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 7px" valign="top">
                    <asp:Label ID="Label4" runat="server" Font-Size="7pt" ForeColor="#000099" Text="LINK URL  :" Width="104px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 7px" valign="top">
                    <asp:TextBox ID="txtUrl" runat="server" Width="286px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUrl"
                        ErrorMessage="Link Url  Required !" ValidationGroup="contactUs" Width="163px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 7px;" valign="top">
                    <asp:Label ID="Label6" runat="server" Font-Size="7pt" ForeColor="#000099" Text="WRITE MAIN OR KEYWORDS ABUT THIS PAGE  :" Width="358px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 7px" valign="top">
                    <asp:TextBox ID="txtKeyWord" runat="server" Width="282px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtKeyWord"
                        ErrorMessage="Key Words Required !" ValidationGroup="contactUs" Width="174px"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 7px" valign="top">
                    <asp:Label ID="Label3" runat="server" Font-Size="7pt" ForeColor="#000099" Text="WRITE MAIN OR KEYWORDS ABUT THIS PAGE  :"
                        Width="358px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 7px; height: 49px" valign="top">
                    <asp:TextBox ID="txtMain" runat="server" Height="45px" TextMode="MultiLine" Width="459px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMain"
                        ErrorMessage="Description Required !" ValidationGroup="contactUs" Width="174px"></asp:RequiredFieldValidator></td>
            </tr>
        </table>
        &nbsp;</td></tr>
     <tr><td style="width: 618px"><p class="main">Select one from the buttons below according to the actions you wish 
	(and have the permissions) to perform. <br /><br /></p>
    </td>
    </tr>
    <tr> 
    <td style="width: 618px; height: 26px;"><asp:Button ID ="btnSave" Text ="Save" runat ="server" OnClick="btnSave_Click" ValidationGroup="contactUs"></asp:Button>&nbsp;<asp:Button ID ="btnApprove" Text ="Approve" runat ="server" OnClick="btnApprove_Click"></asp:Button><asp:Button ID ="btnDelete" Text ="Delete" runat ="server" OnClick="btnDelete_Click" ></asp:Button>
    <asp:Button ID ="btnReset" Text ="Reset" runat ="server" OnClick="btnReset_Click" ></asp:Button>
    </td>
    </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

