<%@ Page Language="C#" MasterPageFile="../MasterPages/Addis.master" AutoEventWireup="true" CodeFile="SiteMap.aspx.cs" Inherits="Pages_SiteMap" Title="Site Map" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 83%" align=center><tr >
							<td colspan="2" style="height: 38px" > 
                                 <table align="left" border="0" 
                                     style="text-align: justify; width: 86%;">
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
                                                             alt="" border="0" height="19" src="../images/ico1.gif" width="19" />&nbsp; 
                                                         Sitemap<b><font color="#D78E37" style="font-size: 12px; text-align: left;">
                                                         </font></b>
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
&nbsp;</td>
						</tr>
						<tr>
							<td>
                                
                                   <asp:literal ID="litMidTitle" runat="server" />
								<asp:literal ID="litContent" runat="server" />
								<br />
								<br />
								<a href="#A">A</a>&nbsp;| <a href="#B">B</a>&nbsp;| <a href="#C">C</a>&nbsp;| <a href="#D">
									D</a>&nbsp;| <a href="#E">E</a>&nbsp;| <a href="#F">F</a>&nbsp;| <a href="#G">G</a>&nbsp;|
								<a href="#H">H</a>&nbsp;| <a href="#I">I</a>&nbsp;| <a href="#J">J</a>&nbsp;| <a href="#K">
									K</a>&nbsp;| <a href="#L">L</a>&nbsp;| <a href="#M">M</a>&nbsp;| <a href="#N">N</a>&nbsp;|
								<a href="#O">O</a>&nbsp;| <a href="#P">P</a>&nbsp;| <a href="#R">R</a>&nbsp;| <a href="#S">
									S</a>&nbsp;| <a href="#T">T</a>&nbsp;| <a href="#U">U</a>&nbsp;| <a href="#V">V</a>&nbsp;|
								<a href="#W">W</a>&nbsp;| <a href="#X">X</a>&nbsp;| <a href="#Y">Y</a>&nbsp;| <a href="#Z">
									Z</a>
								<asp:repeater ID="rptContent" runat="server">
									<headertemplate>
										<p class="Main">
									</headertemplate>
									<itemtemplate>
										
											<%# DataBinder.Eval(Container.DataItem,"Url","{0:}").Length<=0? "<br><a name=\""+ DataBinder.Eval(Container.DataItem,"Name") + "\"><b>" + DataBinder.Eval(Container.DataItem,"Name") + "</b></a>" : "" %>
											<%# DataBinder.Eval(Container.DataItem, "Url", "{0:}").Length > 0 ? "<a style='font-weight:normal;color:#336699' href=\"" + DataBinder.Eval(Container.DataItem, "Url") + " \">" : ""%>
											<%# DataBinder.Eval(Container.DataItem, "Url", "{0:}").Length > 0 ? DataBinder.Eval(Container.DataItem, "Title") : ""%>
											<%# DataBinder.Eval(Container.DataItem,"Url","{0:}").Length>0? "</a>" : "" %>
										
									</itemtemplate>
									<footertemplate>
										</p>
									</footertemplate>
									<separatortemplate>
										<br>
									</separatortemplate>
								</asp:repeater>
								<asp:literal ID="litContentB" runat="server" /><br />
								
							
							</td>
						</tr>
</table>
</asp:Content>


