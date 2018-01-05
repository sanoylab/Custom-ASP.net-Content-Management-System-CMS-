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

public partial class admin_UserManager :System.Web.UI.Page
{
    #region mem vars
    private static bool newUser = false;
    #endregion

    #region event handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.ModifyUser, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.DeleteUser, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.AddNewUser, Session)))
                Response.Redirect("AdminDefault.aspx");

            if (!IsPostBack)
            {
                PopulateListUser();
                PopulateGridView();

                if (Session["User"] != null)
                {
                    btnSaveUserProperties.Enabled = (AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.ModifyUser, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session));
                    btnNewUser.Enabled = (AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.AddNewUser, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session));
                    btnDelete.Enabled = (AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.DeleteUser, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session));
                    btnSavePermission.Enabled = (AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.GivePermission, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session));
                }
                else
                {
                    btnSaveUserProperties.Enabled = false;
                    btnNewUser.Enabled = false;
                    btnDelete.Enabled = false;
                }
                btnSavePermission.Enabled = false;
                gvRoleList.Enabled = false;
            }
        }
        catch { }
    }
    protected void lstUserList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        if (lstUserList.SelectedIndex == -1)
            return;
        newUser = false;
        btnSavePermission.Enabled = (AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.GivePermission, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session)); ;
        gvRoleList.Enabled = (AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.GivePermission, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session)); ;
        string user = lstUserList.SelectedValue;
        PopulateUserProperties(user);
        PopulatePermissions(user);
    }
    catch { }
    }
    protected void btnSaveUserProperties_Click(object sender, EventArgs e)
    {
        
        SaveUserProperties();
    }
    protected void btnSavePermission_Click(object sender, EventArgs e)
    {
        SavePermissions();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DeleteUser();
    }
    protected void btnNewUser_Click(object sender, EventArgs e)
    {
        ClearControl();
        btnSavePermission.Enabled = false;
        gvRoleList.Enabled = false;
        lstUserList.ClearSelection();
        newUser = true;
    }
    #endregion

    #region methods
    private void ClearControl()
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtConfirmPassword.Text = "";
        txtFirstName.Text = "";
        txtMiddleName.Text = "";
        txtLastName.Text = "";
    }
    private void PopulateListUser()
    {
        try
        {
            DataTable userDt = Sanoy.AddisTower.DA.SQLHelper.ExecuteDataTable("Select * from Users");

            lstUserList.DataSource = userDt;
            lstUserList.DataValueField = "ID";
            lstUserList.DataTextField = "UserName";
            lstUserList.DataBind();
            lstUserList.Height = userDt.Rows.Count * 20;
        }
        catch { }
    }
    private void PopulateGridView()
    {
        try{
        string sql = "Select * from Roles";
        DataTable dt = Sanoy.AddisTower.DA.SQLHelper.ExecuteDataTable(sql);

        gvRoleList.DataSource = dt;
        gvRoleList.DataBind();
    }
    catch { }
    }

    private void PopulatePermissions(string user)
    {
        try
        {
            lblMsg.Text = "";
            btnDelete.Enabled = (AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.DeleteUser, Session) || AdminBaseUIPage.CheckRole(AdminBaseUIPage.Role.Admin, Session)); ;
            CheckBox chk;
            DataTable userRoles = UserManager.PopulatePermissions(user);

            //reset permision
            foreach (GridViewRow dgi in gvRoleList.Rows)
            {
                ((CheckBox)dgi.FindControl("chkPermit")).Checked = false;
            }
            for (int i = 0; i < userRoles.Rows.Count; i++)
            {
                foreach (GridViewRow dgi in gvRoleList.Rows)
                {
                    chk = (CheckBox)dgi.FindControl("chkPermit");
                    if (short.Parse(gvRoleList.DataKeys[dgi.RowIndex].Value.ToString()) == short.Parse(userRoles.Rows[i]["Role"].ToString()))
                        chk.Checked = true;
                }
            }
        }
        catch { }
    }
    private void PopulateUserProperties(string user)
    {
        try
        {
            DataRow rw = UserManager.SelectByPK(int.Parse(user)).Rows[0];

            if (rw != null)
            {
                txtUserName.Text = rw["UserName"].ToString();
                txtFirstName.Text = rw["FirstName"].ToString();
                txtMiddleName.Text = rw["MiddleName"].ToString();
                txtLastName.Text = rw["LastName"].ToString();
                txtPassword.Text = rw["PassWord"].ToString();
                txtConfirmPassword.Text = txtPassword.Text;
            }
        }
        catch { }
    }
    private bool DeleteRoleMember(string user)
    {
        return Convert.ToBoolean(UserManager.DeleteRollMembers( user ));
    }
    private void InsertRoleMember(string user, string role)
    {
        Convert.ToBoolean(UserManager.InsertRollMembers(user,role));
    }
    private void InsertRoleMember(string user, ArrayList role)
    {
        try
        {
            int count = role.Count;

            for (int i = 0; i < count; i++)
                InsertRoleMember(user, role[i].ToString());
        }
        catch { }
    }
    private void SavePermissions()
    {
        try{
        string user = "";
        ArrayList permitedRoles = new ArrayList();

        user = lstUserList.SelectedValue;

        foreach (GridViewRow dgi in gvRoleList.Rows)
        {
            if (((CheckBox)dgi.FindControl("chkPermit")).Checked)
                permitedRoles.Add(gvRoleList.DataKeys[dgi.RowIndex].Value);
        }
        DeleteRoleMember(user);
        InsertRoleMember(user, permitedRoles);
    }
    catch { }
    }

    private void InsertUserProperties()
    {
        try{
        if (txtUserName.Text == "")
        {
            lblMsg.Text = "User cannot be empty.";
            return;
        }
        if (txtPassword.Text == "")
        {
            lblMsg.Text = "Password cannot be empty.";
            return;
        }
        if (txtPassword.Text != txtConfirmPassword.Text)
        {
            lblMsg.Text = "The password you gave and the confirmation do not match.";
            return;
        }

        bool IsSuccssfullySaved = false;
        IsSuccssfullySaved = UserManager.InserUser(int.Parse(AdminBaseUIPage.GetID("Users")), txtUserName.Text, Utility.ComputeHash(txtPassword.Text), txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, 0);
        if (IsSuccssfullySaved)
        {
            lblMsg.Text = "User Successfully Saved!!!";
            PopulateListUser();
        }
        else
        {
            lblMsg.Text = "User Not saved Please try again!!!";
        }
    }
    catch { }
    }
    private void UpdateUserProperties()
    {
        try{
        if (txtUserName.Text == "")
        {
            lblMsg.Text = "User cannot be empty.";
            return;
        }
        if (txtPassword.Text == "")
        {
            lblMsg.Text = "Password cannot be empty.";
            return;
        }
        if (txtPassword.Text != txtConfirmPassword.Text)
        {
            lblMsg.Text = "The pass word you gave and the confirmation do not match.";
            return;
        }

        bool IsSuccssfullySaved = false;        
        IsSuccssfullySaved = UserManager.UpdateUser(int.Parse(lstUserList.SelectedValue),txtUserName.Text,Utility.ComputeHash(txtPassword.Text),txtFirstName.Text, txtMiddleName.Text,txtLastName.Text);
        if (IsSuccssfullySaved)
        {
            lblMsg.Text = "User Successfully Saved!!!";
            PopulateListUser();
        }
        else
        {
            lblMsg.Text = "User Not saved Please try again!!!";
        }
    }
    catch { }
    }
    private void SaveUserProperties()
    {
        try{
        string user = "";

        if (!newUser)
        {
            user = lstUserList.SelectedValue;
            UpdateUserProperties();

        }
        else
        {
            user = AdminBaseUIPage.GetID("Users");

            InsertUserProperties();
        }
    }
    catch { }
    }
    private void DeleteUser()
    {
        try
        {
            bool issuccessfullyDelete = false;
            short id = short.Parse(lstUserList.SelectedValue);
            issuccessfullyDelete = UserManager.DeleteUser(int.Parse(lstUserList.SelectedValue));

            if (issuccessfullyDelete)
            {
                lblMsg.Text = "User Successfully Deleted!!!";
                PopulateListUser();
                ClearControl();
            }
            else
            {
                lblMsg.Text = "User Not Successsfully Deleted Please Try Again!!!";
            }
        }
        catch { }
    }
    #endregion
}