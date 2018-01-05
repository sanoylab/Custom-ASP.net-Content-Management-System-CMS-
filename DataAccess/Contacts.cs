using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Sanoy.AddisTower.DA
{
   public class Contacts
    {
        public static DataTable SelectContacts()
        {
            string SQLQuery = "Select ID,ContactName from ContactUs ";

            SqlCommand command = new SqlCommand(SQLQuery);
            DataTable dt = SQLHelper.ExecuteDataTable(command);
            return dt;
        }
        public static DataTable SelectApprovedContacts()
        {
            string SQLQuery = "Select * from ContactUs  where (Publish=@Publish) ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Publish", SqlDbType.Char).Value = "P";
            DataTable dt = SQLHelper.ExecuteDataTable(command);

            return dt;
        }
       public static bool Insert(int Id, string Post, string ContactName, string Tel, string Fax, string Email, string Pobox, DateTime Created, string Creator, string Publish, string Language)
        {
            string SQLQuery = "INSERT INTO ContactUs  (ID,Post,ContactName,Tel,Fax,Email,Pobox,Created,Creator,Publish,Language)" +
                             "VALUES (@Id ,@Post,@ContactName,@Tel,@Fax,@Email,@Pobox,@Created,@Creator,@Publish,@Language)";


            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@Post", SqlDbType.NVarChar).Value = Post;
            command.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = ContactName;
            command.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = Tel;
            command.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = Fax;
            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
            command.Parameters.Add("@Pobox", SqlDbType.NVarChar).Value = Pobox;
            command.Parameters.Add("@Created", SqlDbType.DateTime).Value = Created;
            command.Parameters.Add("@Creator", SqlDbType.VarChar).Value = Creator;
            command.Parameters.Add("@Publish", SqlDbType.Char).Value = Publish;
            command.Parameters.Add("@Language", SqlDbType.VarChar).Value = Language;

            return SQLHelper.ExecuteNonQuery(command);
            
        }
       public static bool Update(int Id, string Post, string ContactName, string Tel, string Fax, string Email, string Pobox, DateTime Edited, string Editor, string Language)
        {
            string SQLQuery = "UPDATE ContactUs SET  Post=@Post , ContactName=@ContactName,Pobox=@Pobox, Tel=@Tel, Fax=@Fax, Email=@Email, Edited=@Edited, Editor=@Editor, Language=@Language" +
                       " where Id=@Id";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@Post", SqlDbType.NVarChar).Value = Post;
            command.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = ContactName;
            command.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = Tel;
            command.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = Fax;
            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
            command.Parameters.Add("@Pobox", SqlDbType.NVarChar).Value = Pobox;
            command.Parameters.Add("@Edited", SqlDbType.DateTime).Value = Edited;
            command.Parameters.Add("@Editor", SqlDbType.VarChar).Value = Editor;
            command.Parameters.Add("@Language", SqlDbType.VarChar).Value = Language;


            return SQLHelper.ExecuteNonQuery(command);
            
        }
        public static bool ChangeStatus(int Id, string str)
        {
            string SQLQuery = "UPDATE [ContactUs] SET [Publish]=@str WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@str", SqlDbType.NVarChar).Value = str;


            return SQLHelper.ExecuteNonQuery(command);
            
        }
        public static bool Delete(int Id)
        {
            string SQLQuery = "DELETE FROM [ContactUs] WHERE [Id]=@Id ";


            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

            return SQLHelper.ExecuteNonQuery(command);
            
        }
        public static DataTable SelectContactsByPK(int Id)
        {
            string SQLQuery = "SELECT * " +
                                    "FROM       ContactUs " +
                                           "WHERE     (Id = @pageId )";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@pageId", SqlDbType.Int).Value = Id;


            return SQLHelper.ExecuteDataTable(command);
            
        }
    }
}
