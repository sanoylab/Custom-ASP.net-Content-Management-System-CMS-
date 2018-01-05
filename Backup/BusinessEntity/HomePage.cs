using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Collections;

namespace Sanoy.AddisTower.BE
{
    

    [Serializable]
    public class HomePage 
    {
        #region Private Fields

        private Int32 id;
        private String title;
        private String content;
        private String content1;
        private DateTime created;
        private String createdBy;
        private DateTime edited;
        private String editedBy;
        private String publish;
        private String language;
        private RowState state = RowState.Unchanged;

      

        #endregion

        #region Contstructor

        public HomePage()
        {
        }

        public HomePage(Int32 id,String title,String content,String content1,DateTime created,String createdBy,DateTime edited,String editedBy,String publish,String language)
        {
            this.id = id;
                this.title = title;
                this.content = content;
                this.content1 = content1;
                this.created = created;
                this.createdBy = createdBy;
                this.edited = edited;
                this.editedBy = editedBy;
                this.publish = publish;
                this.language = language;
        }

        public HomePage(Int32 id,String title,String content,String content1,DateTime created,String createdBy,DateTime edited,String editedBy,String publish,String language, RowState state)
        {
            this.id = id;
                this.title = title;
                this.content = content;
                this.content1 = content1;
                this.created = created;
                this.createdBy = createdBy;
                this.edited = edited;
                this.editedBy = editedBy;
                this.publish = publish;
                this.language = language;
            this.state = state;
        }

        #endregion

        #region Const Values

                public const string FIELD_Id = "Id";
        public const string FIELD_Title = "Title";
        public const string FIELD_Content = "Content";
        public const string FIELD_Content1 = "Content1";
        public const string FIELD_Created = "Created";
        public const string FIELD_CreatedBy = "CreatedBy";
        public const string FIELD_Edited = "Edited";
        public const string FIELD_EditedBy = "EditedBy";
        public const string FIELD_Publish = "Publish";
        public const string FIELD_Language = "Language";

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
        /// gets or sets the Content value
        /// </summary>
        public String Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }

        /// <summary>
        /// gets or sets the Content1 value
        /// </summary>
        public String Content1
        {
            get
            {
                return content1;
            }
            set
            {
                content1 = value;
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
        /// gets or sets the CreatedBy value
        /// </summary>
        public String CreatedBy
        {
            get
            {
                return createdBy;
            }
            set
            {
                createdBy = value;
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
        /// gets or sets the EditedBy value
        /// </summary>
        public String EditedBy
        {
            get
            {
                return editedBy;
            }
            set
            {
                editedBy = value;
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
