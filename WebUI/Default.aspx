<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
<link href="Css/style.css" rel="stylesheet" type="text/css">

<style type="text/css">
<!--
.style1 {
	color: #FFFFFF;
	font-weight: bold;
}
-->


/*** set the width and height to match your images **/

#slideshow {
    position:relative;
    height:198px;
}

#slideshow IMG {
    position:absolute;
    top:0;
    left:0;
    z-index:8;
    opacity:0.0;
}

#slideshow IMG.active {
    z-index:10;
    opacity:1.0;
}

#slideshow IMG.last-active {
    z-index:9;
}

    .style2
    {
        height: 9px;
    }

    .style3
    {
        height: 19px;
        font-weight: 700;
    }

    .style5
    {
        width: 368px;
    }

</style>
<script type="text/javascript" src="Javascripts/jquery-1.2.6.min.js"></script>

<script type="text/javascript">

/*** 
    Simple jQuery Slideshow Script
    Released by Jon Raasch (jonraasch.com) under FreeBSD license: free to use or modify, not responsible for anything, etc.  Please link out to me if you like it :)
***/

function slideSwitch() {
    var $active = $('#slideshow IMG.active');

    if ( $active.length == 0 ) $active = $('#slideshow IMG:last');

    // use this to pull the images in the order they appear in the markup
    var $next =  $active.next().length ? $active.next()
        : $('#slideshow IMG:first');

    // uncomment the 3 lines below to pull the images in random order
    
    // var $sibs  = $active.siblings();
    // var rndNum = Math.floor(Math.random() * $sibs.length );
    // var $next  = $( $sibs[ rndNum ] );


    $active.addClass('last-active');

    $next.css({opacity: 0.0})
        .addClass('active')
        .animate({opacity: 1.0}, 1000, function() {
            $active.removeClass('active last-active');
        });
}

$(function() {
    setInterval( "slideSwitch()", 5000 );
});

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <table  border="0" align="center" bgcolor="#FFFFFF">
  <tr>
    <td width="774">
    <table border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="208" valign="top">
	    <table border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td height="89" width="205" align="center" style="background: #1D1D1D"><span class="style1">ADDIS TOWER BUSINESS CENTER</span></td>
				</tr>
				<tr>
					<td height="191" align="center">
						<table border="0" cellpadding="0" cellspacing="0" width="130">
							<tr>
								<td height="26"><div align="justify"><img src="images/menu_ico.gif" width="8" height="7" border="0" alt=""> 
                                    <a href="Default.aspx">Home</a></div></td>
						  </tr>
							<tr><td style="background: #D3D6DB"><div align="justify"><img src="images/spacer.gif" width="1" height="1" border="0" alt=""></div></td></tr>
							<tr>
								<td height="26"><div align="justify"><img src="images/menu_ico.gif" width="8" height="7" border="0" alt=""> 
                                    <a href="Pages/AddisTower.aspx?Id=3">Motorcycle</a></div></td>
						  </tr>
							<tr><td style="background: #D3D6DB"><div align="justify"><img src="images/spacer.gif" width="1" height="1" border="0" alt=""></div></td></tr>
							<tr>
								<td height="26"><div align="justify"><img src="images/menu_ico.gif" width="8" height="7" border="0" alt=""> 
                                    <a href="Pages/AddisTower.aspx?Id=4">Spare Parts</a></div></td>
						  </tr>
							<tr><td style="background: #D3D6DB"><div align="justify"><img src="images/spacer.gif" width="1" height="1" border="0" alt=""></div></td></tr>
							<tr>
								<td height="26"><div align="justify"><img src="images/menu_ico.gif" width="8" height="7" border="0" alt=""> 
                                    <a href="Pages/News.aspx">News</a></div></td>
						  </tr>
							<tr><td style="background: #D3D6DB"><div align="justify"><img src="images/spacer.gif" width="1" height="1" border="0" alt=""></div></td></tr>
							<tr>
								<td height="26"><div align="justify"><img src="images/menu_ico.gif" width="8" height="7" border="0" alt=""> 
                                    <a href="Pages/Downloads.aspx?Id=1">Downloads</a></div></td>
						  </tr>
							<tr><td style="background: #D3D6DB"><div align="justify"><img src="images/spacer.gif" width="1" height="1" border="0" alt=""></div></td></tr>
							<tr>
								<td height="26"><div align="justify"><img src="images/menu_ico.gif" width="8" height="7" border="0" alt=""> 
                                    <a href="Pages/PhotoGallery.aspx?Id=1">Photo Gallery</a></div></td>
						  </tr>
							<tr><td style="background: #D3D6DB"><img src="images/spacer.gif" width="1" height="1" border="0" alt=""></td></tr>
						</table>
					</td>
				</tr>
				<tr><td><img src="images/cn_top.gif" width="32" height="7" border="0" alt="" hspace="14"></td></tr>
			</table>
		</td>
		<td width="1" style="background: #DBDBDB"><img src="images/spacer.gif" width="1" height="1" border="0" alt=""></td>
		<td>
			<div><a href="Pages/AddisTower.aspx?Id=1"><img src="images/m1.gif" width="176" height="89" border="0" alt=""></a><a href="Pages/AddisTower.aspx?Id=2"><img src="images/m2.gif" width="176" height="89" border="0" alt="" hspace="1"></a><a href="Pages/ContactUs.aspx"><img src="images/m3.gif" width="210" height="89" border="0" alt=""></a></div>
			<div id="slideshow">
            
            <img src="images/main.jpg" width="564" height="198" border="0" class="active" alt="">
             <img src="images/main2.jpg" width="564" height="198" border="0" alt="">
             <img src="images/main3.jpg" width="564" height="198" border="0" alt="">
             <img src="images/main4.jpg" width="564" height="198" border="0" alt="">
             <img src="images/main5.jpg" width="564" height="198" border="0" alt="">
            
            </div>
		</td>
	</tr>
	<tr>
		<td valign="top" style="background: url(images/sn_top.gif) no-repeat bottom left">
			<table border="0" cellpadding="0" cellspacing="0" width="205">
				<tr>
					<td height="26" style="background: #1E1E1E"><span class="style1"><img src="images/spacer.gif" width="21" height="1" border="0" alt=""><img src="images/sn_ico.gif" width="19" height="19" border="0" alt=""> &nbsp;&nbsp;NEWS</span></td>
				</tr>
				<tr><td><img src="images/cn_bot.gif" width="32" height="7" border="0" alt="" hspace="14"></td></tr>
				<tr>
					<td style="background: url(images/bg1.gif) no-repeat left middle">

           <asp:Repeater ID="rptContent" runat="server">
                                            <HeaderTemplate>
                                                <table width="90%" align="center">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <img src="Images/arrow.gif" />
                                                    </td>
                                                    <td>
                                                        <a href='Pages/Detail.aspx?type=N&amp;nid=<%# Eval("Id")%>'>
                                                            <%# Eval("Title")%>
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <%# Eval("HomePageSummary")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <SeparatorTemplate>
                                            </SeparatorTemplate>
                                            <FooterTemplate>
                                                </table></FooterTemplate>
                                        </asp:Repeater>

					</td>
				</tr>
				
				
				
			</table>
		</td>
		<td style="background: #DBDBDB"><img src="images/spacer.gif" width="1" height="1" border="0" alt=""></td>
		<td valign="top" style="background: url(images/c_bg.gif)">
			<table border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td style="background: #89B04E; width: 564px;" width="204" class="style2" 
                        colspan="2">
                        <table width="99%">
                        <tr><td><img src="images/spacer.gif" width="19" height="1" border="0" alt=""><img src="images/gr_ico.gif" width="19" height="19" border="0" alt="">
                        </td><td class="style5"> <b><font color="#ffffff" style="font-size: 12px;">
                            <asp:Literal ID="litTitle" runat="server" meta:resourcekey="litTitleResource1"></asp:Literal>
                        </font></b> <img src="images/2000_s.gif" width="1" height="11" border="0" alt="" ></td>
                        <td><asp:TextBox ID="txtSearchSite" runat="server" BorderColor="#006699" 
                                BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="11px" 
                                ForeColor="#006699" Height="15px" Width="100px"></asp:TextBox></td>
                        <td><asp:Button ID="btnSearchSite" runat="server" Text="Search" BackColor="#006699" 
                                BorderStyle="None" BorderWidth="1px" Font-Names="Arial" ForeColor="White" 
                                onclick="btnSearchSite_Click" /></td>
                        </tr>
                        </table>
                        
                        
                       
                        </td>
				</tr>
				<tr>
					<td style="background: #89B04E"><img src="images/spacer.gif" width="1" height="1" border="0" alt=""></td>
					<td style="background: #E5E5E5"><img src="images/spacer.gif" width="1" height="1" border="0" alt=""></td>
				</tr>
			</table>
			<div><img src="images/gr_bot.gif" width="32" height="7" border="0" alt="" hspace="13"></div>
			<table border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="188" height="37" align="center"><img src="images/f_products.gif" width="114" height="13" border="0" alt=""></td>
					<td width="198" align="center"><img src="images/f_services.gif" width="110" height="14" border="0" alt=""></td>
					<td width="178" align="center"><img src="images/f_solutions.gif" width="116" height="14" border="0" alt=""></td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" style="background: #ffffff">
				<tr>
					<td width="187" align="center" valign="top">
						<table border="0" cellpadding="0" cellspacing="0">
							<tr><td><img src="images/spacer.gif" width="1" height="4" border="0" alt=""></td></tr>
					      	<tr>
					      		<td><img id="imgMotor" runat="server" src="" width="150" height="78" border="0" alt="" vspace="8"></td>
					      	</tr>
							<tr>
								<td width="150">
	<b><asp:Literal ID="litMotorName" runat="server"></asp:Literal></b> 
								</td>
							</tr>
							<tr><td><img src="images/spacer.gif" width="1" height="8" border="0" alt=""></td></tr>
							<tr><td>
							<asp:Literal ID="litDescription" runat="server"></asp:Literal>
							</div>
							</td></tr>
							<tr><td><img src="images/spacer.gif" width="1" height="12" border="0" alt=""></td></tr>
					   </table>
 
					</td>
					<td style="background: #A9BC05"><img src="images/spacer.gif" width="1" height="1" border="0" alt=""></td>
					<td width="197" align="center" valign="top">
						<table border="0" cellpadding="0" cellspacing="0">
							<tr><td><img src="images/spacer.gif" width="1" height="4" border="0" alt=""></td></tr>
					      	<tr>
					      		<td><img id="imgSparepart" runat="server" src="" width="150" height="78" border="0" alt="" vspace="8"></td>
					      	</tr>
							<tr>
								<td width="150">
	<b><asp:Literal ID="litSparepart" runat="server"></asp:Literal></b> 
								</td>
							</tr>
							<tr><td><img src="images/spacer.gif" width="1" height="8" border="0" alt=""></td></tr>
							<tr><td>
							<div class="t10">
<asp:Literal ID="litSpareDescription" runat="server"></asp:Literal>
							</div>
							</td></tr>
							<tr><td><img src="images/spacer.gif" width="1" height="12" border="0" alt=""></td></tr>
					   </table>
					
					</td>
					<td style="background: #A9BC05"><img src="images/spacer.gif" width="1" height="1" border="0" alt=""></td>
					<td width="178" align="center" valign="top">
						<asp:UpdatePanel ID="Updatepanel1" runat="server">
						<ContentTemplate>
						<table>
            <tr><td><b>Search:</b></td></tr>
            <tr><td>
                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlCategory_SelectedIndexChanged" 
                    Font-Names="Arial" Font-Size="11px" ForeColor="#006699" Width="150px">
                <asp:ListItem Selected="True">-Select-</asp:ListItem>
                <asp:ListItem>Motorcycle</asp:ListItem>
                <asp:ListItem>Sparepart</asp:ListItem>
                </asp:DropDownList></td></tr>
            <tr><td class="style3"><asp:Literal ID="litCategory" runat="server"></asp:Literal> </td></tr>
            <tr><td>
                <asp:DropDownList ID="ddlCategory0" runat="server" Font-Names="Arial" 
                    Font-Size="11px" ForeColor="#006699" Width="150px">
                <asp:ListItem Selected="True">-Select-</asp:ListItem>
                <asp:ListItem>Motorcycle</asp:ListItem>
                <asp:ListItem>Sparepart</asp:ListItem>
                </asp:DropDownList> </td></tr>
            <tr><td><b>Name: </b> </td></tr>
            <tr><td>
                <asp:TextBox ID="txtSearchSite0" runat="server" BorderColor="#006699" 
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="11px" 
                    ForeColor="#006699" Height="15px" Width="150px"></asp:TextBox>
                </td></tr>
            <tr><td>
                <asp:Button ID="btnSearchSite0" runat="server" BackColor="#006699" 
                    BorderStyle="None" BorderWidth="1px" Font-Names="Arial" ForeColor="White" 
                    Text="Search Product" />
                </td></tr>
            </table>
						
						</ContentTemplate>
						</asp:UpdatePanel>
					</td>
				</tr>
			</table>			
			<div><img src="images/spacer.gif" width="1" height="7" border="0" alt=""></div>
		</td>
	</tr>
	<tr>
		<td style="background: #242424"><span class="style1"><img src="images/spacer.gif" width="21" height="1" border="0" alt=""><img src="images/sn_ico.gif" width="19" height="19" border="0" alt="">&nbsp;&nbsp;PHOTO GALLERY</span></td>
		<td style="background: #DBDBDB"> <img src="images/spacer.gif" width="1" height="1" border="0" alt=""></td>
		<td>
			<table border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr><td style="background: #E5E5E5"><img src="images/spacer.gif" width="1" height="1" border="0" alt=""></td></tr>
			   	<tr>
			   		<td height="24"><img src="images/spacer.gif" width="13" height="1" border="0" alt=""><img src="images/ico1.gif" width="19" height="19" border="0" alt=""></td>
			   	</tr>
				<tr><td style="background: #E5E5E5"><img src="images/spacer.gif" width="1" height="1" border="0" alt=""></td></tr>
			</table>
		</td>
	</tr>
	<tr>
		<td valign="top">
			<div><img src="images/sn_bot.gif" width="32" height="7" border="0" alt="" hspace="14"></div>
			<div style="padding: 12px 0 10px 14px"><table border="0" cellpadding="0" cellspacing="0">
				
			   	<tr>
			   		<td align="center">
                    
                    <img src="images/header-img3.jpg" width="158" height="95" class="active" />
                    
                    
                    </td>
			   	</tr>
				<tr>
					<TD><div align="right">More...</div></TD>
				</tr>
				
			</table></div>
		
		</td>
		<td style="background: #DBDBDB"><img src="images/spacer.gif" width="1" height="1" border="0" alt=""></td>
		<td height="89" width="581" valign="top">
		<table width="98%" align="center">
		<tr><td></td></tr>
		<tr><td>
            <asp:Literal ID="litContent" runat="server" 
                meta:resourcekey="litContentResource1"></asp:Literal>
            </td></tr>
		<tr><td>
            <asp:Literal ID="litContent1" runat="server" 
                meta:resourcekey="litContent1Resource1"></asp:Literal>
            </td></tr>
		</table>
   </td>
	</tr>
	<tr>
		<td colspan="3" style="background: #A0A0A0"><img src="images/spacer.gif" width="1" height="13" border="0" alt=""></td> 	</tr> 	<tr> 		<td align="center" height="65">
                            &nbsp;</td> 		<td style="background: #DBDBDB"><a href="images/img.html"><img src="images/spacer.gif" width="1" height="1" border="0" alt=""></a></td> 		<td>			<div style="padding-left: 25px">
		<table>
		<tr>
		  <td><a href="Default.aspx">Home</a></td>
		  <td>|</td>
		  <td><a href="Pages/AddisTower.aspx?Id=1">About Us</a></td>
		  <td>|</td>
		  <td><a href="Pages/News.aspx">News</a></td>
		  <td>|</td>
		  <td><a href="Pages/FAQ.aspx">FAQ</a></td>
		  <td>|</td>
		  <td><a href="Pages/SiteMap.aspx">Sitemap</a></td>
		  <td>|</td>
		  <td><a href="Pages/Feedback.aspx">Feedback</a></td>
		  <td>|</td>
		</tr>
		<tr><td colspan=12>Copyright &copy; <asp:Literal ID="litYear" runat="server"></asp:Literal>. Site Designed & Developed by: </td></tr>
		</table>
		
		</div>
		</td>
	</tr>
</table>

    
    </td>
  </tr>
</table>
    
    </div>
    </form>
</body>
</html>
