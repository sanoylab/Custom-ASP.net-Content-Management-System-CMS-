using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Collections;

namespace Sanoy.AddisTower.BE
{
    

    [Serializable]
    public class CommonPageContent 
    {
        #region Private Fields

        private Int32 id;
        private Int32 commonPage;
        private String title;
        private String content;
        private DateTime created;
        private String createdBy;
        private DateTime edited;
        private String editedBy;
        private String publish;
        private RowState state = RowState.Unchanged;

      

        #endregion

        #region Contstructor

        public CommonPageContent()
        {
        }

        public CommonPageContent(Int32 id,Int32 commonPage,String title,String content,DateTime created,String createdBy,DateTime edited,String editedBy,String publish)
        {
            this.id = id;
                this.commonPage = commonPage;
                this.title = title;
                this.content = content;
                this.created = created;
                this.createdBy = createdBy;
                this.edited = edited;
                this.editedBy = editedBy;
                this.publish = publish;
        }

        public CommonPageContent(Int32 id,Int32 commonPage,String title,String content,DateTime created,String createdBy,DateTime edited,String editedBy,String publish, RowState state)
        {
            this.id = id;
                this.commonPage = commonPage;
                this.title = title;
                this.content = content;
                this.created = created;
                this.createdBy = createdBy;
                this.edited = edited;
                this.editedBy = editedBy;
                this.publish = publish;
            this.state = state;
        }

        #endregion

        #region Const Values

                public const string FIELD_Id = "Id";
        public const string FIELD_CommonPage = "CommonPage";
        public const string FIELD_Title = "Title";
        public const string FIELD_Content = "Content";
        public const string FIELD_Created = "Created";
        public const string FIELD_CreatedBy = "CreatedBy";
        public const string FIELD_Edited = "Edited";
        public const string FIELD_EditedBy = "EditedBy";
        public const string FIELD_Publish = "Publish";

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
        /// gets or sets the CommonPage value
        /// </summary>
        public Int32 CommonPage
        {
            get
            {
                return commonPage;
            }
            set
            {
                commonPage = value;
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
