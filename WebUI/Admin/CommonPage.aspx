<%@ Page Language="C#" MasterPageFile="../MasterPages/AdminAddis.master" AutoEventWireup="true"
    CodeFile="CommonPage.aspx.cs" Inherits="NALA_Admin_CommonPage" Title="Common Page"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="FCKeditorV2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table style="font-family: Verdana; font-weight: bold; font-size: 10px; border: solid 0px;">
        <tr>
            <td class="messagetext" style="height: 60px; width: 618px;" valign="top">
                <span style="font-size: 16pt"><span style="color: #fff"><span style="font-size: 14pt">
                    <span style="font-family: Tahoma">
                        <asp:Label ID="lblCaption" runat="server" ForeColor="#6E6E6E"></asp:Label></span>&nbsp;</span><br />
                </span></span>
                <hr />
                &nbsp;
                <asp:Label ID="lblUser" runat="server" Width="341px" Font-Bold="True" Font-Names="thahoma"
                    Font-Size="10pt" ForeColor="#6E6E6E"></asp:Label></td>
        </tr>
        <tr style="font-size: 7pt">
            <td class="messagetext" style="height: 3px; width: 618px;" valign="top">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Red"
                    Width="308px" /></td>
        </tr>
        <tr>
            <td style="width: 618px; height: 19px">
            </td>
        </tr>
        <tr>
            <td style="width: 618px; height: 19px;">
                <span style="color: #6e6e6e"><span style="font-size: 7pt"><span style="color: #000000">
                    Select Content by </span>Title or <span style="color: #000000">Create New : </span>
                </span></span>
            </td>
        </tr>
        <tr style="font-size: 7pt; color: #000000">
            <td style="width: 618px; height: 21px;" valign="top">
                &nbsp;<asp:DropDownList ID="ddListOperation" runat="server" Width="203px" AutoPostBack="True"
                    OnSelectedIndexChanged="ddListOperation_SelectedIndexChanged">
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
            <td style="width: 618px; height: 6px;" valign="bottom">
                <span style="font-size: 7pt; color: #6e6e6e">Title: </span>
            </td>
        </tr>
        <tr>
            <td style="width: 618px; height: 38px;" valign="top">
                &nbsp;<asp:TextBox ID="txtTitle" runat="server" Width="268px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" ControlToValidate="txtTitle" runat="server" ErrorMessage="Title Required"
                    ValidationGroup="Content"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 618px;">
                <span style="color: #6e6e6e">Content: </span>
            </td>
        </tr>
        <tr>
            <td style="height: 382px; width: 618px;" valign="top">
                <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" BasePath="~/FCKeditor/" Height="360"
                    Width="95%">
                </FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td style="width: 618px">
                <p class="main">
                    Select one from the buttons below according to the actions you wish (and have the
                    permissions) to perform.
                    <br />
                    <br />
                </p>
            </td>
        </tr>
        <tr>
            <td style="width: 618px">
                <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" ValidationGroup="Content">
                </asp:Button>
                &nbsp;<asp:Button ID="btnApprove" Text="Approve" runat="server" OnClick="btnApprove_Click">
                </asp:Button><asp:Button ID="btnDelete" Text="Delete" runat="server" OnClick="btnDelete_Click">
                </asp:Button>
                <asp:Button ID="btnReset" Text="Reset" runat="server" OnClick="btnReset_Click"></asp:Button>
            </td>
        </tr>
    </table>
   
</asp:Content>
