
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System.Runtime.Serialization;

namespace WebReports.Helpers
{
    /// <summary>
    /// ValidationException purpose, description
    /// To do : FxCop Guidelines - http://msdn.microsoft.com/library/ms182151(VS.100).aspx
    /// CA1032: Implement standard exception constructors
    /// </summary>
    [Serializable]
    public class ValidationException : Exception
    {
        #region Public Static Variables

        /// <summary>
        /// Message to show error support message.
        /// </summary>
        public const string ErrorSupportMessage = "An error occurred while performing requested operation. Please contact customer support.";

        /// <summary>
        /// Message to show that there are no record.
        /// </summary>
        public const string NoRecordsMessage = "No records found for the request.";

        /// <summary>
        /// Standard message for error in data access.
        /// </summary>
        public const string ErrorInDBCall = "Error occurred while fetching data from database. Please contact customer support.";

        /// <summary>
        /// Standard message for un-authorized access
        /// </summary>
        public const string NoPermission = "You do not own permissions to access the requested page, Please contact customer support.";

        /// <summary>
        /// Standard message for record saving
        /// </summary>
        public const string RecordSaved = "Record has been saved successfully.";

        /// <summary>
        /// Standard message for record updating
        /// </summary>
        public const string RecordUpdated = "Record has been updated successfully.";

        /// <summary>
        /// Standard message for record deletion
        /// </summary>
        public const string RecordDeleted = "Record has been deleted successfully.";

        /// <summary>
        /// Standard message for delete confirmation
        /// </summary>
        public const string DeleteConfirmation = "Once deleted, the record information cannot be recovered. Are you sure to delete the record?";

        #endregion

        #region Public Properties

        /// <summary>
        /// Validation Results corresponding to the Exception
        /// </summary>
        public ValidationResults ValidationResults { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="validationResults"></param>
        public ValidationException(ValidationResults validationResults)
        {
            this.ValidationResults = validationResults;
        }

        /// <summary>
        /// Constructor which takes a message and adds it as the ValidationResult
        /// </summary>
        /// <param name="message"></param>
        public ValidationException(string message)
            : base(message)
        {
            ValidationResult validationResult = new ValidationResult(message, String.Empty, String.Empty, String.Empty, null);
            ValidationResults results = new ValidationResults();
            results.AddResult(validationResult);
            this.ValidationResults = results;
        }

        /// <summary>
        /// Constructor which takes a message and Property/Field Name, and set them to the ValidationResult of the exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="propertyKey">name of the Html field Name which is responsible for the error. This is usually the Data class property name responsible for the Error</param>
        public ValidationException(string message, string propertyKey)
            : base(message)
        {
            ValidationResult validationResult = new ValidationResult(message, String.Empty, propertyKey, String.Empty, null);
            ValidationResults results = new ValidationResults();
            results.AddResult(validationResult);
            this.ValidationResults = results;
        }

        /// <summary>
        /// Concatenate all Validation messages and return it as a single string
        /// </summary>
        public string GetConcatenatedValidationMessages()
        {
            string concatenatedMessage = String.Empty;
            if (null != this.ValidationResults)
            {
                foreach (ValidationResult result in this.ValidationResults)
                {
                    concatenatedMessage += result.Message + " ";
                }
            }

            return concatenatedMessage;
        }

        #endregion

        #region FxCopGuideline

        public ValidationException()
        {
            // Add any type-specific logic, and supply the default message.
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
            // Add any type-specific logic for inner exceptions.
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            // Implement type-specific serialization constructor logic.
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            if (info != null)
            {
                info.AddValue("results", this.ValidationResults);
            }
        }

        #endregion

    }
}
