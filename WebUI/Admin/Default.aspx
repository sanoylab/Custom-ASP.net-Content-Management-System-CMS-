<%@ Page Language="C#" MasterPageFile="../MasterPages/Addis.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="MFA_Web_Admin_Default" Title="Addis Tower Business Center - Web Administrator Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p align="center">
        <table width="80%" align="center">
            <tr>
                <td>
                 <b><font style="font-size: 12px;" color="#D78E37">
                    Web Admin Login</font></b>
                </td>
            </tr>
            <tr>
                <td style="height: 203px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Login ID="LogInAuthenticate" TabIndex="1" runat="server" Width="179px" OnAuthenticate="LogInAuthenticate_Authenticate"
                                Height="177px" FailureTextStyle-Wrap="true" FailureText="Invalid Username or Password!"
                                FailureTextStyle-Font-Size="XX-Small" LoginButtonStyle-CssClass="submit" CheckBoxStyle-ForeColor="#666"
                                CheckBoxStyle-Font-Size="X-Small" LabelStyle-Font-Size="X-Small" LabelStyle-ForeColor="#666"
                                TextBoxStyle-Font-Size="XX-Small" TextBoxStyle-Height="10PX" TextBoxStyle-Width="110px">
                                <CheckBoxStyle ForeColor="#000666" Font-Size="X-Small"></CheckBoxStyle>
                                <TextBoxStyle Width="110px" Height="10px" Font-Size="XX-Small"></TextBoxStyle>
                                <LoginButtonStyle CssClass="submit"></LoginButtonStyle>
                                <LabelStyle ForeColor="#000666" Font-Size="X-Small"></LabelStyle>
                                <FailureTextStyle Wrap="True" Font-Size="XX-Small"></FailureTextStyle>
                            </asp:Login>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                </td>
            </tr>
            </table>
</asp:Content>
