using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;

namespace Sanoy.AddisTower.DA
{
    public class FeedBack
	{
        #region Manually Written Methods

        #endregion
        
        #region Auto Generated Methods

        public static BE.FeedBack Select(Int32 Id)
        {
            BE.FeedBack feedBack = new BE.FeedBack();
            string SQLQuery = "SELECT * FROM [FeedBack] WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = SQLHelper.ExecuteReader(command);
            reader.Read();

            feedBack.FirstName = Convert.ToString(reader["FirstName"]);
            feedBack.LastName = Convert.ToString(reader["LastName"]);
            feedBack.Email = Convert.ToString(reader["Email"]);
            feedBack.Subject = Convert.ToString(reader["Subject"]);
            feedBack.Comment = Convert.ToString(reader["Comment"]);
            feedBack.Status = Convert.ToString(reader["Status"]);

            reader.Close();
            reader.Dispose();
            return feedBack;
        }
        public static DataTable GetDetailFeedback(string Email)
        {

            string SQLQuery = "SELECT * FROM [FeedBack] WHERE Email= @Email";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Email", Email);

            return SQLHelper.ExecuteDataTable(command);
        }


        public static BE.FeedBack[] SelectAll()
        {
            ArrayList feedBacks = new ArrayList();
            BE.FeedBack feedBack;
	    string SQLQuery = "SELECT * FROM [FeedBack]  ";
           SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            SqlDataReader reader = SQLHelper.ExecuteReader(command);

            while (reader.Read())
            {
                feedBack = new BE.FeedBack();

                feedBack.FirstName = Convert.ToString(reader["FirstName"]);
            feedBack.LastName = Convert.ToString(reader["LastName"]);
            feedBack.Email = Convert.ToString(reader["Email"]);
            feedBack.Subject = Convert.ToString(reader["Subject"]);
            feedBack.Comment = Convert.ToString(reader["Comment"]);
            feedBack.Status = Convert.ToString(reader["Status"]);
                feedBacks.Add(feedBack);
            }

          
 	    reader.Close();
            reader.Dispose();
            return (BE.FeedBack[])feedBacks.ToArray(typeof(BE.FeedBack));
        }

		public static void Save(BE.FeedBack[] feedBacks)
        {
            foreach (BE.FeedBack feedBack in feedBacks)
            {
                if (feedBack.State == BE.RowState.Added)
                    Insert(feedBack);
                else if (feedBack.State == BE.RowState.Modified)
                    Update(feedBack);
                else if (feedBack.State == BE.RowState.Deleted)
                    Delete(feedBack.Email);
            }
        }
        public static DataTable GetFeedback()
        {
            string SQLQuery = "SELECT * FROM [FeedBack]";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;


            return SQLHelper.ExecuteDataTable(command);
        }
        public static bool Save(BE.FeedBack feedBack)
        {
		
		bool IsAffected= false;
            if (feedBack.State == BE.RowState.Added)
              IsAffected=  Insert(feedBack);
            else if (feedBack.State == BE.RowState.Modified)
               IsAffected=  Update(feedBack);
            else if (feedBack.State == BE.RowState.Deleted)
              IsAffected=   Delete(feedBack.Email);
		return 	IsAffected;
        }

        public static bool Insert(String firstName,String lastName,String email,String subject,String comment,String status)
		{
			string SQLQuery="INSERT INTO [FeedBack] ( firstName,lastName,email,subject,comment,status ) VALUES	(@firstName, @lastName, @email, @subject, @comment, @status)";

			SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, firstName,lastName,email,subject,comment,status);
			
			return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
		}
        public static DataTable GetRegisteredFeedbacks(string Status)
        {
            string SQLQuery = "SELECT * FROM [FeedBack] WHERE Status= @Status";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Status", Status);

            return SQLHelper.ExecuteDataTable(command);
        }

        public static bool IsExist(string Email)
        {
            string SQLQuery =
          "SELECT * FROM FeedBack WHERE Email=@Email ";
            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
            DataTable dt = SQLHelper.ExecuteDataTable(command);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static bool Insert(BE.FeedBack feedBack)
        {
            string SQLQuery = "INSERT INTO [FeedBack] ( firstName,lastName,email,subject,comment,status ) VALUES	(@firstName, @lastName, @email, @subject, @comment, @status)";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, feedBack);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static void Insert(BE.FeedBack[] feedBacks)
		{
            foreach(BE.FeedBack feedBack in feedBacks)
            {
                Insert(feedBack);
			}
		}

		public static void Update(BE.FeedBack[] feedBacks)
		{
            foreach (BE.FeedBack feedBack in feedBacks)
                Update(feedBack);
		}

        public static bool Update(BE.FeedBack feedBack)
        {
            string SQLQuery = "UPDATE [FeedBack] SET FirstName = @FirstName, LastName= @LastName, Email= @Email, Subject= @Subject, Comment= @Comment, Status= @Status WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, feedBack);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static bool Update(String firstName,String lastName,String email,String subject,String comment,String status)
        {
            string SQLQuery = "UPDATE [FeedBack] SET FirstName = @FirstName, LastName= @LastName, Email= @Email, Subject= @Subject, Comment= @Comment, Status= @Status WHERE [Email]=@Email ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, firstName,lastName,email,subject,comment,status);

            return Convert.ToBoolean( SQLHelper.ExecuteNonQuery(command));
        }

		public static bool Delete(string email)
		{
			string SQLQuery = "DELETE FROM [FeedBack] WHERE [Email]=@Email ";
			SqlCommand command=new SqlCommand();

            command.CommandText = SQLQuery;
			command.Parameters.AddWithValue("@Email",email);

			return Convert.ToBoolean( SQLHelper.ExecuteNonQuery(command));
		}
        public static bool DeleteFeedback(Int32 id)
        {
            string SQLQuery = "DELETE FROM [FeedBack] WHERE [Id]=@Id ";
            SqlCommand command = new SqlCommand();

            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Id", id);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }
        private static void AddParameters(SqlCommand command, BE.FeedBack feedBack)
        {
			command.Parameters.AddWithValue("@FirstName", feedBack.FirstName);
            command.Parameters.AddWithValue("@LastName", feedBack.LastName);
            command.Parameters.AddWithValue("@Email", feedBack.Email);
            command.Parameters.AddWithValue("@Subject", feedBack.Subject);
            command.Parameters.AddWithValue("@Comment", feedBack.Comment);
            command.Parameters.AddWithValue("@Status", feedBack.Status);
        }

        private static void AddParameters(SqlCommand command, String firstName,String lastName,String email,String subject,String comment,String status)
        {
			command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Subject", subject);
            command.Parameters.AddWithValue("@Comment", comment);
            command.Parameters.AddWithValue("@Status", status);
        }
        #endregion        
	}
}