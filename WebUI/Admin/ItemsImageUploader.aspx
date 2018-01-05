<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminAddis.master"
    AutoEventWireup="true" CodeFile="ItemsImageUploader.aspx.cs" Inherits="Admin_ItemsImageUploader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul>
        <li>
            <asp:LinkButton ID="lnkUploadMotorImage" runat="server" Text="Upload Motorcycle Image"
                OnClick="lnkUploadMotorImage_Click"></asp:LinkButton><br />
            <br />
        </li>
        <li>
            <asp:LinkButton ID="lnkUploadSpareImage" runat="server" Text="Upload Sparepart Image"
                OnClick="lnkUploadSpareImage_Click"></asp:LinkButton>
        </li>
    </ul>
    <br />
    <asp:Panel ID="panUploadMotorImage" runat="server" Visible="false">
        <table>
            <tr>
                <td>
                    Select Motor Model:
                </td>
                <td>
                    <asp:DropDownList ID="ddlMotorModel" runat="server" DataSourceID="objAllMotors" DataValueField="Id"
                        DataTextField="Model">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Motor Image:
                </td>
                <td>
                    <asp:FileUpload ID="imgMotor" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="panUploadSpareImage" runat="server" Visible="false">
        <table>
            <tr>
                <td>
                    Select Sparepart Name:
                </td>
                <td>
                    <asp:DropDownList ID="ddlSparepart" runat="server" DataSourceID="objAllSpares" DataValueField="Id"
                        DataTextField="Name">
                    </asp:DropDownList>
                </td>
                <td rowspan="3">
                <asp:Image ID="imgPreview" runat="server" Width="66px" />
                </td>
            </tr>
            <tr>
                <td>
                    Sprepart Image:
                </td>
                <td>
                    <asp:FileUpload ID="imgSprepart" runat="server" />
                </td>
            </tr>
            <tr>
               <%-- <td align="right">
                    <asp:Button ID="btnPreview" runat="server" Text="Preview" OnClick="btnPreview_Click" />
                </td>--%>
                <td>
                    <asp:Button ID="btnSpareUpload" runat="server" Text="Upload" OnClick="btnSpareUpload_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:ObjectDataSource ID="objAllMotors" runat="server" TypeName="BusinessEntitySearch.Motorcycle"
        SelectMethod="PopulateAllMotorcycle"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="objAllSpares" runat="server" TypeName="BusinessEntitySearch.Sparepart"
        SelectMethod="PopulateAllSparepart"></asp:ObjectDataSource>
</asp:Content>
