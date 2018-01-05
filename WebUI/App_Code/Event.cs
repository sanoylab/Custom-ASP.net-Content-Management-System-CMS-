using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.SessionState;
using Sanoy.AddisTower.DA;

/// <summary>
/// Summary description for DT_Event
/// </summary>
namespace Sanoy.AddisTower.DA
{
    public class Event 
    {
        public Event()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static DataTable SelectByTWG(int TWG)
        {
            string SQLQuery = "Select Id,Title" +
                                " from Event WHERE [TWG]=@TWG ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@TWG", SqlDbType.BigInt).Value = TWG;
            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
        public static DataTable SelectByPK(int Id)
        {
            string SQLQuery = "Select Id,Title,Detail,[Date],ShowToPublic,Publish" +
                               " from Event WHERE Id=@Id";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.BigInt).Value = Id;


            DataTable dt = SQLHelper.ExecuteDataTable(command);
            return dt;
        }
        public static DataTable SelectByDate(string Date)
        {
            string SQLQuery = "Select Id,Title, Detail from Event where [Date] = @Date AND Publish=@Publish";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Date", SqlDbType.VarChar).Value = Date;
            command.Parameters.Add("@Publish", SqlDbType.VarChar).Value = "P";

            DataTable dt = SQLHelper.ExecuteDataTable(command);
            return dt;
        }
        public static bool Insert(int Id, string Title, string Detail, int TWG, DateTime EventDate, string ShowToPublic, string Publish)
        {
            string SQLQuery = "INSERT INTO Event  (Id,Title,Detail,TWG,[Date],ShowToPublic,Publish)" +
                            "VALUES (@Id,@Title,@Detail " +
               ",@TWG,@EventDate,@ShowToPublic,@Publish)";
            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.BigInt).Value = Id;
            command.Parameters.Add("@TWG", SqlDbType.TinyInt).Value = TWG;
            command.Parameters.Add("@Title", SqlDbType.VarChar).Value = Title;
            command.Parameters.Add("@Detail", SqlDbType.VarChar).Value = Detail;
            command.Parameters.Add("@ShowToPublic", SqlDbType.VarChar).Value = ShowToPublic;
            command.Parameters.Add("@EventDate", SqlDbType.DateTime).Value = EventDate;
            command.Parameters.Add("@Publish", SqlDbType.Char).Value = Publish;


            return SQLHelper.ExecuteNonQuery(command);
        }
        public static bool Update(int Id, string Title, string Detail, DateTime EventDate, string ShowToPublic)
        {
            string SQLQuery = "UPDATE Event SET " +
                "Title = @Title,Detail=@Detail,[Date]=@EventDate,ShowToPublic=@ShowToPublic" +
                      " where Id=@Id";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.BigInt).Value = Id;
            command.Parameters.Add("@Title", SqlDbType.VarChar).Value = Title;
            command.Parameters.Add("@Detail", SqlDbType.VarChar).Value = Detail;
            command.Parameters.Add("@ShowToPublic", SqlDbType.VarChar).Value = ShowToPublic;
            command.Parameters.Add("@EventDate", SqlDbType.DateTime).Value = EventDate;


           return  SQLHelper.ExecuteNonQuery(command);
           
             
        }
        public static bool ChangeStatus(int Id, string str)
        {
            string SQLQuery = "UPDATE [Event] SET [Publish]=@str WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@str", SqlDbType.NVarChar).Value = str;


            return SQLHelper.ExecuteNonQuery(command);
        }
        public static bool Delete(int Id)
        {
            string SQLQuery = "DELETE FROM [Event] WHERE [Id]=@Id ";


            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

            return SQLHelper.ExecuteNonQuery(command);
        }
        public static DataTable Show(HttpSessionState session)
        {
            DataTable dt;
            string sql;
            bool IsPublic = false;
            SqlCommand command;
            if (session["User"] != null && session["User"].ToString() != "")
            {
                sql =
                "SELECT RoleMembers.[User], TWG.Id " +
                "FROM   RoleMembers INNER JOIN " +
                        "Roles ON RoleMembers.Role = Roles.ID INNER JOIN " +
                        "TWG ON Roles.Description = TWG.Name " +
                "WHERE  (RoleMembers.[User] = @User) AND (TWG.Id = @TWG)";
                command = new SqlCommand(sql);
                command.Parameters.Add("@TWG", SqlDbType.BigInt).Value = AdminBaseUIPage.CurrentTWG;
                command.Parameters.Add("@User", SqlDbType.VarChar).Value = session["User"].ToString();
                dt = SQLHelper.ExecuteDataTable(command);
                if (dt.Rows.Count > 0)
                    IsPublic = true;

            }
            if (IsPublic == true)
                sql = "SELECT top 3 Id, Title From Event where TWG =@TWG And Publish=@Publish AND [Date] >@Date   ORDER BY [Date] ASC";
            else
                sql = "SELECT top 3 Id, Title From Event where TWG =@TWG And Publish=@Publish AND [Date] >@Date AND ShowToPublic='1' ORDER BY [Date] ASC";
            command = new SqlCommand(sql);
            command.Parameters.Add("@TWG", SqlDbType.BigInt).Value = AdminBaseUIPage.CurrentTWG;
            command.Parameters.Add("@Publish", SqlDbType.Char).Value = "P";
            command.Parameters.Add("@Date", SqlDbType.DateTime).Value = System.DateTime.Now;
            dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
        public static DataTable ShowCalanderEvents(HttpSessionState session)
        {
            DataTable dt;
            string sql;
            bool IsPublic = false;
            SqlCommand command;
            if (session["User"] != null && session["User"].ToString() != "")
            {
                sql =
                "SELECT RoleMembers.[User], TWG.Id " +
                "FROM   RoleMembers INNER JOIN " +
                        "Roles ON RoleMembers.Role = Roles.ID INNER JOIN " +
                        "TWG ON Roles.Description = TWG.Name " +
                "WHERE  (RoleMembers.[User] = @User) AND (TWG.Id = @TWG)";
                command = new SqlCommand(sql);
                command.Parameters.Add("@TWG", SqlDbType.BigInt).Value = AdminBaseUIPage.CurrentTWG;
                command.Parameters.Add("@User", SqlDbType.VarChar).Value = session["User"].ToString();
                dt = SQLHelper.ExecuteDataTable(command);
                if (dt.Rows.Count > 0)
                    IsPublic = true;

            }
            if (IsPublic == true)
                sql = "SELECT  Date From Event where TWG =@TWG  And Publish=@Publish AND [Date] > @Date   ORDER BY [Date] ASC";
            else
                sql = "SELECT  Date From Event where TWG =@TWG  And Publish=@Publish AND [Date] > @Date AND ShowToPublic='1'  ORDER BY [Date] ASC";
            command = new SqlCommand(sql);
            command.Parameters.Add("@TWG", SqlDbType.BigInt).Value = AdminBaseUIPage.CurrentTWG;
            command.Parameters.Add("@Publish", SqlDbType.Char).Value = "P";
            command.Parameters.Add("@Date", SqlDbType.DateTime).Value = System.DateTime.Now;
            dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }

    }
}
