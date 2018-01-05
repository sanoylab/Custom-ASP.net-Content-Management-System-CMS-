<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminAddis.master" AutoEventWireup="true" CodeFile="imageUploder.aspx.cs" Inherits="EIA_Admin_imageUploder" Title="Image Uploader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:Panel ID="panUpload" runat="server"  Width="95%">
                &nbsp;
                &nbsp;<br />
     <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Blue" Text="Select File Type To Upload"
         Width="199px"></asp:Label>&nbsp;<asp:DropDownList ID="ddlType" runat="server">
         <asp:ListItem>Image</asp:ListItem>
         <asp:ListItem>Other</asp:ListItem>
     </asp:DropDownList><br />
     <br />
                <br />
                <asp:Label ID="lblMassage" runat="server" Width="297px" ForeColor="Red"></asp:Label><br />
                        Upload File :&nbsp; <asp:FileUpload id="FileUpload1" runat="server" Width="356px"></asp:FileUpload> <asp:Button id="btnUpload" onclick="btnUpload_Click" runat="server" Text="Upload" Width="70px" Height="21px" CssClass="button"></asp:Button>
                        <br />
                        You can find the Uploaded file here:
                         <br /><br /><b>IMAGES: "../Uploaded/images"<br />
                         OTHER FILES: "../Uploaded/other"</b>
                        
                        </asp:Panel>
</asp:Content>

