<%@ Page Language="C#" MasterPageFile="../MasterPages/AdminAddis.master" AutoEventWireup="true"
    CodeFile="AdminDefault.aspx.cs" Inherits="ANRSEB_Admin_AdminDefault" Title="Admin Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="text-align: left;">
        <table style="width: 96%; height: 563px">
            <tr>
                <td style="width: 455px">
                    <div class="grey_top" style="width: 714px; height: 9px;" id="DIV1" onclick="return DIV1_onclick()">
                    </div>
                    <div class="grey" style="width: 621px; height: 572px;" id="DIV2" 
                        onclick="return DIV2_onclick()">
                        <h2 style="text-align: justify">
                            Admin Home</h2>
                        <p style="text-align: justify">
                            The administrators section allows authorized administrators to carry out specific
                            tasks. Once you are in this section, you can access the pages you have been granted
                            permission to by following the links to the left and right of this center section.
                        </p>
                        <p style="text-align: justify">
                            The set of links you see at the left of this page, under the heading of Administration,
                            provide access to the home page of the administrative section (this page itself),
                            the User Accounts management page and to the User Groups maintenance page. The first
                            link (Admin Home) brings you back to this administrative Home Page. The 'User Accounts'
                            link takes you to a page where you can view or modify your own user account (or
                            that of others); depending on the level of permissions assigned by the user accounts
                            administrator. The 'User Groups' link allows you to view or modify user groups provided
                            you have been given the necessary permissions to do so.
                        </p><br />
                        <blockquote>
                            <p style="text-align: justify">
                                <b>NOTE :</b> While these Administration links appear consistently throughout the
                                administrative section, you may be denied access to the User Accounts and/or the
                                User Groups management page. Only members of the administrators groups will have
                                complete access to both those pages.
                            </p><br />
                        </blockquote>
                        <p style="text-align: justify">
                            The links that appear to your right are organized under a specific page family as
                            designated by a bold yellow in dark-green background. The regular face yellow links
                            with hollow images of circular shape at their left may be followed to access a particular
                            page in the heading page family. Only links to the pages you can access are provided
                            at the right pane.
                        </p>
                        <p style="text-align: justify">
                            If you click one of those links at the right side of the page, a new set links appear
                            at the left with the selected page indicated by a bold yellow heading. The links
                            below that heading enable you to modify the content that appear on the page including
                            the left images, the top banner and the center advertisement.
                        </p><br />
                        <p style="text-align: justify">
                            The top of the central section in each page displays a header in stylish font indicating
                            the current section the user is working on. Underneath the heading is a title indicating
                            the username and the functionality the user is accessing (Username @ Page Function)
                        </p>
                        <div>
                            &nbsp;</div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
