using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Collections;

namespace Sanoy.AddisTower.BE
{
    

    [Serializable]
    public class CommonPage 
    {
        #region Private Fields

        private Int32 id;
        private String title;
        private String menuCaption;
        private RowState state = RowState.Unchanged;

      

        #endregion

        #region Contstructor

        public CommonPage()
        {
        }

        public CommonPage(Int32 id,String title,String menuCaption)
        {
            this.id = id;
                this.title = title;
                this.menuCaption = menuCaption;
        }

        public CommonPage(Int32 id,String title,String menuCaption, RowState state)
        {
            this.id = id;
                this.title = title;
                this.menuCaption = menuCaption;
            this.state = state;
        }

        #endregion

        #region Const Values

                public const string FIELD_Id = "Id";
        public const string FIELD_Title = "Title";
        public const string FIELD_MenuCaption = "MenuCaption";

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
        /// gets or sets the MenuCaption value
        /// </summary>
        public String MenuCaption
        {
            get
            {
                return menuCaption;
            }
            set
            {
                menuCaption = value;
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
