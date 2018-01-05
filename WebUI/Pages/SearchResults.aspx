<%@ Page Language="C#" MasterPageFile="~/MasterPages/Addis.master" AutoEventWireup="true" CodeFile="SearchResults.aspx.cs" Inherits="Pages_SearchResults" Title="Search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div >
 <br />
	     <b><font style="font-size: 12px;" color="#D78E37">Search </font></b><br />
            <span ><b><asp:Literal ID="lblResult" runat="server"></asp:Literal></b></span><br />
            <asp:Repeater ID="rptSearchResults" runat="server">
                <ItemTemplate>
                    <img src="../images/arrow.gif" alt="Image"  />
                    <a title='<%# DataBinder.Eval(Container.DataItem, "Title")%>' 
                        class="twg" 
                        href='<%# DataBinder.Eval(Container.DataItem,"Url")%>'>
                        <%# DataBinder.Eval(Container.DataItem, "Title")%>
                    </a><br /><br />
                </ItemTemplate>
            </asp:Repeater>
        </div>
</asp:Content>


