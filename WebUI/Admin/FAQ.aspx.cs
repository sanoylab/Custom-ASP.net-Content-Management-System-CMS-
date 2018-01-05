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
public partial class Admin_FAQ : System.Web.UI.Page
{
    #region mem vars

    #endregion

    #region event handlers
    private void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialize();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        Populate();
        ddListOperation.Items[0].Selected = true;
        clear();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Delete(ddListOperation.SelectedValue);
        Populate();
        ddListOperation.Items[0].Selected = true;
        clear();
        lblMessage.Text = "The content is deleted Succesfuly";
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        Approve(ddListOperation.SelectedValue.ToString());
        Populate();
        ddListOperation.Items[0].Selected = true;
        clear();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void cboTWG_SelectedIndexChanged(object sender, EventArgs e)
    {
        Populate();
        clear();
    }
    protected void ddListOperation_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateFilelds();

    }
    #endregion

    #region methods
    private void Initialize()
    {
        try
        {
            //Session["User"] = 1;
            //Session["UserName"] = "Sanoy";
            if (Session["User"] != null)
            {
                lblUser.Text = Session["UserName"].ToString() + " @ Faq";

               // btnSave.Enabled = ddListOperation.Enabled = btnApprove.Enabled = btnDelete.Enabled = AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session);
                Populate();
            }
            else
                Response.Redirect("Default.aspx");
        }
        catch { }

    }
    private void Populate()
    {
        try{
        DataTable dt = new DataTable();        
        ddListOperation.Items.Clear();
        dt =Faq.SelectAll();
        if (dt.Rows == null || dt.Rows.Count == 0)
            ddListOperation.Items.Insert(0, "-- Create New --");
        else
        {

            ddListOperation.DataTextField = "Question";
            ddListOperation.DataValueField = "ID";
            ddListOperation.DataSource = dt;
            ddListOperation.DataBind();
            ddListOperation.Items.Insert(0, "-- Create New --");
            btnApprove.Text = "Approve";
            btnSave.Text = "Save";
        }
    }
    catch { }

    }
    private void PopulateFilelds()
    {
        try{
        DataTable dt = new DataTable();
        string strqur = ddListOperation.SelectedValue.ToString();
        lblMessage.Text = "";

        if (strqur.Equals("-- Create New --"))
        {
            clear();
            btnSave.Text = "Save";
            btnApprove.Text = "Approve";
        }
        else if (short.Parse(strqur) > 0)
        {
            short pageId = short.Parse(strqur);
       
            dt = Faq.SelectByPK(int.Parse(strqur));
            if (dt != null)
            {
                btnSave.Text = "Update";
                lblStatus.Visible = true;
                lblSta.Visible = true;
            }
            if (dt.Rows[0]["Publish"].ToString() == "D")
            {
                lblStatus.Text = "Draft";
                btnApprove.Text = "Approve";
            }
            else if (dt.Rows[0]["Publish"].ToString() == "P")
            {
                lblStatus.Text = "Published";
                btnApprove.Text = "Suspend";
            }
            else if (dt.Rows[0]["Publish"].ToString() == "X")
            {
                lblStatus.Text = "Archive";
                btnApprove.Text = "Approve";
            }
            else if (dt.Rows[0]["Publish"].ToString() == "S")
            {
                lblStatus.Text = "Suspended";
                btnApprove.Text = "Approve";
            }
            txtQuestion.Text = dt.Rows[0]["Question"].ToString();
            txtAnswer.Text = dt.Rows[0]["Answer"].ToString();
        }
    }
    catch { }
    }
    private void clear()
    {

        txtQuestion.Text = "";
        ddListOperation.SelectedIndex = 0;
        lblStatus.Visible = false;
        txtAnswer.Text = "";
        btnSave.Text = "Save";
        btnApprove.Text = "Approve";
        lblSta.Visible = false;
    }
    private void Save()
    {
        try {
        string id;
        string sql;

        if (ddListOperation.SelectedValue == "-- Create New --")
        {
            id = id = Sanoy.AddisTower.DA.Utility.GetId("Faq", "Id").ToString(); ;
            if (id == "")
                id = "1";
            sql = "INSERT INTO Faq  (ID,Question,Answer,Publish)" +
                        "VALUES (" + id + ",'" + txtQuestion.Text + "','" + txtAnswer.Text + "','D')";
            if(Faq.Insert(int.Parse(id),txtQuestion.Text ,txtAnswer.Text,"D"))
                lblMessage.Text = "The content was succesfully saved.";
            else
                lblMessage.Text = "There was problem saving the content.";
        }
        else
        {
            id = ddListOperation.SelectedValue;
            if (Faq.Update(int.Parse(id), txtQuestion.Text, txtAnswer.Text))
                lblMessage.Text = "The content was succesfully saved.";
            else
                lblMessage.Text = "There was problem saving the content.";
        }
       
        Populate();
    }
    catch { }

    }
    private void Delete(string entry)
    {
        try{
        if (entry == "")
        {
            lblMessage.Text = "Select a Title.";
            return;
        }


        if (Faq.Delete(Convert.ToInt32(entry)))
            lblMessage.Text = "The content was succesfully Deleted.";
        else
            lblMessage.Text = "There was problem Deleting the content.";
    }
    catch { }
    }
    private void Approve(string entry)
    {
      try {
        bool publish;
        publish = btnApprove.Text.Equals("Approve") ? true : false;
        if (publish)
        {
         
            if (Faq.ChangeStatus(Convert.ToInt32(entry),"P"))
                lblMessage.Text = "The content was succesfully published.";
            else
                lblMessage.Text = "There was problem publishing the content.";
        }
        else
        {
            if (Faq.ChangeStatus(Convert.ToInt32(entry), "X"))
                lblMessage.Text = "The content was succesfully Suspended.";
            else
                lblMessage.Text = "There was problem Suspending the content.";
        }
    }
    catch { }
    }

    #endregion

   
}
