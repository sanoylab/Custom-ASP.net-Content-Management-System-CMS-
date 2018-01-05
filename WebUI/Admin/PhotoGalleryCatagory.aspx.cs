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
public partial class MFA_WebAdmin_PhotoGalleryCatagory : System.Web.UI.Page
{
    #region mem vars
    private string sql, title = "";
    private string strqur;
    static private string Status;
    static private int Id;
    #endregion


    #region event handlers
    protected void Page_Load(object sender, EventArgs e)
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
        cleartextbox();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Delete(ddListOperation.SelectedValue);
        Populate();
        ddListOperation.Items[0].Selected = true;
        cleartextbox();

    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        Approve(ddListOperation.SelectedValue.ToString());
        Populate();
        ddListOperation.Items[0].Selected = true;
        cleartextbox();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        cleartextbox();
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
            lblUser.Text = Session["UserName"].ToString() + " @ Picture Catagory";
            if (Session["User"] != null)
            {
                ddListOperation.Enabled = btnApprove.Enabled = btnDelete.Enabled = btnSave.Enabled = ((AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.ManageNews, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session)));

               
                Populate();
            }
            else
                Response.Redirect("Default.aspx");
        }
        catch { }


    }
   
    protected void Populate()
    {
        try
        {

            Sanoy.AddisTower.BE.PhotoGalleryCatagory[] catagory = Sanoy.AddisTower.DA.PhotoGalleryCatagory.SelectAll();
            ddListOperation.Items.Clear();
            if (catagory == null || catagory.Length == 0)
                ddListOperation.Items.Insert(0, "-- Create New --");
            else
            {

                ddListOperation.DataTextField = Sanoy.AddisTower.BE.PhotoGalleryCatagory.FIELD_CatagoryName;
                ddListOperation.DataValueField = Sanoy.AddisTower.BE.PhotoGalleryCatagory.FIELD_Id;
                ddListOperation.DataSource = catagory;
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
        try
        {
          
            string strqur = ddListOperation.SelectedValue.ToString();
            lblMessage.Text = "";

            if (strqur.Equals("-- Create New --"))
            {
                cleartextbox();
                btnSave.Text = "Save";
                btnApprove.Text = "Approve";
            }
            else if (short.Parse(strqur) > 0)
            {
                short pageId = short.Parse(strqur);
                Sanoy.AddisTower.BE.PhotoGalleryCatagory catagory = Sanoy.AddisTower.DA.PhotoGalleryCatagory.Select(int.Parse(strqur));

                if (catagory != null)
                {

                    panStatus.Visible = true;
                    btnSave.Text = "Update";

                }
                if (catagory.Publish == "D")
                {
                    lblStatus.Text = "Draft"; 
                    btnApprove.Text = "Approve";
                }
                else if (catagory.Publish == "P")
                {
                    lblStatus.Text = "Published";
                    btnApprove.Text = "Suspend";
                }
                else if (catagory.Publish == "X")
                {
                    lblStatus.Text = "Archive";
                    btnApprove.Text = "Approve";
                }
                else if (catagory.Publish == "S")
                {
                    lblStatus.Text = "Suspended";
                    btnApprove.Text = "Approve";
                }

                txtHeadLine.Text = catagory.CatagoryName;
                Status = catagory.Publish;
                Id = catagory.Id;
               
             
            }
        }
        catch { }
    }
    private void Save()
    {
        try
        {
            string id;
            Sanoy.AddisTower.BE.PhotoGalleryCatagory catagory = new Sanoy.AddisTower.BE.PhotoGalleryCatagory();
            catagory.CatagoryName = txtHeadLine.Text;
            

            if (ddListOperation.SelectedValue == "-- Create New --")
            {
               
                catagory.Id = Sanoy.AddisTower.DA.Utility.GetId("PhotoGalleryCatagory", "Id");
                catagory.State = Sanoy.AddisTower.BE.RowState.Added;
                catagory.Publish = "D";
               

            }
            else
            {
                catagory.State = Sanoy.AddisTower.BE.RowState.Modified;
                catagory.Id = Id;
                catagory.Publish = Status;
            }
            if (Sanoy.AddisTower.DA.PhotoGalleryCatagory.Save(catagory))
                lblMessage.Text = "The content was succesfully saved.";
            else
                lblMessage.Text = "The content was not succesfully saved.";
            Populate();
        }
        catch (Exception ex)

        { }

    }
    private void Approve(string entry)
    {
        try
        {
            bool publish;
            publish = btnApprove.Text.Equals("Approve") ? true : false;
            if (publish)
            {
               
                if (Sanoy.AddisTower.DA.PhotoGalleryCatagory.ChangeStatus(Convert.ToInt32(entry), "P"))
                    lblMessage.Text = "The content was succesfully published.";
                else
                    lblMessage.Text = "There was problem publishing the content.";
            }
            else
            {
                if (Sanoy.AddisTower.DA.PhotoGalleryCatagory.ChangeStatus(Convert.ToInt32(entry), "X"))
                    lblMessage.Text = "The content was succesfully Suspended.";
                else
                    lblMessage.Text = "There was problem Suspending the content.";
            }
        }
        catch { }
    }
    private void Delete(string entry)
    {
        try
        {
            if (entry == "")
            {
                lblMessage.Text = "Select a Title.";
                return;
            }


            if (Sanoy.AddisTower.DA.PhotoGalleryCatagory.ChangeStatus(Convert.ToInt32(entry), "Q"))
                lblMessage.Text = "The content was succesfully Deleted.";
            else
                lblMessage.Text = "There was problem Deleting the content.";
        }
        catch { }
    }
    protected void cleartextbox()
    {
      
        txtHeadLine.Text = "";
        ddListOperation.SelectedIndex = 0;
        panStatus.Visible = false;
       


    }
    #endregion
}
