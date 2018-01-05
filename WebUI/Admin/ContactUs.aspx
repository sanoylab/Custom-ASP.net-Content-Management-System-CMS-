<%@ Page Language="C#" MasterPageFile="../MasterPages/AdminAddis.master" AutoEventWireup="true"
    CodeFile="ContactUs.aspx.cs" Inherits="Admin_ContactUs" Title="Contact Us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[



// ]]>
    </script>

    
            <table style="border-right: 0px solid; border-top: 0px solid; font-weight: bold;
                font-size: 10px; border-left: 0px solid; width: 91%; border-bottom: 0px solid;
                font-family: Verdana">
                <tbody>
                    <tr>
                        <td style="width: 618px; height: 71px" class="messagetext" valign="top">
                            <span style="font-size: 16pt"><span style="color: #000"><span><span style="font-family: Tahoma">
                            </span></span><span style="font-size: 14pt; font-family: Tahoma">Contact Us</span><br />
                            </span></span>
                            <hr id="HR1" onclick="return HR1_onclick()" />
                            &nbsp;
                            <asp:Label ID="lblUser" runat="server" Width="341px" Text="Label" Font-Bold="True"
                                Font-Names="thahoma" Font-Size="10pt" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 618px; height: 36px" class="messagetext" valign="top">
                            <asp:Label ID="lblMessage" runat="server" Width="308px" Font-Bold="True" Font-Size="8pt"
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 618px; height: 19px">
                            <span style="font-size: 7pt; color: #000">Select Contacts by Name or Create New :
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 618px; height: 21px" valign="top">
                            &nbsp;<asp:DropDownList ID="ddListOperation" runat="server" Width="203px" AutoPostBack="True"
                                OnSelectedIndexChanged="ddListOperation_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 618px; color: #000000; height: 54px" valign="top">
                            <asp:Panel ID="panStatus" runat="server" Width="95%" Height="50px" Visible="False">
                                &nbsp;&nbsp;
                                <table style="width: 566px">
                                    <tbody>
                                        <tr>
                                            <td style="width: 75px; height: 36px">
                                                <asp:Label ID="Label1" runat="server" Text="Status:" Font-Size="7pt" ForeColor="DimGray"></asp:Label>&nbsp;
                                                <asp:Label ID="lblStatus" runat="server" Width="53px" Font-Bold="True" Font-Size="8pt"></asp:Label>
                                            </td>
                                            <td style="width: 100px; height: 36px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 75px; height: 14px">
                                                <asp:Label ID="Created" runat="server" Text="Created:" Font-Size="7pt" ForeColor="DimGray"></asp:Label>
                                            </td>
                                            <td style="width: 100px; height: 14px">
                                                <asp:Label ID="Updated" runat="server" Text="Updated:" Font-Size="7pt" ForeColor="DimGray"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 75px">
                                                <asp:Label ID="lblCreated" runat="server" Width="200px" Font-Bold="False" Font-Size="8pt"></asp:Label>
                                            </td>
                                            <td style="width: 100px">
                                                <asp:Label ID="lblUpdated" runat="server" Width="185px" Font-Bold="False" Font-Size="8pt"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            <br />
                            <br />
                            <asp:Panel ID="panUpload" runat="server" Width="95%" Height="73px">
                                <br />
                                <asp:Label ID="lblMassage" runat="server" Width="314px" ForeColor="Red"></asp:Label><br />
                                Upload Picture :&nbsp;<font color="brown">
                                    <asp:FileUpload ID="fileContactUs" runat="server" Width="319px"></asp:FileUpload>
                                    <asp:Button ID="btnUpload" OnClick="btnUpload_Click" runat="server" Width="70px"
                                        Text="Upload" Height="21px"></asp:Button></font></asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 618px; height: 187px" valign="top">
                            <table style="width: 557px">
                                <tbody>
                                    <tr>
                                        <td style="width: 7px; height: 29px" valign="top">
                                            <asp:Label ID="Label2" runat="server" Width="91px" Text="CONTACT NAME : " Font-Size="7pt"
                                                ForeColor="Black"></asp:Label>
                                            &nbsp; &nbsp;
                                        </td>
                                        <td style="width: 5px; height: 29px">
                                            <asp:TextBox ID="txtContactName" runat="server" Width="169px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Width="174px"
                                                ControlToValidate="txtContactName" ErrorMessage="Contact Name  Required !" ValidationGroup="contactUs"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="width: 44px; height: 29px" valign="top">
                                            <asp:Label ID="Label3" runat="server" Text="POSITION : " Font-Size="7pt" ForeColor="Black"></asp:Label>
                                        </td>
                                        <td style="width: 109px; height: 29px">
                                            <asp:TextBox ID="txtPosition" runat="server" Width="157px"></asp:TextBox><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7px; height: 2px" valign="top">
                                            <asp:Label ID="Label4" runat="server" Text="TELEPHONE :" Font-Size="7pt" ForeColor="Black"></asp:Label>
                                            &nbsp; &nbsp; &nbsp;&nbsp;
                                        </td>
                                        <td style="width: 5px; height: 2px" valign="top">
                                            <asp:TextBox ID="txtTel" runat="server" Width="168px"></asp:TextBox>
                                        </td>
                                        <td style="width: 44px; height: 2px" valign="top">
                                            <asp:Label ID="Label5" runat="server" Text="FAX :" Font-Size="7pt" ForeColor="Black"></asp:Label>
                                        </td>
                                        <td style="width: 109px; height: 2px" valign="top">
                                            <asp:TextBox ID="txtFax" runat="server" Width="156px"></asp:TextBox><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7px; height: 49px" valign="top">
                                            <asp:Label ID="Label6" runat="server" Width="95px" Text="EMAIL ADDRESS :" Font-Size="7pt"
                                                ForeColor="Black"></asp:Label>
                                        </td>
                                        <td style="width: 5px; height: 49px">
                                            <asp:TextBox ID="txtEmail" runat="server" Width="166px"></asp:TextBox><br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Width="100px"
                                                ControlToValidate="txtEmail" ErrorMessage="Email  Required !" ValidationGroup="contactUs"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Width="168px"
                                                ControlToValidate="txtEmail" ErrorMessage="Email Address is not Valid !" ValidationGroup="contactUs"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        </td>
                                        <td style="width: 44px; height: 49px" valign="top">
                                            <asp:Label ID="Label8" runat="server" Width="62px" Text="P.O.Box  :" Font-Size="7pt"
                                                ForeColor="Black"></asp:Label>
                                        </td>
                                        <td style="width: 109px; height: 49px" valign="top">
                                            <asp:TextBox ID="txtPOBox" runat="server" Width="166px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7px; height: 49px" valign="top">
                                            <asp:Label ID="Label7" runat="server" Width="95px" Text="Picture File Name :" Font-Size="7pt"
                                                ForeColor="Black"></asp:Label>
                                        </td>
                                        <td style="width: 5px; height: 49px">
                                            <asp:TextBox ID="txtFileName" runat="server" Width="166px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Width="100px"
                                                ControlToValidate="txtFileName" ErrorMessage="Picture File Name  Required !"
                                                ValidationGroup="contactUs"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="width: 44px; height: 49px" valign="top">
                                        </td>
                                        <td style="width: 109px; height: 49px">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 618px; height: 65px">
                            <p class="main">
                                Select one from the buttons below according to the actions you wish (and have the
                                permissions) to perform.
                                <br />
                                <br />
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 618px; height: 26px">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Save" ValidationGroup="contactUs">
                            </asp:Button>&nbsp;<asp:Button ID="btnApprove" OnClick="btnApprove_Click" runat="server"
                                Text="Approve"></asp:Button><asp:Button ID="btnDelete" OnClick="btnDelete_Click"
                                    runat="server" Text="Delete"></asp:Button>
                            <asp:Button ID="btnReset" OnClick="btnReset_Click" runat="server" Text="Reset"></asp:Button>
                        </td>
                    </tr>
                </tbody>
            </table>
       
</asp:Content>
