<%@ Page Language="C#" MasterPageFile="~/MasterPages/Addis.master" AutoEventWireup="true"
    CodeFile="PhotoGallery.aspx.cs" Inherits="Pages_PhotoGallery" Title="Photo Gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center" style="width: 100%">
        <tr>
            <td colspan="3">
                <b><font style="font-size: 12px;" color="#D78E37">Photo Gallery </font></b>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 262px; text-align: left;">
                <div id="myImageFlow" class="imageflow">
                     <asp:DataList ID="dlstImageGallery" EnableTheming="false" runat="server" DataKeyField="ID"
                    GridLines="None" Width="100%" RepeatColumns="3">
                    <ItemTemplate>
                        <table cellpadding="6" style="width: 100%;">
                            <tr>
                                <td style="width: 1px;">
                                    <span style="padding: 10px 0 13px 3px;"><a title='<%# DataBinder.Eval(Container.DataItem, "Title")%>'
                                        href='<%#"../PhotoGallery/Thumbnails/" + DataBinder.Eval(Container.DataItem,"Thumbnails")%>'
                                        style="text-decoration: none">
                                        <img style="border: 1px solid #999999;" src='<%#"../PhotoGallery/Thumbnails/" + DataBinder.Eval(Container.DataItem,"Thumbnails")%>'
                                            width="130px" height="120px" alt='<%# DataBinder.Eval(Container.DataItem, "Title")%>'
                                            style="border: none 0 #000" />
                                    </a></span>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>