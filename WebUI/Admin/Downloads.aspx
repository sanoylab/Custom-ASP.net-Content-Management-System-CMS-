<%@ Page Language="C#" MasterPageFile="../MasterPages/AdminAddis.master" AutoEventWireup="true" CodeFile="Downloads.aspx.cs" Inherits="ANRSEB_Admin_Downloads" Title="Downloads" ValidateRequest="false" %>
<%@ Register TagPrefix="FCKeditorV2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="font-family:Verdana;font-weight:bold;font-size:10px;border:solid 0px" >
     <tr>
        <td class="messagetext" style="height: 50px; " valign="top">
         <span style="font-size: 16pt">
         <span style="color: #0000ff"><span style="font-size: 14pt; font-family: Tahoma">Downloads</span></span></span>
         <hr />
         &nbsp;
         <asp:Label ID="lblUser" runat="server" Width="341px" Font-Bold="True" Font-Names="thahoma" Font-Size="10pt" ForeColor="Blue"></asp:Label>
         </td>
         </tr>
    <tr>
        <td class="messagetext" style="height: 12px; " valign="top">
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Red" Width="308px"/>
         </td>
    </tr>
   
 
    <tr>
    <td style=" height: 18px;"> 
        <span style="font-size: 7pt; color: #000099">Select Downloads &nbsp;or &nbsp;Create New : </span>
    </td>
    </tr>
    <tr>
    <td style=" height: 14px;" valign="top">
        &nbsp;<asp:DropDownList ID= "ddListOperation" runat ="server" Width="278px" AutoPostBack="True" OnSelectedIndexChanged="ddListOperation_SelectedIndexChanged"  >   
     </asp:DropDownList>
        <br />
        </td>
    </tr>
    <tr>
        <td style=" height: 52px" valign="top">
            <asp:Panel ID="panUpload" runat="server" Height="50px" Width="95%">
                &nbsp;
                <br />
                <asp:Label ID="lblMassage" runat="server" Width="314px" ForeColor="Red"></asp:Label><br />
                        Upload File :&nbsp;<font color="brown"> <asp:FileUpload id="FileUpload1" runat="server" Width="319px"></asp:FileUpload> <asp:Button id="btnUpload" onclick="btnUpload_Click" runat="server" Text="Upload" Width="70px" Height="21px"></asp:Button></font></asp:Panel>
        </td>
    </tr>
    <tr>
    <td style=" height: 83px;" valign="bottom">
      
            <table style="width: 568px">
                <tr>
                    <td colspan="2" style="height: 40px; width: 146px;" valign="bottom">
                        <asp:Label ID="lblStatus" runat="server" Font-Size="Large" Visible="False" Width="143px"></asp:Label><br />
                        <br />
                        DOCUMENT TITLE :(80 Char Max) 
                    </td>
                    <td colspan="2" style="height: 40px; width: 278px;" valign="bottom">
                        FILE NAME :(80 Char Max)</td>
                </tr>
                <tr>
                    <td style="height: 23px; width: 146px;" colspan="2">
                        <asp:TextBox ID="txtTitle" runat="server" Width="219px"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                            ErrorMessage="Document Title Required !" ValidationGroup="Minits" Width="184px"></asp:RequiredFieldValidator></td>
                    <td style="height: 23px; width: 278px;" colspan="2">
                       <asp:TextBox ID="txtFileName" runat="server" Width="234px" ></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFileName"
                            ErrorMessage="File Name is Rerquired !" ValidationGroup="Minits"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 146px">
                        DOCUMENT TYPE : (50 Char Max) 
                    </td>
                    <td colspan="2" style="width: 278px">
                        DOWNLOAD SIZE :(50 CharMax)
                    </td>
                </tr>
                <tr>
                    <td style="height: 9px; width: 146px;" colspan="2">
                        <p class="main">
                            <asp:DropDownList ID="cmbDocType" runat="server">
                            </asp:DropDownList>&nbsp;</p>
                    </td>
                    <td style="height: 9px; width: 278px;" colspan="2" valign="top">
                        <asp:TextBox ID="txtSize" runat="server" Width="231px"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSize"
                            ErrorMessage="Document Size Required!" ValidationGroup="Minits"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 279px; height: 19px">
                        DESCRIPTION :(255 char Max) </td>
                    <td colspan="3" style="height: 19px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 50px" colspan="4">
                        <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" BasePath="~/FCKeditor/"
            Height="360" Width="95%">
        </FCKeditorV2:FCKeditor></td>
                </tr>
            </table>
      
    </td>
    </tr>
     <tr>
     <td style="width: 618px"><p class="main">
     Select one from the buttons below according to the actions you wish 
	(and have the permissions) to perform. <br /><br /></p>
    </td>
    </tr>
    <tr> 
    <td style="width: 618px; height: 26px;"><asp:Button ID ="btnSave" Text ="Save" runat ="server" OnClick="btnSave_Click" ValidationGroup="Minits"></asp:Button>&nbsp;<asp:Button ID ="btnApprove" Text ="Approve" runat ="server" OnClick="btnApprove_Click"></asp:Button><asp:Button ID ="btnDelete" Text ="Delete" runat ="server" OnClick="btnDelete_Click" ></asp:Button>
    <asp:Button ID ="btnReset" Text ="Reset" runat ="server" OnClick="btnReset_Click" ></asp:Button>
    </td>
    </tr>
    </table>
</asp:Content>

