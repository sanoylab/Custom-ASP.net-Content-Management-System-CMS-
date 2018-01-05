using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Sanoy.AddisTower.DA;

public partial class MFA_Web_Admin_Default : System.Web.UI.Page
{
    #region mem vars
    #endregion

    #region event handlers
    protected void LogInAuthenticate_Authenticate(object sender, AuthenticateEventArgs e)
    {
        try
        {
            Authenticate();
        }
        catch { }
    }
    #endregion

    #region methods
    void Authenticate()
    {
        string msg;

        if (!AdminBaseUIPage.Login(LogInAuthenticate.UserName, LogInAuthenticate.Password, Session, out msg))
        {
            LogInAuthenticate.FailureText = msg;
        }
        else //authenticated
        {
            //  if (AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session))
            Response.Redirect("AdminDefault.aspx");
        }
    }
    void LogOut()
    {
        AdminBaseUIPage.CleanUp(Session);
    }
    #endregion
}
