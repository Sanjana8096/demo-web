namespace WebReports.Helpers
{
    public class AjaxResultData
    {

        #region Constructor

        public AjaxResultData()
        {
            this.Success = true;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// true, if the call is without error 
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Message, depends upon "success" field
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Any Returning data to the client side
        /// </summary>
        public object ResultData { get; set; }

        #endregion

    }
}
