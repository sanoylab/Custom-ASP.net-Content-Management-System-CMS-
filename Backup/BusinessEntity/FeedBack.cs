using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Collections;

namespace Sanoy.AddisTower.BE
{
    

    [Serializable]
    public class FeedBack 
    {
        #region Private Fields

        private String firstName;
        private String lastName;
        private String email;
        private String subject;
        private String comment;
        private String status;
        private RowState state = RowState.Unchanged;

      

        #endregion

        #region Contstructor

        public FeedBack()
        {
        }

        public FeedBack(String firstName,String lastName,String email,String subject,String comment,String status)
        {
            this.firstName = firstName;
                this.lastName = lastName;
                this.email = email;
                this.subject = subject;
                this.comment = comment;
                this.status = status;
        }

        public FeedBack(String firstName,String lastName,String email,String subject,String comment,String status, RowState state)
        {
            this.firstName = firstName;
                this.lastName = lastName;
                this.email = email;
                this.subject = subject;
                this.comment = comment;
                this.status = status;
            this.state = state;
        }

        #endregion

        #region Const Values

                public const string FIELD_FirstName = "FirstName";
        public const string FIELD_LastName = "LastName";
        public const string FIELD_Email = "Email";
        public const string FIELD_Subject = "Subject";
        public const string FIELD_Comment = "Comment";
        public const string FIELD_Status = "Status";

        #endregion

        #region Properties

		        /// <summary>
        /// gets or sets the FirstName value
        /// </summary>
        public String FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        /// <summary>
        /// gets or sets the LastName value
        /// </summary>
        public String LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
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
        /// gets or sets the Subject value
        /// </summary>
        public String Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }

        /// <summary>
        /// gets or sets the Comment value
        /// </summary>
        public String Comment
        {
            get
            {
                return comment;
            }
            set
            {
                comment = value;
            }
        }

        /// <summary>
        /// gets or sets the Status value
        /// </summary>
        public String Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
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
