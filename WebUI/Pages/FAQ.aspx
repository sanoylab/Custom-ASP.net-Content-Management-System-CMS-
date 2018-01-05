<%@ Page Language="C#" MasterPageFile="~/MasterPages/Addis.master" AutoEventWireup="true" CodeFile="FAQ.aspx.cs" Inherits="Pages_FAQ" Title="Frequently Asked Questions" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function DIV1_onclick() {

}

// ]]>
</script>

 
    <table align="center" width="100%" border="0" style="text-align: justify">
        <tr>
            <td style="height: 20px">
               
                     
                     <table align="left" border="0" style="text-align: justify; width: 86%;">
                         <tr>
                             <td>
                                 <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                     <tr>
                                         <td style="background: #E5E5E5">
                                             <img alt="" border="0" height="1" src="../images/spacer.gif" width="1" /></td>
                                     </tr>
                                     <tr>
                                         <td height="24">
                                             <img alt="" border="0" height="1" src="../images/spacer.gif" width="13" /><img 
                                                 alt="" border="0" height="19" src="../images/ico1.gif" width="19" />&nbsp; FAQ<b><font 
                                                 color="#D78E37" style="font-size: 12px; text-align: left;"> </font></b>
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
            <td>
                
                    
                    
                    
                    <div class="content" id="DIV1" onclick="return DIV1_onclick()" style="width: 482px">
                    
                    
                    <asp:Panel runat="server" ID="answer" Visible="false" Height="53px" Width="308px">
        <div  style=" width:154%; margin-left:7px" >
	       <b> <asp:Literal ID="lblTitle" runat="server"></asp:Literal></b><br />
	     <asp:Literal ID="lblBody" runat="server"></asp:Literal>
        </div>
        <hr style="width:155%" />
        </asp:Panel>
        <div style="text-align: justify">
            <asp:Repeater ID="rptFAQ" runat="server">
                <ItemTemplate>
                
                <table >
                <tr>
                 <td><img src="../images/arrow.gif" alt="Image"  /></td>
                 <td><a href='<%# "FAQ.aspx?Id=" + DataBinder.Eval(Container.DataItem,"ID")%>'>
                        <%# DataBinder.Eval(Container.DataItem, "Question")%>
                    </a></td>
                </tr>
                </table>
	                
                   
                </ItemTemplate>
            </asp:Repeater>
        </div>
                    
             </div>       
                    
                    
                    
                    
                    
                    
                    
                    
            </td>
        </tr>
    </table>
	    <br />
	    
</asp:Content>


