<%@ Page Language="C#" MasterPageFile="../MasterPages/AdminAddis.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="NALA_Admin_News" Title="News" ValidateRequest="false"  %>
<%@ Register TagPrefix="FCKeditorV2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="font-family:Verdana;font-weight:bold;font-size:10px;border:solid 0px;">
     <tr><td class="messagetext" style="height: 32px; width: 618px;" valign="top">
         <span style="font-size: 16pt"><span style="color: #0000ff"><span style="font-size: 14pt">
             <span style="font-family: Tahoma">News</span></span></span></span>
         <hr style="font-family: Verdana" />
         &nbsp;
         </td></tr>
    <tr style="font-family: Verdana">
        <td class="messagetext" style="height: 36px; width: 618px;" valign="top">
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Red" Width="308px"/></td>
    </tr>
 
    <tr style="font-family: Verdana"><td style="width: 618px; height: 19px;"> 
        <span style="font-size: 7pt; color: #000099">Select News Title or Create New : </span>
    </td></tr><tr style="font-family: Verdana">
    <td style="width: 618px; height: 21px;" valign="top">
        &nbsp;<asp:DropDownList ID= "ddListOperation" runat ="server" Width="203px" AutoPostBack="True" OnSelectedIndexChanged="ddListOperation_SelectedIndexChanged" >   
     </asp:DropDownList></td>
    </tr>
    <tr style="font-family: Verdana">
        <td style="width: 618px; height: 33px" valign="top">
            <asp:Panel ID="panStatus" runat="server" Height="50px" Visible="False" Width="95%">
                &nbsp;&nbsp;
                <table style="width: 583px">
                    <tr>
                        <td style="width: 75px; height: 36px">
                            <asp:Label ID="Label1" runat="server" Font-Size="7pt" ForeColor="#000099" Text="Status:"></asp:Label>&nbsp;
                            <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Size="8pt" Width="53px"></asp:Label></td>
                        <td style="width: 100px; height: 36px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 75px">
                            <asp:Label ID="Created" runat="server" Font-Size="7pt" ForeColor="#000099" Text="Created:"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:Label ID="Updated" runat="server" Font-Size="7pt" ForeColor="#000099" Text="Updated:"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 75px; height: 22px;">
                            <asp:Label ID="lblCreated" runat="server" Font-Bold="False" Font-Size="8pt" Width="200px"></asp:Label></td>
                        <td style="width: 100px; height: 22px;">
                            <asp:Label ID="lblUpdated" runat="server" Font-Bold="False" Font-Size="8pt" Width="185px"></asp:Label></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr style="font-family: Verdana"><td style="width: 618px; height: 21px;" valign="bottom">
        <span style="font-size: 7pt; color: #000099">Head Line: </span>
    </td></tr><tr style="font-family: Verdana">
    <td style="width: 618px; height: 38px;" valign="top">
        &nbsp;<asp:TextBox ID ="txtHeadLine" runat ="server" Width="268px"></asp:TextBox>
    </td>
    </tr>
    <tr style="font-family: Verdana"><td style="width: 618px; height: 23px;">
        <span style="color: #000099"> Summary: </span>
    </td></tr>
    <tr style="font-family: Verdana">
        <td style="width: 618px">
            &nbsp;<FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server" BasePath="~/FCKeditor/"
            Height="360" Width="95%">
            </FCKeditorV2:FCKeditor>
        </td>
    </tr>
    <tr style="font-family: Verdana">
        <td style="width: 618px; height: 23px;">
            <span style="color: #000099">Detail: </span>
        </td>
    </tr>
    <tr style="font-family: Verdana">
    <td style=" height: 383px; width: 618px;" valign="top">
        <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" BasePath="~/FCKeditor/"
            Height="360" Width="95%">
        </FCKeditorV2:FCKeditor>
    </td></tr>
    <tr style="font-family: Verdana">
        <td style="width: 618px; height: 20px" valign="top">
            <span style="color: #000099">AUTO-EXPIRY DATE : </span>
        </td>
    </tr>
    <tr style="font-family: Verdana">
        <td style="width: 618px; height: 14px;" valign="top">
            &nbsp; &nbsp;<asp:Label ID="lblAutoexpire" runat="server" Height="19px" Width="210px"></asp:Label><br />
            <asp:Calendar ID="Calendar1" runat="server" BorderColor="Gray" BorderStyle="Solid"
                BorderWidth="1px" CellPadding="4" CellSpacing="2" EnableTheming="True" Height="63px"
                NextMonthText="&gt;&gt;" OnSelectionChanged="Calendar1_SelectionChanged" PrevMonthText="&lt;&lt;"
                Width="220px">
                <SelectedDayStyle BackColor="#E0E0E0" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                    ForeColor="Red" />
            </asp:Calendar>
            <br />
            &nbsp;<br />
            <br />
    <asp:checkbox style="font-size: 8pt; line-height: normal; font-style: normal; font-variant: normal;" AutoPostBack="false" Checked="false" ID="chkShow" runat="server" Text="Show on News Bar" />
        </td>
    </tr>
     <tr style="font-family: Verdana"><td style="width: 618px"><p class="main">Select one from the buttons below according to the actions you wish 
	(and have the permissions) to perform. <br /><br /></p>
    </td></tr>
    <tr style="font-family: Verdana"> 
    <td style="width: 618px"><asp:Button ID ="btnSave" Text ="Save" runat ="server" OnClick="btnSave_Click"></asp:Button>&nbsp;<asp:Button ID ="btnApprove" Text ="Approve" runat ="server" OnClick="btnApprove_Click"></asp:Button><asp:Button ID ="btnDelete" Text ="Delete" runat ="server" OnClick="btnDelete_Click" ></asp:Button>
    <asp:Button ID ="btnReset" Text ="Reset" runat ="server" OnClick="btnReset_Click" ></asp:Button>
    </td>
    </tr>
    </table>
</asp:Content>

