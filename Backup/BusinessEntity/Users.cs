using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Collections;

namespace Sanoy.AddisTower.BE
{
    

    [Serializable]
    public class Users 
    {
        #region Private Fields

        private Int32 iD;
        private String userName;
        private String passWord;
        private String firstName;
        private String middleName;
        private String lastName;
        private Boolean loggedIn;
        private RowState state = RowState.Unchanged;

      

        #endregion

        #region Contstructor

        public Users()
        {
        }

        public Users(Int32 iD,String userName,String passWord,String firstName,String middleName,String lastName,Boolean loggedIn)
        {
            this.iD = iD;
                this.userName = userName;
                this.passWord = passWord;
                this.firstName = firstName;
                this.middleName = middleName;
                this.lastName = lastName;
                this.loggedIn = loggedIn;
        }

        public Users(Int32 iD,String userName,String passWord,String firstName,String middleName,String lastName,Boolean loggedIn, RowState state)
        {
            this.iD = iD;
                this.userName = userName;
                this.passWord = passWord;
                this.firstName = firstName;
                this.middleName = middleName;
                this.lastName = lastName;
                this.loggedIn = loggedIn;
            this.state = state;
        }

        #endregion

        #region Const Values

                public const string FIELD_ID = "ID";
        public const string FIELD_UserName = "UserName";
        public const string FIELD_PassWord = "PassWord";
        public const string FIELD_FirstName = "FirstName";
        public const string FIELD_MiddleName = "MiddleName";
        public const string FIELD_LastName = "LastName";
        public const string FIELD_LoggedIn = "LoggedIn";

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
        /// gets or sets the UserName value
        /// </summary>
        public String UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        /// <summary>
        /// gets or sets the PassWord value
        /// </summary>
        public String PassWord
        {
            get
            {
                return passWord;
            }
            set
            {
                passWord = value;
            }
        }

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
        /// gets or sets the MiddleName value
        /// </summary>
        public String MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
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
        /// gets or sets the LoggedIn value
        /// </summary>
        public Boolean LoggedIn
        {
            get
            {
                return loggedIn;
            }
            set
            {
                loggedIn = value;
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
