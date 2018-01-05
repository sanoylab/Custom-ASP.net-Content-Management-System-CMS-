<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminAddis.master" AutoEventWireup="true"
    CodeFile="PhotoGalleryCatagory.aspx.cs" Inherits="MFA_WebAdmin_PhotoGalleryCatagory"
    Title="Photo Gallery Catagory" %>

<%@ Register TagPrefix="FCKeditorV2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="border-right: 0px solid; border-top: 0px solid; font-weight: bold;
                font-size: 10px; border-left: 0px solid; border-bottom: 0px solid; font-family: Verdana">
                <tbody>
                    <tr>
                        <td style="width: 618px; height: 32px" class="messagetext" valign="top">
                            <span style="font-size: 16pt"><span style="color: #0000ff"><span style="font-size: 14pt">
                                <span style="font-family: Tahoma"></span></span></span></span><span style="font-size: 14pt;
                                    font-family: Tahoma">
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal></span> <span style="font-size: 14pt; font-family: Tahoma">Photo Gallery
                            Catagory</span><br />
                            <hr style="font-family: Verdana" />
                            &nbsp;<asp:Label ID="lblUser" runat="server" Font-Bold="True" Font-Names="thahoma"
                                Font-Size="10pt" ForeColor="Black" Text="Label" Width="341px"></asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="font-family: Verdana">
                        <td style="width: 618px; height: 36px" class="messagetext" valign="top">
                            <asp:Label ID="lblMessage" runat="server" Width="308px" Font-Bold="True" Font-Size="8pt"
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr style="font-family: Verdana">
                        <td style="width: 618px; height: 36px" class="messagetext" valign="top">
                            &nbsp;<asp:Panel ID="panStatus" runat="server" Width="100%">
                                Status:<asp:Literal ID="lblStatus" runat="server"></asp:Literal></asp:Panel>
                        </td>
                    </tr>
                    <tr style="font-family: Verdana">
                        <td style="width: 618px; height: 19px">
                            <span style="font-size: 7pt; color: #000099">Select&nbsp;Photo Gallery&nbsp;Catagory
                                or Create New : </span>
                        </td>
                    </tr>
                    <tr style="font-family: Verdana">
                        <td style="width: 618px; height: 21px" valign="top">
                            &nbsp;<asp:DropDownList ID="ddListOperation" runat="server" Width="203px" AutoPostBack="True"
                                OnSelectedIndexChanged="ddListOperation_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="font-family: Verdana">
                        <td style="width: 618px; height: 21px" valign="bottom">
                            <span style="font-size: 7pt; color: #000099">Catagory Name: </span>
                        </td>
                    </tr>
                    <tr style="font-family: Verdana">
                        <td style="width: 618px; height: 38px" valign="top">
                            &nbsp;<asp:TextBox ID="txtHeadLine" runat="server" Width="268px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="font-family: Verdana">
                        <td style="width: 618px">
                            <p class="main">
                                Select one from the buttons below according to the actions you wish (and have the
                                permissions) to perform.
                                <br />
                                <br />
                            </p>
                        </td>
                    </tr>
                    <tr style="font-family: Verdana">
                        <td style="width: 618px">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Save"></asp:Button>&nbsp;<asp:Button
                                ID="btnApprove" OnClick="btnApprove_Click" runat="server" Text="Approve"></asp:Button><asp:Button
                                    ID="btnDelete" OnClick="btnDelete_Click" runat="server" Text="Delete"></asp:Button>
                            <asp:Button ID="btnReset" OnClick="btnReset_Click" runat="server" Text="Reset"></asp:Button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
