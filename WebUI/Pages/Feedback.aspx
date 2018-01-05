<%@ Page Language="C#" MasterPageFile="../MasterPages/Addis.master" AutoEventWireup="true"
    CodeFile="Feedback.aspx.cs" Inherits="Pages_Contact_us" Title="Feedback Form" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
                <table style="height: 501px" width="90%">
                    <tbody>
                        <tr>
                            <td style="text-align: left">
                                                                    
                                        <table align="left" border="0" style="text-align: justify; width: 86%;">
                                            <tr>
                                                <td >
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td style="background: #E5E5E5">
                                                                <img alt="" border="0" height="1" src="../images/spacer.gif" width="1" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td height="24">
                                                                <img alt="" border="0" height="1" src="../images/spacer.gif" width="13" /><img 
                                                                    alt="" border="0" height="19" src="../images/ico1.gif" width="19" />&nbsp; <b>
                                                                <font color="#D78E37" style="font-size: 12px; text-align: left;">Feedback </font></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="background: #E5E5E5">
                                                                <img alt="" border="0" height="1" src="../images/spacer.gif" width="1" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                                                    
                                        <asp:Panel runat="server" ID="Comment">
                                            <table style="width: 425px; text-align: left">
                                                <tbody>
                                                    
                                                    <tr>
                                                        <td style="width: 114px; height: 7px">
                                                            </td>
                                                        <td style="width: 444px; height: 7px">
                                                            <asp:Label ID="lblMsg" runat="server" __designer:wfdid="w403" Font-Bold="True" 
                                                                Font-Names="Tahoma" Font-Size="12px" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            FirstName:</td>
                                                        <td>
                                                            <asp:TextBox runat="server" CssClass="txt" Width="177px" ID="txtFirstName" 
                                                                __designer:wfdid="w404"></asp:TextBox>
                                                            <span style="color: #ff0000">* 
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                                __designer:wfdid="w405" ControlToValidate="txtFirstName" 
                                                                ErrorMessage="Please enter Firstname"></asp:RequiredFieldValidator>
                                                            </span>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Last Name:</td>
                                                        <td>
                                                            <asp:TextBox runat="server" CssClass="txt" Width="177px" ID="txtLastName" 
                                                                __designer:wfdid="w406"></asp:TextBox>
                                                            <span style="color: #ff0000">* </span>&nbsp;<asp:RequiredFieldValidator runat="server"
                                                                ControlToValidate="txtLastName" ErrorMessage="Last Name  Required" Display="None"
                                                                ValidationGroup="Comment" Font-Size="8pt" ID="RequiredFieldValidator4" 
                                                                __designer:wfdid="w407"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Email:</td>
                                                        <td colspan="1" valign="top">
                                                            <asp:TextBox runat="server" CssClass="txt" Width="177px" ID="txtEmail" 
                                                                __designer:wfdid="w408"></asp:TextBox>
                                                            <span style="color: #ff0000">* </span>&nbsp;<asp:RequiredFieldValidator runat="server"
                                                                ControlToValidate="txtEmail" ErrorMessage="Email Addres  Required" Display="None"
                                                                ValidationGroup="Comment" Font-Size="8pt" ID="RequiredFieldValidator2" 
                                                                __designer:wfdid="w409"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                                __designer:wfdid="w410" ControlToValidate="txtEmail" Display="None" 
                                                                ErrorMessage="Email Address is not Valid" Font-Size="8pt" Height="7px" 
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                                ValidationGroup="Comment" Width="138px"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="FormText">
                                                            Subject:</td>
                                                        <td>
                                                            <asp:TextBox runat="server" CssClass="txt" Width="176px" ID="txtSubject" 
                                                                __designer:wfdid="w411"></asp:TextBox>
                                                            <span style="color: #ff0000">* </span>&nbsp;<asp:RequiredFieldValidator 
                                                                runat="server" ControlToValidate="txtSubject" ErrorMessage="Subject Required"
                                                                Display="None" ValidationGroup="Comment" Font-Size="8pt" ID="RequiredFieldValidator5"
                                                                __designer:wfdid="w412"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 137px" class="FormText" valign="top">
                                                            Comment:</td>
                                                        <td style="height: 137px; " valign="middle">
                                                            <asp:TextBox ID="txtComment" runat="server" __designer:wfdid="w413" 
                                                                CssClass="txt" Font-Size="13px" Height="91px" TextMode="MultiLine" 
                                                                Width="322px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                __designer:wfdid="w414" ControlToValidate="txtComment" Display="None" 
                                                                ErrorMessage="Comment Required" Font-Size="8pt" ValidationGroup="Comment" 
                                                                Width="171px"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 43px">
                                                        </td>
                                                        <td style="height: 43px; text-align: center">
                                                            <asp:Button ID="cmdSend" runat="server" __designer:wfdid="w415" 
                                                                CssClass="btnregistration" OnClick="cmdSend_Click" Text="Send" 
                                                                ValidationGroup="Comment" />
                                                            &nbsp; &nbsp; &nbsp;&nbsp;
                                                            <input ID="Reset1" class="btnregistration" language="javascript" 
                                                                name="cmdReset" onclick="return Reset1_onclick()" type="reset" value="Reset" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 114px; height: 53px">
                                                        </td>
                                                        <td style="height: 53px; text-align: center">
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="panFeedback" Visible="False" __designer:wfdid="w416">
                                            <asp:Label runat="server" Width="417px" ID="lblConfirmation" __designer:wfdid="w417">
  <br />
    <h2>  Thank You !</h2>
      <br />
         Your comment has been submitted successfully, and we will contact you soon.<br />
         Thank you very much for your comment! 
                                            </asp:Label>
                                        </asp:Panel>
                                    
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Content>
