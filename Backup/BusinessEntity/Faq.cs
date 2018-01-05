using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Collections;

namespace Sanoy.AddisTower.BE
{
    

    [Serializable]
    public class Faq 
    {
        #region Private Fields

        private Int32 iD;
        private String question;
        private String answer;
        private String publish;
        private RowState state = RowState.Unchanged;

      

        #endregion

        #region Contstructor

        public Faq()
        {
        }

        public Faq(Int32 iD,String question,String answer,String publish)
        {
            this.iD = iD;
                this.question = question;
                this.answer = answer;
                this.publish = publish;
        }

        public Faq(Int32 iD,String question,String answer,String publish, RowState state)
        {
            this.iD = iD;
                this.question = question;
                this.answer = answer;
                this.publish = publish;
            this.state = state;
        }

        #endregion

        #region Const Values

                public const string FIELD_ID = "ID";
        public const string FIELD_Question = "Question";
        public const string FIELD_Answer = "Answer";
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
        /// gets or sets the Question value
        /// </summary>
        public String Question
        {
            get
            {
                return question;
            }
            set
            {
                question = value;
            }
        }

        /// <summary>
        /// gets or sets the Answer value
        /// </summary>
        public String Answer
        {
            get
            {
                return answer;
            }
            set
            {
                answer = value;
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
