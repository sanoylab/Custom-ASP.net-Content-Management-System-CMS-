<%@ Page Language="C#" MasterPageFile="../MasterPages/AdminAddis.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="MFA_Web_Admin_Home" Title="Homepage" ValidateRequest="false" %>
<%@ Register TagPrefix="FCKeditorV2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="border-right: 0px solid; border-top: 0px solid; font-weight: bold;
        font-size: 10px; border-left: 0px solid; border-bottom: 0px solid; font-family: Verdana">
        <tr>
            <td class="messagetext" style="width: 618px; height: 60px" valign="top">
                <span style="font-size: 16pt"><span style="color: #fff"><span style="font-size: 14pt">
                    <span style="font-family: Tahoma">
                        <asp:Label ID="lblCaption" runat="server" ForeColor="#6E6E6E"></asp:Label></span>&nbsp;</span><br />
                </span></span>
                <hr />
                &nbsp;
                <asp:Label ID="lblUser" runat="server" Font-Bold="True" Font-Names="thahoma" Font-Size="10pt"
                    ForeColor="#6E6E6E" Width="341px"></asp:Label></td>
        </tr>
        <tr style="font-size: 7pt">
            <td class="messagetext" style="width: 618px; height: 7px" valign="top">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Red"
                    Width="308px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 618px; height: 19px">
            </td>
        </tr>
        <tr>
            <td style="width: 618px; height: 19px">
                <span style="font-size: 7pt; color: #6e6e6e">Select Content by Title or Create New : 
                </span>
            </td>
        </tr>
        <tr style="font-size: 7pt">
            <td style="width: 618px; height: 21px" valign="top">
                &nbsp;<asp:DropDownList ID="ddListOperation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddListOperation_SelectedIndexChanged"
                    Width="449px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 618px; height: 33px" valign="top">
                <asp:Panel ID="panStatus" runat="server" Height="50px" Visible="False" Width="95%">
                    &nbsp;&nbsp;
                    <table style="width: 583px">
                        <tr>
                            <td style="width: 75px; height: 36px">
                                <asp:Label ID="Label1" runat="server" Font-Size="7pt" ForeColor="#6E6E6E" Text="Status:"></asp:Label>&nbsp;
                                <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Size="8pt" Width="53px"></asp:Label></td>
                            <td style="width: 100px; height: 36px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 75px">
                                <asp:Label ID="Created" runat="server" Font-Size="7pt" ForeColor="#6E6E6E" Text="Created:"></asp:Label></td>
                            <td style="width: 100px">
                                <asp:Label ID="Updated" runat="server" Font-Size="7pt" ForeColor="#6E6E6E" Text="Updated:"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 75px">
                                <asp:Label ID="lblCreated" runat="server" Font-Bold="False" Font-Size="8pt" Width="200px"></asp:Label></td>
                            <td style="width: 100px">
                                <asp:Label ID="lblUpdated" runat="server" Font-Bold="False" Font-Size="8pt" Width="185px"></asp:Label></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 618px; height: 6px" valign="bottom">
                <span style="font-size: 7pt; color: #6e6e6e">Content 1, Title: </span>
            </td>
        </tr>
        <tr>
            <td style="width: 618px; height: 38px" valign="top">
                &nbsp;<asp:TextBox ID="txtTitle" runat="server" Width="444px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="Title Required"
                    ValidationGroup="Content"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 618px">
                <span style="color: #6e6e6e">Content 1, Detail:</span></td>
        </tr>
        <tr>
            <td style="width: 618px; height: 382px" valign="top">
                <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" BasePath="~/FCKeditor/" Height="360"
                    Width="95%">
                </FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td style="width: 618px" valign="top">
                Content 2,
            Detail:</td>
        </tr>
        <tr>
            <td style="width: 618px" valign="top">
                <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server" BasePath="~/FCKeditor/" Height="360"
                    Width="95%">
                </FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td style="width: 618px" valign="top">
            </td>
        </tr>
        <tr>
            <td style="width: 618px">
                <p class="main">
                    Select one from the buttons below according to the actions you wish 
	(and have the permissions) to perform. 
                    <br />
                    <br />
                </p>
            </td>
        </tr>
        <tr>
            <td style="width: 618px">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" ValidationGroup="Content" />
                &nbsp;<asp:Button ID="btnApprove" runat="server" OnClick="btnApprove_Click" Text="Approve" /><asp:Button
                    ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
                <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" />
            </td>
        </tr>
    </table>
</asp:Content>

