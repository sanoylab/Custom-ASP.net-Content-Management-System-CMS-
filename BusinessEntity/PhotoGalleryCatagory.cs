using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Collections;

namespace Sanoy.AddisTower.BE
{
    

    [Serializable]
    public class PhotoGalleryCatagory 
    {
        #region Private Fields

        private Int32 id;
        private String catagoryName;
        private String publish;
        private RowState state = RowState.Unchanged;

      

        #endregion

        #region Contstructor

        public PhotoGalleryCatagory()
        {
        }

        public PhotoGalleryCatagory(Int32 id,String catagoryName,String publish)
        {
            this.id = id;
                this.catagoryName = catagoryName;
                this.publish = publish;
        }

        public PhotoGalleryCatagory(Int32 id,String catagoryName,String publish, RowState state)
        {
            this.id = id;
                this.catagoryName = catagoryName;
                this.publish = publish;
            this.state = state;
        }

        #endregion

        #region Const Values

                public const string FIELD_Id = "Id";
        public const string FIELD_CatagoryName = "CatagoryName";
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
        /// gets or sets the CatagoryName value
        /// </summary>
        public String CatagoryName
        {
            get
            {
                return catagoryName;
            }
            set
            {
                catagoryName = value;
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
