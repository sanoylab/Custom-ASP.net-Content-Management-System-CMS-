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
using System.Net.Mail;

public partial class Pages_Contact_us : System.Web.UI.Page
{
    #region mem vars
    MailMessage mail = new MailMessage();
    #endregion

    #region event handlers
    private void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialize();
        }
    }
    protected void cmdSend_Click(object sender, EventArgs e)
    {
        SaveFeedback();
        SendFeedback();
    }
    #endregion

    #region methods
    private void Initialize()
    {

     

    }
    private void SaveFeedback()
    {
        try
        {
            if (!Sanoy.AddisTower.DA.FeedBack.IsExist(txtEmail.Text))
            {
                if (Sanoy.AddisTower.DA.FeedBack.Insert(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtSubject.Text, txtComment.Text, "Un Conformed")) ;
                {
                    Response.Redirect("RegistrationConfirmation.aspx?Status=Feedback");
                }
            }
            else
                
                lblMsg.Text = "Your E-mail Address already exist !!! <br> Please Change E-mail Address.";
        }
        catch { }
        
            


    }
    private void SendFeedback()
    {
        try
        {

            SmtpClient smtpclient = new SmtpClient();
            DataTable dt = new DataTable();

            mail.From = new MailAddress(txtEmail.Text, txtFirstName.Text + " " + txtLastName.Text);

            mail.To.Add(new MailAddress(ConfigurationManager.AppSettings["mail"].ToString(), ConfigurationManager.AppSettings["name"].ToString()));

            mail.Subject = txtSubject.Text;
            mail.Body = txtComment.Text;
            mail.Priority = MailPriority.High;



            smtpclient.Send(mail);
            txtSubject.Text = txtEmail.Text = txtFirstName.Text = txtComment.Text = txtLastName.Text = "";
            panFeedback.Visible = true;
            Comment.Visible = false;

        }
        catch (Exception ex)
        {
        }


    }
    #endregion
}
