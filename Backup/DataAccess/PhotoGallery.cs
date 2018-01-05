using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;

namespace Sanoy.AddisTower.DA
{
    public class PhotoGallery
	{
        #region Manually Written Methods

        #endregion
        
        #region Auto Generated Methods

        public static BE.PhotoGallery Select(Int32 Id)
        {
            BE.PhotoGallery photoGallery = new BE.PhotoGallery();
            string SQLQuery = "SELECT * FROM [PhotoGallery] WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = SQLHelper.ExecuteReader(command);
            reader.Read();

            photoGallery.Id = Convert.ToInt32(reader["Id"]);
            photoGallery.Title = Convert.ToString(reader["Title"]);
            photoGallery.Thumbnails = Convert.ToString(reader["Thumbnails"]);
            photoGallery.NormalPicture = Convert.ToString(reader["NormalPicture"]);
            photoGallery.Publish = Convert.ToString(reader["Publish"]);
            photoGallery.Catagory = Convert.ToInt32(reader["Catagory"]);

            reader.Close();
            reader.Dispose();
            return photoGallery;
        }
        public static DataTable SelectPublished(string Catagory)
        {
            string SQLQuery = "SELECT * FROM PhotoGallery WHERE Catagory = @Catagory";
            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Catagory", SqlDbType.BigInt).Value =int.Parse(Catagory);
            DataTable dt = SQLHelper.ExecuteDataTable(command);
            return dt;
        }

        public static BE.PhotoGallery[] SelectAll(string Catagory)
        {
            ArrayList photoGallerys = new ArrayList();
            BE.PhotoGallery photoGallery;
            string SQLQuery = "SELECT * FROM [PhotoGallery] where   Catagory= @Catagory";
           SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;
            command.Parameters.AddWithValue("@Catagory", Catagory);
            SqlDataReader reader = SQLHelper.ExecuteReader(command);

            while (reader.Read())
            {
                photoGallery = new BE.PhotoGallery();

                photoGallery.Id = Convert.ToInt32(reader["Id"]);
            photoGallery.Title = Convert.ToString(reader["Title"]);
            photoGallery.Thumbnails = Convert.ToString(reader["Thumbnails"]);
            photoGallery.NormalPicture = Convert.ToString(reader["NormalPicture"]);
            photoGallery.Publish = Convert.ToString(reader["Publish"]);
            photoGallery.Catagory = Convert.ToInt32(reader["Catagory"]);
                photoGallerys.Add(photoGallery);
            }

          
 	    reader.Close();
            reader.Dispose();
            return (BE.PhotoGallery[])photoGallerys.ToArray(typeof(BE.PhotoGallery));
        }

		public static void Save(BE.PhotoGallery[] photoGallerys)
        {
            foreach (BE.PhotoGallery photoGallery in photoGallerys)
            {
                if (photoGallery.State == BE.RowState.Added)
                    Insert(photoGallery);
                else if (photoGallery.State == BE.RowState.Modified)
                    Update(photoGallery);
                else if (photoGallery.State == BE.RowState.Deleted)
                    Delete(photoGallery.Id);
            }
        }

        public static bool Save(BE.PhotoGallery photoGallery)
        {
		
		bool IsAffected= false;
            if (photoGallery.State == BE.RowState.Added)
              IsAffected=  Insert(photoGallery);
            else if (photoGallery.State == BE.RowState.Modified)
               IsAffected=  Update(photoGallery);
            else if (photoGallery.State == BE.RowState.Deleted)
              IsAffected=   Delete(photoGallery.Id);
		return 	IsAffected;
        }

        public static bool Insert(Int32 id,String title,String thumbnails,String normalPicture,String publish,Int32 catagory)
		{
			string SQLQuery="INSERT INTO [PhotoGallery] ( id,title,thumbnails,normalPicture,publish,catagory ) VALUES	(@id, @title, @thumbnails, @normalPicture, @publish, @catagory)";

			SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, id,title,thumbnails,normalPicture,publish,catagory);
			
			return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
		}

        public static bool Insert(BE.PhotoGallery photoGallery)
        {
            string SQLQuery = "INSERT INTO [PhotoGallery] ( id,title,thumbnails,normalPicture,publish,catagory ) VALUES	(@id, @title, @thumbnails, @normalPicture, @publish, @catagory)";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, photoGallery);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static void Insert(BE.PhotoGallery[] photoGallerys)
		{
            foreach(BE.PhotoGallery photoGallery in photoGallerys)
            {
                Insert(photoGallery);
			}
		}

		public static void Update(BE.PhotoGallery[] photoGallerys)
		{
            foreach (BE.PhotoGallery photoGallery in photoGallerys)
                Update(photoGallery);
		}

        public static bool Update(BE.PhotoGallery photoGallery)
        {
            string SQLQuery = "UPDATE [PhotoGallery] SET Id = @Id, Title= @Title, Thumbnails= @Thumbnails, NormalPicture= @NormalPicture, Publish= @Publish, Catagory= @Catagory WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, photoGallery);

            return Convert.ToBoolean(SQLHelper.ExecuteNonQuery(command));
        }

        public static bool Update(Int32 id,String title,String thumbnails,String normalPicture,String publish,Int32 catagory)
        {
            string SQLQuery = "UPDATE [PhotoGallery] SET Id = @Id, Title= @Title, Thumbnails= @Thumbnails, NormalPicture= @NormalPicture, Publish= @Publish, Catagory= @Catagory WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand();
            command.CommandText = SQLQuery;

            AddParameters(command, id,title,thumbnails,normalPicture,publish,catagory);

            return Convert.ToBoolean( SQLHelper.ExecuteNonQuery(command));
        }

		public static bool Delete(Int32 id)
		{
			string SQLQuery = "DELETE FROM [PhotoGallery] WHERE [Id]=@Id ";
			SqlCommand command=new SqlCommand();

            command.CommandText = SQLQuery;
			command.Parameters.AddWithValue("@Id",id);

			return Convert.ToBoolean( SQLHelper.ExecuteNonQuery(command));
		}
        public static bool ChangeStatus(int Id, string str)
        {
            string SQLQuery = "UPDATE [PhotoGallery] SET [Publish]=@str WHERE [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@str", SqlDbType.NVarChar).Value = str;


            return SQLHelper.ExecuteNonQuery(command);

        }
        private static void AddParameters(SqlCommand command, BE.PhotoGallery photoGallery)
        {
			command.Parameters.AddWithValue("@Id", photoGallery.Id);
            command.Parameters.AddWithValue("@Title", photoGallery.Title);
            command.Parameters.AddWithValue("@Thumbnails", photoGallery.Thumbnails);
            command.Parameters.AddWithValue("@NormalPicture", photoGallery.NormalPicture);
            command.Parameters.AddWithValue("@Publish", photoGallery.Publish);
            command.Parameters.AddWithValue("@Catagory", photoGallery.Catagory);
        }

        private static void AddParameters(SqlCommand command, Int32 id,String title,String thumbnails,String normalPicture,String publish,Int32 catagory)
        {
			command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Title", title);
            command.Parameters.AddWithValue("@Thumbnails", thumbnails);
            command.Parameters.AddWithValue("@NormalPicture", normalPicture);
            command.Parameters.AddWithValue("@Publish", publish);
            command.Parameters.AddWithValue("@Catagory", catagory);
        }
        #endregion        
	}
}