using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Collections;

namespace Sanoy.AddisTower.BE
{
    

    [Serializable]
    public class DocumentType 
    {
        #region Private Fields

        private Byte id;
        private String name;
        private String imgUrl;
        private String language;
        private RowState state = RowState.Unchanged;

      

        #endregion

        #region Contstructor

        public DocumentType()
        {
        }

        public DocumentType(Byte id,String name,String imgUrl,String language)
        {
            this.id = id;
                this.name = name;
                this.imgUrl = imgUrl;
                this.language = language;
        }

        public DocumentType(Byte id,String name,String imgUrl,String language, RowState state)
        {
            this.id = id;
                this.name = name;
                this.imgUrl = imgUrl;
                this.language = language;
            this.state = state;
        }

        #endregion

        #region Const Values

                public const string FIELD_Id = "Id";
        public const string FIELD_Name = "Name";
        public const string FIELD_ImgUrl = "ImgUrl";
        public const string FIELD_Language = "Language";

        #endregion

        #region Properties

		        /// <summary>
        /// gets or sets the Id value
        /// </summary>
        public Byte Id
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
        /// gets or sets the Name value
        /// </summary>
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// gets or sets the ImgUrl value
        /// </summary>
        public String ImgUrl
        {
            get
            {
                return imgUrl;
            }
            set
            {
                imgUrl = value;
            }
        }

        /// <summary>
        /// gets or sets the Language value
        /// </summary>
        public String Language
        {
            get
            {
                return language;
            }
            set
            {
                language = value;
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
