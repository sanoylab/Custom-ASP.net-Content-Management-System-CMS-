using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Collections;

namespace Sanoy.AddisTower.BE
{
    

    [Serializable]
    public class Downloads 
    {
        #region Private Fields

        private Int32 id;
        private String catagory;
        private String amharicText;
        private RowState state = RowState.Unchanged;

      

        #endregion

        #region Contstructor

        public Downloads()
        {
        }

        public Downloads(Int32 id,String catagory,String amharicText)
        {
            this.id = id;
                this.catagory = catagory;
                this.amharicText = amharicText;
        }

        public Downloads(Int32 id,String catagory,String amharicText, RowState state)
        {
            this.id = id;
                this.catagory = catagory;
                this.amharicText = amharicText;
            this.state = state;
        }

        #endregion

        #region Const Values

                public const string FIELD_Id = "Id";
        public const string FIELD_Catagory = "Catagory";
        public const string FIELD_AmharicText = "AmharicText";

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
        /// gets or sets the Catagory value
        /// </summary>
        public String Catagory
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
        /// gets or sets the AmharicText value
        /// </summary>
        public String AmharicText
        {
            get
            {
                return amharicText;
            }
            set
            {
                amharicText = value;
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
