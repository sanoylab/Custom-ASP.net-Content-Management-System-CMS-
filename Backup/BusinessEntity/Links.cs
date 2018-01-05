using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Collections;

namespace Sanoy.AddisTower.BE
{
    

    [Serializable]
    public class Links 
    {
        #region Private Fields

        private Int32 iD;
        private String urlText;
        private String url;
        private String publish;
        private RowState state = RowState.Unchanged;

      

        #endregion

        #region Contstructor

        public Links()
        {
        }

        public Links(Int32 iD,String urlText,String url,String publish)
        {
            this.iD = iD;
                this.urlText = urlText;
                this.url = url;
                this.publish = publish;
        }

        public Links(Int32 iD,String urlText,String url,String publish, RowState state)
        {
            this.iD = iD;
                this.urlText = urlText;
                this.url = url;
                this.publish = publish;
            this.state = state;
        }

        #endregion

        #region Const Values

                public const string FIELD_ID = "ID";
        public const string FIELD_UrlText = "UrlText";
        public const string FIELD_Url = "Url";
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
        /// gets or sets the UrlText value
        /// </summary>
        public String UrlText
        {
            get
            {
                return urlText;
            }
            set
            {
                urlText = value;
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
