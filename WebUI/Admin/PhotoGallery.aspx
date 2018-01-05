<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminAddis.master" AutoEventWireup="true" CodeFile="PhotoGallery.aspx.cs" Inherits="MFA_Web_Admin_PhotoGallery" Title="Photo Gallary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="border-right: 0px solid; border-top: 0px solid; font-weight: bold;
        font-size: 10px; border-left: 0px solid; width: 91%; border-bottom: 0px solid;
        font-family: Verdana">
        <tr>
            <td class="messagetext" style="width: 618px; height: 71px" valign="top">
                <span style="font-size: 16pt">
                <span style="color: #000<a href="../Admin/Downloads.aspx?Id=1"><span>
                <span style="font-family: Tahoma">
                &nbsp;</span></span><span style="font-size: 14pt; font-family: Tahoma">Photo Gallery</span><br />
                </span></span>
                <hr />
                &nbsp;
                <asp:Label ID="lblUser" runat="server" Font-Bold="True" Font-Names="thahoma" Font-Size="10pt"
                    ForeColor="Black" Text="Label" Width="341px"></asp:Label></td>
        </tr>
        <tr style="font-size: 7pt; color: #ffffff">
            <td class="messagetext" style="width: 618px; height: 36px" valign="top">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Red"
                    Width="308px"></asp:Label></td>
        </tr>
        <tr style="font-size: 7pt; color: #ffffff">
            <td class="messagetext" style="width: 618px; color: #000099; height: 20px" valign="top">
                Select Catagory:</td>
        </tr>
        <tr style="font-size: 7pt; color: #ffffff">
            <td class="messagetext" style="width: 618px; color: #000099; height: 36px" valign="top">
                <asp:DropDownList ID="ddlCatagory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCatagory_SelectedIndexChanged" Width="315px">
                </asp:DropDownList>
                <a href="PhotoGalleryCatagory.aspx">Manage Catagory</a></td>
        </tr>
        <tr>
            <td style="width: 618px; height: 19px">
                <span style="font-size: 7pt; color: #fff">or<span style="color: #000080"> Create New
                    : </span></span>
            </td>
        </tr>
        <tr style="color: #000080">
            <td style="width: 618px; height: 21px" valign="top">
                &nbsp;<asp:DropDownList ID="ddListOperation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddListOperation_SelectedIndexChanged"
                    Width="203px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 618px; color: #000000; height: 45px" valign="top">
                <asp:Panel ID="panStatus" runat="server" Height="50px" Visible="False" Width="95%">
                    &nbsp;&nbsp;
                    <table style="width: 566px">
                        <tr>
                            <td style="width: 75px; height: 36px">
                                <asp:Label ID="Label1" runat="server" Font-Size="7pt" ForeColor="DimGray" Text="Status:"></asp:Label>&nbsp;
                                <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Size="8pt" Width="53px"></asp:Label></td>
                            <td style="width: 100px; height: 36px">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <br />
                <asp:Panel ID="panUpload" runat="server" Height="50px" Width="95%">
                    <br />
                    <asp:Label ID="lblMassage" runat="server" ForeColor="Navy" Width="314px">Thumbnaile Picture Uploader</asp:Label><br />
                    Upload Picture :&nbsp;<font color="brown">
                        <asp:FileUpload ID="fuThumb" runat="server" Width="319px" />
                        <asp:Button ID="btnUploadThumb" runat="server" Height="21px" OnClick="btnUploadThumb_Click"
                            Text="Upload" Width="70px" /></font></asp:Panel>
                <br />
                <asp:Panel ID="Panel1" runat="server" Height="50px" Width="95%">
                    <br />
                    <asp:Label ID="Label9" runat="server" ForeColor="Navy" Width="314px">Normal Picture Uploader</asp:Label><br />
                    Upload Picture :&nbsp;<font color="brown">
                        <asp:FileUpload ID="FileUpload2" runat="server" Width="319px" />
                        <asp:Button ID="btnUploadNormal" runat="server" Height="21px" OnClick="btnUploadNormal_Click" Text="Upload"
                            Width="70px" /></font></asp:Panel>
                            <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 618px; height: 187px" valign="top">
                <table style="width: 557px">
                    <tr>
                        <td style="width: 30px; height: 29px" valign="top">
                            <asp:Label ID="Label2" runat="server" Font-Size="7pt" ForeColor="Black" Text="Normal Picture Name: "
                                Width="91px"></asp:Label>
                            &nbsp; &nbsp;
                        </td>
                        <td style="width: 8px; height: 29px">
                            <asp:TextBox ID="txtPicName" runat="server" Width="169px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPicName"
                                ErrorMessage="Picture Name  Required !" ValidationGroup="contactUs" Width="174px"></asp:RequiredFieldValidator></td>
                        <td style="width: 120px; height: 29px" valign="top">
                            <asp:Label ID="Label3" runat="server" Font-Size="7pt" ForeColor="Black" Text="Thumbnails  Picture Name: "></asp:Label></td>
                        <td style="width: 109px; height: 29px">
                            <asp:TextBox ID="txtThumbnails" runat="server" Width="157px"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30px; height: 2px" valign="top">
                            Title</td>
                        <td style="width: 8px; height: 2px" valign="top">
                            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td>
                        <td style="width: 120px; height: 2px" valign="top">
                        </td>
                        <td style="width: 109px; height: 2px" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30px; height: 2px" valign="top">
                            &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp;&nbsp;
                        </td>
                        <td style="width: 8px; height: 2px" valign="top">
                            </td>
                        <td style="width: 120px; height: 2px" valign="top">
                        </td>
                        <td style="width: 109px; height: 2px" valign="top">
                            <br />
                        </td>
                    </tr>
                </table>
                &nbsp;</td>
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
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" ValidationGroup="contactUs" />&nbsp;<asp:Button
                    ID="btnApprove" runat="server" OnClick="btnApprove_Click" Text="Approve" /><asp:Button
                        ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
                <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" />
            </td>
        </tr>
    </table>
  
</asp:Content>

