using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;

namespace Sanoy.AddisTower.DA
{
    public class PhotoGalleryCatagory
	{
        #region Manually Written Methods

        #endregion
        
        #region Auto Generated Methods

        public static BE.PhotoGalleryCatagory Select(Int32 Id)
        {
            BE.PhotoGalleryCatagory photoGalleryCatagory = new BE.PhotoGalleryCatagory();
            string SQLQuery = "SELECT * FROM [PhotoGalleryCatagory] WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = SQLHelper.ExecuteReader(command);
            reader.Read();

            photoGalleryCatagory.Id = Convert.ToInt32(reader["Id"]);
            photoGalleryCatagory.CatagoryName = Convert.ToString(reader["CatagoryName"]);
            photoGalleryCatagory.Publish = Convert.ToString(reader["Publish"]);

            reader.Close();
            reader.Dispose();
            return photoGalleryCatagory;
        }

        public static BE.PhotoGalleryCatagory[] SelectAll()
        {
            ArrayList photoGalleryCatagorys = new ArrayList();
            BE.PhotoGalleryCatagory photoGalleryCatagory;
            string SQLQuery = "SELECT * FROM [PhotoGalleryCatagory] where Publish <> @Publish ";
           SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Publish", "Q");
            SqlDataReader reader = SQLHelper.ExecuteReader(command);

            while (reader.Read())
            {
                photoGalleryCatagory = new BE.PhotoGalleryCatagory();

                photoGalleryCatagory.Id = Convert.ToInt32(reader["Id"]);
            photoGalleryCatagory.CatagoryName = Convert.ToString(reader["CatagoryName"]);
            photoGalleryCatagory.Publish = Convert.ToString(reader["Publish"]);
                photoGalleryCatagorys.Add(photoGalleryCatagory);
            }

          
 	    reader.Close();
            reader.Dispose();
            return (BE.PhotoGalleryCatagory[])photoGalleryCatagorys.ToArray(typeof(BE.PhotoGalleryCatagory));
        }

        public static BE.PhotoGalleryCatagory[] SelectApproved()
        {
            ArrayList photoGalleryCatagorys = new ArrayList();
            BE.PhotoGalleryCatagory photoGalleryCatagory;
            string SQLQuery = "SELECT * FROM [PhotoGalleryCatagory] where Publish=@Publish ";
            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Publish", "P");
            SqlDataReader reader = SQLHelper.ExecuteReader(command);

            while (reader.Read())
            {
                photoGalleryCatagory = new BE.PhotoGalleryCatagory();

                photoGalleryCatagory.Id = Convert.ToInt32(reader["Id"]);
                photoGalleryCatagory.CatagoryName = Convert.ToString(reader["CatagoryName"]);
                photoGalleryCatagory.Publish = Convert.ToString(reader["Publish"]);
                photoGalleryCatagorys.Add(photoGalleryCatagory);
            }


            reader.Close();
            reader.Dispose();
            return (BE.PhotoGalleryCatagory[])photoGalleryCatagorys.ToArray(typeof(BE.PhotoGalleryCatagory));
        }

		public static void Save(BE.PhotoGalleryCatagory[] photoGalleryCatagorys)
        {
            foreach (BE.PhotoGalleryCatagory photoGalleryCatagory in photoGalleryCatagorys)
            {
                if (photoGalleryCatagory.State == BE.RowState.Added)
                    Insert(photoGalleryCatagory);
                else if (photoGalleryCatagory.State == BE.RowState.Modified)
                    Update(photoGalleryCatagory);
                else if (photoGalleryCatagory.State == BE.RowState.Deleted)
                    Delete(photoGalleryCatagory.Id);
            }
        }

        public static bool Save(BE.PhotoGalleryCatagory photoGalleryCatagory)
        {
		
		bool IsAffected= false;
            if (photoGalleryCatagory.State == BE.RowState.Added)
              IsAffected=  Insert(photoGalleryCatagory);
            else if (photoGalleryCatagory.State == BE.RowState.Modified)
               IsAffected=  Update(photoGalleryCatagory);
            else if (photoGalleryCatagory.State == BE.RowState.Deleted)
              IsAffected=   Delete(photoGalleryCatagory.Id);
		return 	IsAffected;
        }

        public static bool Insert(Int32 id,String catagoryName,String publish)
		{
			string SQLQuery="INSERT INTO [PhotoGalleryCatagory] ( id,catagoryName,publish ) VALUES	(@id, @catagoryName, @publish)";

			SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, id,catagoryName,publish);
			
			return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
		}

        public static bool Insert(BE.PhotoGalleryCatagory photoGalleryCatagory)
        {
            string SQLQuery = "INSERT INTO [PhotoGalleryCatagory] ( id,catagoryName,publish ) VALUES	(@id, @catagoryName, @publish)";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, photoGalleryCatagory);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static void Insert(BE.PhotoGalleryCatagory[] photoGalleryCatagorys)
		{
            foreach(BE.PhotoGalleryCatagory photoGalleryCatagory in photoGalleryCatagorys)
            {
                Insert(photoGalleryCatagory);
			}
		}

		public static void Update(BE.PhotoGalleryCatagory[] photoGalleryCatagorys)
		{
            foreach (BE.PhotoGalleryCatagory photoGalleryCatagory in photoGalleryCatagorys)
                Update(photoGalleryCatagory);
		}

        public static bool Update(BE.PhotoGalleryCatagory photoGalleryCatagory)
        {
            string SQLQuery = "UPDATE [PhotoGalleryCatagory] SET Id = @Id, CatagoryName= @CatagoryName, Publish= @Publish WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, photoGalleryCatagory);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static bool Update(Int32 id,String catagoryName,String publish)
        {
            string SQLQuery = "UPDATE [PhotoGalleryCatagory] SET Id = @Id, CatagoryName= @CatagoryName, Publish= @Publish WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, id,catagoryName,publish);

            return Convert.ToBoolean( SQLHelper.ExecuteNonQuery(command));
        }

		public static bool Delete(Int32 id)
		{
			string SQLQuery = "DELETE FROM [PhotoGalleryCatagory] WHERE [Id]=@Id ";
			SqlCommand command=new SqlCommand();

            command.CommandText = SQLQuery;
			command.Parameters.AddWithValue("@Id",id);

			return Convert.ToBoolean( SQLHelper.ExecuteNonQuery(command));
		}
        public static bool ChangeStatus(int Id, string str)
        {
            string SQLQuery = "UPDATE [PhotoGalleryCatagory] SET [Publish]=@str WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@str", SqlDbType.NVarChar).Value = str;


            return SQLHelper.ExecuteNonQuery(command);

        }

        private static void AddParameters(SqlCommand command, BE.PhotoGalleryCatagory photoGalleryCatagory)
        {
			command.Parameters.AddWithValue("@Id", photoGalleryCatagory.Id);
            command.Parameters.AddWithValue("@CatagoryName", photoGalleryCatagory.CatagoryName);
            command.Parameters.AddWithValue("@Publish", photoGalleryCatagory.Publish);
        }

        private static void AddParameters(SqlCommand command, Int32 id,String catagoryName,String publish)
        {
			command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@CatagoryName", catagoryName);
            command.Parameters.AddWithValue("@Publish", publish);
        }
        #endregion        
	}
}