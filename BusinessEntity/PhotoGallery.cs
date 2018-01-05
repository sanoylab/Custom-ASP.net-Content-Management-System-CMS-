using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Collections;

namespace Sanoy.AddisTower.BE
{
    

    [Serializable]
    public class PhotoGallery 
    {
        #region Private Fields

        private Int32 id;
        private String title;
        private String thumbnails;
        private String normalPicture;
        private String publish;
        private Int32 catagory;
        private RowState state = RowState.Unchanged;

      

        #endregion

        #region Contstructor

        public PhotoGallery()
        {
        }

        public PhotoGallery(Int32 id,String title,String thumbnails,String normalPicture,String publish,Int32 catagory)
        {
            this.id = id;
                this.title = title;
                this.thumbnails = thumbnails;
                this.normalPicture = normalPicture;
                this.publish = publish;
                this.catagory = catagory;
        }

        public PhotoGallery(Int32 id,String title,String thumbnails,String normalPicture,String publish,Int32 catagory, RowState state)
        {
            this.id = id;
                this.title = title;
                this.thumbnails = thumbnails;
                this.normalPicture = normalPicture;
                this.publish = publish;
                this.catagory = catagory;
            this.state = state;
        }

        #endregion

        #region Const Values

                public const string FIELD_Id = "Id";
        public const string FIELD_Title = "Title";
        public const string FIELD_Thumbnails = "Thumbnails";
        public const string FIELD_NormalPicture = "NormalPicture";
        public const string FIELD_Publish = "Publish";
        public const string FIELD_Catagory = "Catagory";

        #endregion

        #region Properties

		        /// <summary>
        /// gets or sets the Id value
        /// </summary>
        public Int32 Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        /// <summary>
        /// gets or sets the Title value
        /// </summary>
        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        /// <summary>
        /// gets or sets the Thumbnails value
        /// </summary>
        public String Thumbnails
        {
            get
            {
                return thumbnails;
            }
            set
            {
                thumbnails = value;
            }
        }

        /// <summary>
        /// gets or sets the NormalPicture value
        /// </summary>
        public String NormalPicture
        {
            get
            {
                return normalPicture;
            }
            set
            {
                normalPicture = value;
            }
        }

        /// <summary>
        /// gets or sets the Publish value
        /// </summary>
        public String Publish
        {
            get
            {
                return publish;
            }
            set
            {
                publish = value;
            }
        }

        /// <summary>
        /// gets or sets the Catagory value
        /// </summary>
        public Int32 Catagory
        {
            get
            {
                return catagory;
            }
            set
            {
                catagory = value;
            }
        }

        /// <summary>
        /// gets the State value
        /// </summary>
        public RowState State
        {
            get { return state; }
            set { state = value; }
        }

       
        
        #endregion

        #region Methods

        public void Delete()
        {
            this.state = RowState.Deleted;
        }

        public void AcceptChanges()
        {
            state = RowState.Unchanged;
        }

        #endregion
    }
}
