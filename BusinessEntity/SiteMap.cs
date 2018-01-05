using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Collections;

namespace Sanoy.AddisTower.BE
{
    

    [Serializable]
    public class SiteMap 
    {
        #region Private Fields

        private Int32 iD;
        private String title;
        private String url;
        private String keywords;
        private String description;
        private DateTime created;
        private String creator;
        private DateTime edited;
        private String editor;
        private String publish;
        private RowState state = RowState.Unchanged;

      

        #endregion

        #region Contstructor

        public SiteMap()
        {
        }

        public SiteMap(Int32 iD,String title,String url,String keywords,String description,DateTime created,String creator,DateTime edited,String editor,String publish)
        {
            this.iD = iD;
                this.title = title;
                this.url = url;
                this.keywords = keywords;
                this.description = description;
                this.created = created;
                this.creator = creator;
                this.edited = edited;
                this.editor = editor;
                this.publish = publish;
        }

        public SiteMap(Int32 iD,String title,String url,String keywords,String description,DateTime created,String creator,DateTime edited,String editor,String publish, RowState state)
        {
            this.iD = iD;
                this.title = title;
                this.url = url;
                this.keywords = keywords;
                this.description = description;
                this.created = created;
                this.creator = creator;
                this.edited = edited;
                this.editor = editor;
                this.publish = publish;
            this.state = state;
        }

        #endregion

        #region Const Values

                public const string FIELD_ID = "ID";
        public const string FIELD_Title = "Title";
        public const string FIELD_Url = "Url";
        public const string FIELD_Keywords = "Keywords";
        public const string FIELD_Description = "Description";
        public const string FIELD_Created = "Created";
        public const string FIELD_Creator = "Creator";
        public const string FIELD_Edited = "Edited";
        public const string FIELD_Editor = "Editor";
        public const string FIELD_Publish = "Publish";

        #endregion

        #region Properties

		        /// <summary>
        /// gets or sets the ID value
        /// </summary>
        public Int32 ID
        {
            get
            {
                return iD;
            }
            set
            {
                iD = value;
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
        /// gets or sets the Url value
        /// </summary>
        public String Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }

        /// <summary>
        /// gets or sets the Keywords value
        /// </summary>
        public String Keywords
        {
            get
            {
                return keywords;
            }
            set
            {
                keywords = value;
            }
        }

        /// <summary>
        /// gets or sets the Description value
        /// </summary>
        public String Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        /// <summary>
        /// gets or sets the Created value
        /// </summary>
        public DateTime Created
        {
            get
            {
                return created;
            }
            set
            {
                created = value;
            }
        }

        /// <summary>
        /// gets or sets the Creator value
        /// </summary>
        public String Creator
        {
            get
            {
                return creator;
            }
            set
            {
                creator = value;
            }
        }

        /// <summary>
        /// gets or sets the Edited value
        /// </summary>
        public DateTime Edited
        {
            get
            {
                return edited;
            }
            set
            {
                edited = value;
            }
        }

        /// <summary>
        /// gets or sets the Editor value
        /// </summary>
        public String Editor
        {
            get
            {
                return editor;
            }
            set
            {
                editor = value;
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
