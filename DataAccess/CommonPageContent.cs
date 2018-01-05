using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;

namespace Sanoy.AddisTower.DA
{
    public class CommonPageContent
	{
        #region Manually Written Methods

        #endregion

        #region Auto Generated Methods

        public static BE.CommonPageContent Select(Int32 Id)
        {
            BE.CommonPageContent commonPageContent = new BE.CommonPageContent();
            string SQLQuery = "SELECT * FROM [CommonPageContent] WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = SQLHelper.ExecuteReader(command);
            reader.Read();

            commonPageContent.Id = Convert.ToInt32(reader["Id"]);
            commonPageContent.CommonPage = Convert.ToInt32(reader["CommonPage"]);
            commonPageContent.Title = Convert.ToString(reader["Title"]);
            commonPageContent.Content = Convert.ToString(reader["Content"]);
            commonPageContent.Created = Convert.ToDateTime(reader["Created"]);
            commonPageContent.CreatedBy = Convert.ToString(reader["CreatedBy"]);
            commonPageContent.Edited = Convert.ToDateTime(reader["Edited"]);
            commonPageContent.EditedBy = Convert.ToString(reader["EditedBy"]);
            commonPageContent.Publish = Convert.ToString(reader["Publish"]);

            reader.Close();
            reader.Dispose();
            return commonPageContent;
        }
        public static BE.CommonPageContent SelectApproved(Int32 Id)
        {
            BE.CommonPageContent commonPageContent = new BE.CommonPageContent();
            string SQLQuery = "SELECT * FROM [CommonPageContent] WHERE [CommonPage]=@Id  And Publish=@Publish";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Publish", "P");

            SqlDataReader reader = SQLHelper.ExecuteReader(command);
            reader.Read();

            commonPageContent.Id = Convert.ToInt32(reader["Id"]);
            commonPageContent.CommonPage = Convert.ToInt32(reader["CommonPage"]);
            commonPageContent.Title = Convert.ToString(reader["Title"]);
            commonPageContent.Content = Convert.ToString(reader["Content"]);
            commonPageContent.Created = Convert.ToDateTime(reader["Created"]);
            commonPageContent.CreatedBy = Convert.ToString(reader["CreatedBy"]);
            commonPageContent.Edited = Convert.ToDateTime(reader["Edited"]);
            commonPageContent.EditedBy = Convert.ToString(reader["EditedBy"]);
            commonPageContent.Publish = Convert.ToString(reader["Publish"]);

            reader.Close();
            reader.Dispose();
            return commonPageContent;
        }

        public static BE.CommonPageContent[] SelectAll(string CommonPage)
        {
            ArrayList commonPageContents = new ArrayList();
            BE.CommonPageContent commonPageContent;
            string SQLQuery = "SELECT * FROM [CommonPageContent] where CommonPage=@CommonPage  ";
            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@CommonPage", CommonPage);
            SqlDataReader reader = SQLHelper.ExecuteReader(command);

            while (reader.Read())
            {
                commonPageContent = new BE.CommonPageContent();

                commonPageContent.Id = Convert.ToInt32(reader["Id"]);
                commonPageContent.CommonPage = Convert.ToInt32(reader["CommonPage"]);
                commonPageContent.Title = Convert.ToString(reader["Title"]);
                commonPageContent.Content = Convert.ToString(reader["Content"]);
                commonPageContent.Created = Convert.ToDateTime(reader["Created"]);
                commonPageContent.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                commonPageContent.Edited = Convert.ToDateTime(reader["Edited"]);
                commonPageContent.EditedBy = Convert.ToString(reader["EditedBy"]);
                commonPageContent.Publish = Convert.ToString(reader["Publish"]);
                commonPageContents.Add(commonPageContent);
            }


            reader.Close();
            reader.Dispose();
            return (BE.CommonPageContent[])commonPageContents.ToArray(typeof(BE.CommonPageContent));
        }

        public static void Save(BE.CommonPageContent[] commonPageContents)
        {
            foreach (BE.CommonPageContent commonPageContent in commonPageContents)
            {
                if (commonPageContent.State == BE.RowState.Added)
                    Insert(commonPageContent);
                else if (commonPageContent.State == BE.RowState.Modified)
                    Update(commonPageContent);
                else if (commonPageContent.State == BE.RowState.Deleted)
                    Delete(commonPageContent.Id);
            }
        }

        public static bool Save(BE.CommonPageContent commonPageContent)
        {

            bool IsAffected = false;
            if (commonPageContent.State == BE.RowState.Added)
                IsAffected = Insert(commonPageContent);
            else if (commonPageContent.State == BE.RowState.Modified)
                IsAffected = Update(commonPageContent);
            else if (commonPageContent.State == BE.RowState.Deleted)
                IsAffected = Delete(commonPageContent.Id);
            return IsAffected;
        }

        public static bool Insert(Int32 id, Int32 commonPage, String title, String content, DateTime created, String createdBy, DateTime edited, String editedBy, String publish)
        {
            string SQLQuery = "INSERT INTO [CommonPageContent] ( id,commonPage,title,content,created,createdBy,edited,editedBy,publish ) VALUES	(@id, @commonPage, @title, @content, @created, @createdBy, @edited, @editedBy, @publish)";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, id, commonPage, title, content, created, createdBy, edited, editedBy, publish);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static bool Insert(BE.CommonPageContent commonPageContent)
        {
            string SQLQuery = "INSERT INTO [CommonPageContent] ( id,commonPage,title,content,created,createdBy,edited,editedBy,publish ) VALUES	(@id, @commonPage, @title, @content, @created, @createdBy, @edited, @editedBy, @publish)";
            commonPageContent.Id = Utility.GetId("CommonPageContent", "Id");
            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, commonPageContent);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static void Insert(BE.CommonPageContent[] commonPageContents)
        {
            foreach (BE.CommonPageContent commonPageContent in commonPageContents)
            {
                Insert(commonPageContent);
            }
        }

        public static void Update(BE.CommonPageContent[] commonPageContents)
        {
            foreach (BE.CommonPageContent commonPageContent in commonPageContents)
                Update(commonPageContent);
        }

        public static bool Update(BE.CommonPageContent commonPageContent)
        {
            string SQLQuery = "UPDATE [CommonPageContent] SET Id = @Id, CommonPage= @CommonPage, Title= @Title, Content= @Content, Created= @Created, CreatedBy= @CreatedBy, Edited= @Edited, EditedBy= @EditedBy, Publish= @Publish WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, commonPageContent);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static bool Update(Int32 id, Int32 commonPage, String title, String content, DateTime created, String createdBy, DateTime edited, String editedBy, String publish)
        {
            string SQLQuery = "UPDATE [CommonPageContent] SET Id = @Id, CommonPage= @CommonPage, Title= @Title, Content= @Content, Created= @Created, CreatedBy= @CreatedBy, Edited= @Edited, EditedBy= @EditedBy, Publish= @Publish WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, id, commonPage, title, content, created, createdBy, edited, editedBy, publish);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static bool Delete(Int32 id)
        {
            string SQLQuery = "DELETE FROM [CommonPageContent] WHERE [Id]=@Id ";
            SqlCommand command = new SqlCommand();

            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Id", id);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }
        public static bool ChangeStatus(int Id, string str)
        {
            string SQLQuery = "UPDATE [CommonPageContent] SET Publish=@str where Id=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@str", SqlDbType.NVarChar).Value = str;


            return SQLHelper.ExecuteNonQuery(command);
        }
        public static bool SuspendContent(int CommonPage)
        {
            string SQLQuery = "UPDATE CommonPageContent SET Publish=@Suspend  where  Publish=@Publish AND CommonPage=@CommonPage ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@CommonPage", SqlDbType.TinyInt).Value = CommonPage;
            command.Parameters.Add("@Suspend", SqlDbType.Char).Value = "X";
            command.Parameters.Add("@Publish", SqlDbType.VarChar).Value = "P";

            return SQLHelper.ExecuteNonQuery(command);
        }
        private static void AddParameters(SqlCommand command, BE.CommonPageContent commonPageContent)
        {
            command.Parameters.AddWithValue("@Id", commonPageContent.Id);
            command.Parameters.AddWithValue("@CommonPage", commonPageContent.CommonPage);
            command.Parameters.AddWithValue("@Title", commonPageContent.Title);
            command.Parameters.AddWithValue("@Content", commonPageContent.Content);
            command.Parameters.AddWithValue("@Created", commonPageContent.Created);
            command.Parameters.AddWithValue("@CreatedBy", commonPageContent.CreatedBy);
            command.Parameters.AddWithValue("@Edited", commonPageContent.Edited);
            command.Parameters.AddWithValue("@EditedBy", commonPageContent.EditedBy);
            command.Parameters.AddWithValue("@Publish", commonPageContent.Publish);
        }

        private static void AddParameters(SqlCommand command, Int32 id, Int32 commonPage, String title, String content, DateTime created, String createdBy, DateTime edited, String editedBy, String publish)
        {
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@CommonPage", commonPage);
            command.Parameters.AddWithValue("@Title", title);
            command.Parameters.AddWithValue("@Content", content);
            command.Parameters.AddWithValue("@Created", created);
            command.Parameters.AddWithValue("@CreatedBy", createdBy);
            command.Parameters.AddWithValue("@Edited", edited);
            command.Parameters.AddWithValue("@EditedBy", editedBy);
            command.Parameters.AddWithValue("@Publish", publish);
        }
        #endregion
	}
}