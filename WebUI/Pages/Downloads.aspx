<%@ Page Language="C#" MasterPageFile="~/MasterPages/Addis.master" AutoEventWireup="true"
    CodeFile="Downloads.aspx.cs" Inherits="Pages_Downloads" Title="Downloads" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr><td style="background: #E5E5E5"><img src="../images/spacer.gif" width="1" height="1" border="0" alt=""></td></tr>
			   	<tr>
			   		<td height="24"><img src="../images/spacer.gif" width="13" height="1" border="0" alt=""><img src="../images/ico1.gif" width="19" height="19" border="0" alt="">&nbsp;
			   		<b><font style="font-size: 12px;" color="#D78E37">
                    <b><font style="font-size: 12px;" color="#D78E37">
        <asp:Literal ID="litMidTitle" runat="server"></asp:Literal></font></b>
                </font></b>
			   		</td>
			   	</tr>
				<tr><td style="background: #E5E5E5"><img src="../images/spacer.gif" width="1" height="1" border="0" alt=""></td></tr>
			</table>
    
<br />
    <div style="text-align:justify">
    <ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader"
        ContentCssClass="accordionContent" FadeTransitions="true" FramesPerSecond="40"
        TransitionDuration="250" AutoSize="None" DataSourceID="objPublication">
        <HeaderTemplate>
            <img src="../images/arrow.gif" />
            &nbsp; &nbsp; <a>
                <%# DataBinder.Eval(Container.DataItem, "Title")%>
            </a>
        </HeaderTemplate>
        <ContentTemplate>
            <div style="float: left">
                <img src='../images/<%# DataBinder.Eval(Container.DataItem, "ImgUrl")%>' alt="Image"
                    title="Image" height="20px" width="16px" />
            </div>
            &nbsp;
            <%# DataBinder.Eval(Container.DataItem, "Summary")%>
            <hr width="50%" />
            Document Size :
            <%# DataBinder.Eval(Container.DataItem, "Size")%>
            <br />
            Download: <a href='<%= DocumentPath() %><%# DataBinder.Eval(Container.DataItem,"Url")%>'
                style="font-weight: normal;">
                <%# DataBinder.Eval(Container.DataItem, "Title")%></a> &nbsp;&nbsp;
            <img src="../images/download_icon_animated.gif" height="13px" width="10px" /><br />
            <br />
        </ContentTemplate>
    </ajaxToolkit:Accordion></div>
    <asp:ObjectDataSource ID="objPublication" runat="server" TypeName="Sanoy.AddisTower.DA.Downloads"
        SelectMethod="ShowAllPublications">
        <SelectParameters>
            <asp:QueryStringParameter Type="string" QueryStringField="Id" Name="Catagory" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
