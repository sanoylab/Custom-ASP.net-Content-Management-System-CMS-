using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;

namespace Sanoy.AddisTower.DA
{
    public class Faq
	{
        #region Manually Written Methods

        #endregion
        
        #region Auto Generated Methods

        public static BE.Faq Select(Int32 Id)
        {
            BE.Faq faq = new BE.Faq();
            string SQLQuery = "SELECT * FROM [Faq] WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = SQLHelper.ExecuteReader(command);
            reader.Read();

            faq.ID = Convert.ToInt32(reader["ID"]);
            faq.Question = Convert.ToString(reader["Question"]);
            faq.Answer = Convert.ToString(reader["Answer"]);
            faq.Publish = Convert.ToString(reader["Publish"]);

            reader.Close();
            reader.Dispose();
            return faq;
        }
        public static DataTable SelectAll()
        {
            string SQLQuery = "Select ID,Question " +
                                " from Faq ";

            SqlCommand command = new SqlCommand(SQLQuery);
            return SQLHelper.ExecuteDataTable(command);


        }
        public static DataTable ShowNewsDetail(int Id)
        {
            string sql = "Select  ID, Question, Answer from Faq  where [ID] =@Id ";

            SqlCommand command = new SqlCommand(sql);

            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            return SQLHelper.ExecuteDataTable(command);
        }
        public static DataTable SelectByPK(int Id)
        {
            string SQLQuery = "Select * " +
                               " from Faq WHERE ID=@Id";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.BigInt).Value = Id;
            return SQLHelper.ExecuteDataTable(command);
        }
        public static bool Update(int Id, string Question, string Answer)
        {
            string SQLQuery = "UPDATE Faq SET " +
                "Question = @Question,Answer =@Answer  where ID=@Id";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@Question", SqlDbType.VarChar).Value = Question;
            command.Parameters.Add("@Answer", SqlDbType.Text).Value = Answer;



            return SQLHelper.ExecuteNonQuery(command);

        }
        public static bool ChangeStatus(int Id, string str)
        {
            string SQLQuery = "UPDATE [Faq] SET [Publish]=@str WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@str", SqlDbType.NVarChar).Value = str;


            return SQLHelper.ExecuteNonQuery(command);
        }
        public static DataTable Show(string maxId)
        {
            string sql;
            if (maxId != "")
                sql = "Select  ID, Question, Answer from Faq where Publish=@Publish and Id > @maxId";
            else
                sql = "Select  ID, Question, Answer from Faq where Publish=@Publish";

            SqlCommand command = new SqlCommand(sql);
            if (maxId != "")
                command.Parameters.Add("@maxId", SqlDbType.VarChar).Value = maxId;
            command.Parameters.Add("@Publish", SqlDbType.VarChar).Value = "P";
            return SQLHelper.ExecuteDataTable(command);
        }
     

		public static void Save(BE.Faq[] faqs)
        {
            foreach (BE.Faq faq in faqs)
            {
                if (faq.State == BE.RowState.Added)
                    Insert(faq);
                else if (faq.State == BE.RowState.Modified)
                    Update(faq);
                else if (faq.State == BE.RowState.Deleted)
                    Delete(faq.ID);
            }
        }

        public static bool Save(BE.Faq faq)
        {
		
		bool IsAffected= false;
            if (faq.State == BE.RowState.Added)
              IsAffected=  Insert(faq);
            else if (faq.State == BE.RowState.Modified)
               IsAffected=  Update(faq);
            else if (faq.State == BE.RowState.Deleted)
              IsAffected=   Delete(faq.ID);
		return 	IsAffected;
        }

        public static bool Insert(Int32 iD,String question,String answer,String publish)
		{
			string SQLQuery="INSERT INTO [Faq] ( iD,question,answer,publish ) VALUES	(@iD, @question, @answer, @publish)";

			SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, iD,question,answer,publish);
			
			return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
		}

        public static bool Insert(BE.Faq faq)
        {
            string SQLQuery = "INSERT INTO [Faq] ( iD,question,answer,publish ) VALUES	(@iD, @question, @answer, @publish)";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, faq);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static void Insert(BE.Faq[] faqs)
		{
            foreach(BE.Faq faq in faqs)
            {
                Insert(faq);
			}
		}

		public static void Update(BE.Faq[] faqs)
		{
            foreach (BE.Faq faq in faqs)
                Update(faq);
		}

        public static bool Update(BE.Faq faq)
        {
            string SQLQuery = "UPDATE [Faq] SET ID = @ID, Question= @Question, Answer= @Answer, Publish= @Publish WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, faq);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static bool Update(Int32 iD,String question,String answer,String publish)
        {
            string SQLQuery = "UPDATE [Faq] SET ID = @ID, Question= @Question, Answer= @Answer, Publish= @Publish WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, iD,question,answer,publish);

            return Convert.ToBoolean( SQLHelper.ExecuteNonQuery(command));
        }

		public static bool Delete(Int32 id)
		{
			string SQLQuery = "DELETE FROM [Faq] WHERE [Id]=@Id ";
			SqlCommand command=new SqlCommand();

            command.CommandText = SQLQuery;
			command.Parameters.AddWithValue("@Id",id);

			return Convert.ToBoolean( SQLHelper.ExecuteNonQuery(command));
		}

        private static void AddParameters(SqlCommand command, BE.Faq faq)
        {
			command.Parameters.AddWithValue("@ID", faq.ID);
            command.Parameters.AddWithValue("@Question", faq.Question);
            command.Parameters.AddWithValue("@Answer", faq.Answer);
            command.Parameters.AddWithValue("@Publish", faq.Publish);
        }

        private static void AddParameters(SqlCommand command, Int32 iD,String question,String answer,String publish)
        {
			command.Parameters.AddWithValue("@ID", iD);
            command.Parameters.AddWithValue("@Question", question);
            command.Parameters.AddWithValue("@Answer", answer);
            command.Parameters.AddWithValue("@Publish", publish);
        }
        #endregion        
	}
}