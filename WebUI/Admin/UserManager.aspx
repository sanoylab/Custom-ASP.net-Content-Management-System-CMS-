<%@ Page Language="C#" MasterPageFile="../MasterPages/AdminAddis.master" AutoEventWireup="true" CodeFile="UserManager.aspx.cs" Inherits="admin_UserManager" Title="User Manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <table >
      <tr>
        <td colspan ="4"><asp:Label ID="lblMsg" runat ="server" Font-Bold="True" Font-Names="SansSerif" Font-Size="Medium" ForeColor="#C00000" ></asp:Label></td>
      </tr> 
      <tr style="color: #000080">
          <td valign="top" style="margin:1 1 1 1;" >
              <asp:ListBox ID="lstUserList" runat ="server" Width="131px" OnSelectedIndexChanged="lstUserList_SelectedIndexChanged" AutoPostBack="True" Font-Names="Verdana" >
              </asp:ListBox><br/>
          </td>
          <td valign="top">
            <table>
                <tr><td><asp:Button Width="80px" ID ="btnNewUser" Text ="New User" runat ="server" OnClick="btnNewUser_Click" ></asp:Button></td></tr>
                <tr><td><asp:Button Width="80px" ID ="btnDelete" Text ="Delete" runat ="server" Enabled="False" OnClick="btnDelete_Click" ></asp:Button ></td></tr>
            </table>
          </td>
      </tr>
      <tr><td colspan ="3" style="height: 5px"><hr/></td> </tr>
      <tr>
        <td colspan="2"><asp:Button ID="btnSavePermission" Text="Save" runat="server" OnClick="btnSavePermission_Click"/></td>
        <td colspan="2"><asp:Button ID="btnSaveUserProperties" Text="Save" runat="server" OnClick="btnSaveUserProperties_Click"/></td>
      </tr>
      <tr>
          <td colspan="2" style="margin:1 1 1 1;vertical-align:top;">
              <asp:GridView ID ="gvRoleList" runat ="server" Width="215px" AutoGenerateColumns="False" DataKeyNames ="ID" BorderColor="LightSteelBlue" Font-Names="Verdana" Font-Size="Small">
                  <Columns>
                      <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                      <asp:TemplateField HeaderText="Select">
                          <ItemTemplate>
                              <center><asp:CheckBox ID="chkPermit" runat="server" /></center>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:BoundField DataField="RoleName" HeaderText="Role Name" />
                  </Columns>
                  <RowStyle BorderColor="LightSteelBlue" />
                  <HeaderStyle BackColor="InactiveCaptionText" />
                  <AlternatingRowStyle BorderColor="LightSteelBlue" BackColor="WhiteSmoke" />
                  <EditRowStyle BorderColor="LightSteelBlue" />
                  <FooterStyle BackColor="InactiveCaptionText" BorderColor="LightSteelBlue" />
              </asp:GridView>
              
          </td>
          <td valign="top">
            <table>
                <tr>
                  <td>User Name :</td> 
                  <td ><asp:TextBox ID ="txtUserName" runat = "server" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                  <td>Password :</td> 
                  <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ></asp:TextBox></td>
                </tr>
                <tr>
                  <td>Confirm Password :</td> 
                  <td><asp:TextBox ID ="txtConfirmPassword" runat = "server" TextMode="Password" ></asp:TextBox></td>
                </tr>
                <tr>
                  <td >First Name :</td> 
                  <td ><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                  <td>Middle Name :</td> 
                  <td><asp:TextBox ID ="txtMiddleName" runat = "server"></asp:TextBox></td>
                </tr>
                <tr>
                  <td>Last Name :</td> 
                  <td><asp:TextBox ID ="txtLastName" runat = "server" ></asp:TextBox></td>
                </tr>
            </table>
        </td>
      </tr>
    </table>
        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
