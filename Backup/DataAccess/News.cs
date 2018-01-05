using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Sanoy.AddisTower.DA;


namespace Sanoy.AddisTower.DA
{
  public  class News
    {

        public static DataTable SelectAll()
        {
            string SQLQuery = "Select Id,Title from News ";
            SqlCommand command = new SqlCommand(SQLQuery);
            DataTable dt = SQLHelper.ExecuteDataTable(command);
            

            return dt;
        }
        public static DataTable SelectByPK(int Id)
        {
            string SQLQuery = "Select * " +
                               " from News WHERE ID=@Id";
            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.BigInt).Value = Id;
            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
        public static bool Insert(int Id, string Title, string HomePageSummary, DateTime Created, string Creator, string Body, string ShowOnHomePage, string Publish, DateTime AutoExpire, string Language)
        {

            string SQLQuery = "INSERT INTO News (ID,Title,HomePageSummary,Created,Creator,Body,ShowOnHomePage,Publish";
            SQLQuery += ",AutoExpire";
            SQLQuery += ")" +
            " VALUES (@Id,@Title,@HomePageSummary,@Created,@Creator" +
            ",@Body,@ShowOnHomePage,@Publish";
            SQLQuery += ",@AutoExpire";
            SQLQuery += ")";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Title;
            command.Parameters.Add("@HomePageSummary", SqlDbType.NVarChar).Value = HomePageSummary;
            command.Parameters.Add("@Created", SqlDbType.DateTime).Value = Created;
            command.Parameters.Add("@Creator", SqlDbType.VarChar).Value = Creator;
            command.Parameters.Add("@Body", SqlDbType.NText).Value = Body;
            command.Parameters.Add("@ShowOnHomePage", SqlDbType.Char).Value = ShowOnHomePage;
            command.Parameters.Add("@Publish", SqlDbType.Char).Value = Publish;
            command.Parameters.Add("@AutoExpire", SqlDbType.DateTime).Value = AutoExpire;
           

            return  SQLHelper.ExecuteNonQuery(command);
           
        }
        public static bool Update(int Id, string Title, string HomePageSummary, DateTime Edited, string Editor, string Body, string ShowOnHomePage, DateTime AutoExpire)
        {


            string SQLQuery = "UPDATE News SET  Title =@Title, HomePageSummary =@HomePageSummary, ShowOnHomePage =@ShowOnHomePage, Body =@Body, Edited=@Edited, Editor=@Editor";
            SQLQuery += ",AutoExpire=@AutoExpire ";
            SQLQuery += "where Id=@Id";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Title;
            command.Parameters.Add("@HomePageSummary", SqlDbType.NVarChar).Value = HomePageSummary;
            command.Parameters.Add("@Edited", SqlDbType.DateTime).Value = Edited;
            command.Parameters.Add("@Editor", SqlDbType.VarChar).Value = Editor;
            command.Parameters.Add("@Body", SqlDbType.NText).Value = Body;
            command.Parameters.Add("@ShowOnHomePage", SqlDbType.Char).Value = ShowOnHomePage;
            command.Parameters.Add("@AutoExpire", SqlDbType.DateTime).Value = AutoExpire;


            return SQLHelper.ExecuteNonQuery(command);
            
        }
        public static bool ChangeStatus(int Id, string str)
        {
            string SQLQuery = "UPDATE [News] SET [Publish]=@str WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@str", SqlDbType.NVarChar).Value = str;


            return SQLHelper.ExecuteNonQuery(command);
           
        }
        public static bool Delete(int Id)
        {
            string SQLQuery = "DELETE FROM [News] WHERE [Id]=@Id ";


            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

            return SQLHelper.ExecuteNonQuery(command);
            
        }
        public static DataTable ShowNews()
        {
            string SQLQuery = "SELECT  Id, Title,HomePageSummary FROM News WHERE Publish=@Publish AND AutoExpire >@AutoExpire  ORDER BY Created DESC";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Publish", SqlDbType.Char).Value = "P";
            command.Parameters.Add("@AutoExpire", SqlDbType.DateTime).Value = DateTime.Now;
           

            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
        public static DataTable ShowLatestNews()
        {
            string SQLQuery = "SELECT  Top 2 Id, Title,HomePageSummary FROM News WHERE Publish=@Publish AND AutoExpire >@AutoExpire AND  ShowOnHomePage=@Show ORDER BY Created DESC";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Publish", SqlDbType.Char).Value = "P";
            command.Parameters.Add("@Show", SqlDbType.Char).Value = "Y";
            command.Parameters.Add("@AutoExpire", SqlDbType.DateTime).Value = DateTime.Now;


            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
        public static DataTable ShowDetail(int Id)
        {
            string SQLQuery = "SELECT Title, Body FROM News WHERE Publish=@Publish  AND Id =@Id";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@Publish", SqlDbType.VarChar).Value = "P";
            DataTable dt =  SQLHelper.ExecuteDataTable(command);
            return dt;
        }

    }
}
