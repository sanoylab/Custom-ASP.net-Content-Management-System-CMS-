using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Collections;

namespace Sanoy.AddisTower.BE
{
    

    [Serializable]
    public class ContactUs 
    {
        #region Private Fields

        private Int32 id;
        private String post;
        private String contactName;
        private String tel;
        private String fax;
        private String email;
        private String pobox;
        private DateTime created;
        private String creator;
        private DateTime edited;
        private String editor;
        private String publishing;
        private String language;
        private RowState state = RowState.Unchanged;

      

        #endregion

        #region Contstructor

        public ContactUs()
        {
        }

        public ContactUs(Int32 id,String post,String contactName,String tel,String fax,String email,String pobox,DateTime created,String creator,DateTime edited,String editor,String publishing,String language)
        {
            this.id = id;
                this.post = post;
                this.contactName = contactName;
                this.tel = tel;
                this.fax = fax;
                this.email = email;
                this.pobox = pobox;
                this.created = created;
                this.creator = creator;
                this.edited = edited;
                this.editor = editor;
                this.publishing = publishing;
                this.language = language;
        }

        public ContactUs(Int32 id,String post,String contactName,String tel,String fax,String email,String pobox,DateTime created,String creator,DateTime edited,String editor,String publishing,String language, RowState state)
        {
            this.id = id;
                this.post = post;
                this.contactName = contactName;
                this.tel = tel;
                this.fax = fax;
                this.email = email;
                this.pobox = pobox;
                this.created = created;
                this.creator = creator;
                this.edited = edited;
                this.editor = editor;
                this.publishing = publishing;
                this.language = language;
            this.state = state;
        }

        #endregion

        #region Const Values

                public const string FIELD_Id = "Id";
        public const string FIELD_Post = "Post";
        public const string FIELD_ContactName = "ContactName";
        public const string FIELD_Tel = "Tel";
        public const string FIELD_Fax = "Fax";
        public const string FIELD_Email = "Email";
        public const string FIELD_Pobox = "Pobox";
        public const string FIELD_Created = "Created";
        public const string FIELD_Creator = "Creator";
        public const string FIELD_Edited = "Edited";
        public const string FIELD_Editor = "Editor";
        public const string FIELD_Publishing = "Publishing";
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
        /// gets or sets the Post value
        /// </summary>
        public String Post
        {
            get
            {
                return post;
            }
            set
            {
                post = value;
            }
        }

        /// <summary>
        /// gets or sets the ContactName value
        /// </summary>
        public String ContactName
        {
            get
            {
                return contactName;
            }
            set
            {
                contactName = value;
            }
        }

        /// <summary>
        /// gets or sets the Tel value
        /// </summary>
        public String Tel
        {
            get
            {
                return tel;
            }
            set
            {
                tel = value;
            }
        }

        /// <summary>
        /// gets or sets the Fax value
        /// </summary>
        public String Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }

        /// <summary>
        /// gets or sets the Email value
        /// </summary>
        public String Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        /// <summary>
        /// gets or sets the Pobox value
        /// </summary>
        public String Pobox
        {
            get
            {
                return pobox;
            }
            set
            {
                pobox = value;
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
        /// gets or sets the Publishing value
        /// </summary>
        public String Publishing
        {
            get
            {
                return publishing;
            }
            set
            {
                publishing = value;
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
