using System.Configuration;
using System.Globalization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;

namespace WebReports.Helpers
{
    public static class PortalHelper
    {

        #region Helper Methods

        /// <summary>
        /// Replaces the special characters by the specified character.
        /// Excludes the underscore.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="replaceCharacter"></param>
        /// <returns></returns>
        public static string ReplaceSpecialCharacters(string text, string replaceCharacter)
        {
            return Regex.Replace(text, "[^a-zA-Z0-9_]+", replaceCharacter ?? String.Empty, RegexOptions.Compiled);
        }

        /// <summary>
        /// Removes the blank spaces from the text content
        /// </summary>
        /// <param name="textContent"></param>
        /// <returns></returns>
        public static string TrimTextContent(string textContent)
        {
            if (!String.IsNullOrEmpty(textContent))
            {
                textContent = textContent.Trim();
            }
            return textContent;
        }

        /// <summary>
        /// Get the name part of the email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static string GetNameFromEmail(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                int index = email.IndexOf("@");
                if (index > 0)
                {
                    return email.Substring(0, index);
                }
                return email;
            }
            return String.Empty;
        }

        
        /// <summary>
        /// Gets the Camel case of the inpue text
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public static string GetCamelCase(string inputText)
        {
            string camelCase = String.Empty;
            if (!String.IsNullOrEmpty(inputText))
            {
                camelCase = inputText.Substring(0, 1).ToLower(System.Globalization.CultureInfo.InstalledUICulture);
                camelCase = camelCase + inputText.Substring(1);
            }
            return camelCase;
        }

        /// <summary>
        /// Gets the title case of the input text
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public static string GetTitleCase(string inputText)
        {
            string titleCase = String.Empty;
            if (!String.IsNullOrWhiteSpace(inputText))
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                titleCase = textInfo.ToTitleCase(inputText);
            }
            return titleCase;
        }

        /// <summary>
        /// Encrypts given string to Base64Hash using SHA1 Hash Algoritham
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        //public static string EncryptToSha1Hash(string password)
        //{
        //    byte[] bytes = Encoding.Unicode.GetBytes(password);
        //    byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
        //    return Convert.ToBase64String(inArray);
        //}

        /// <summary>
        /// Membership error code to String.
        /// </summary>
        /// <param name="createStatus"></param>
        /// <returns></returns>
        //public static string ErrorCodeToString(MembershipCreateStatus createStatus)
        //{
        //    // See http://go.microsoft.com/fwlink/?LinkID=177550 for
        //    // a full list of status codes.
        //    switch (createStatus)
        //    {
        //        case MembershipCreateStatus.DuplicateUserName:
        //            return "User name already exists. Please enter a different user name.";

        //        case MembershipCreateStatus.DuplicateEmail:
        //            return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

        //        case MembershipCreateStatus.InvalidPassword:
        //            return "The password provided is invalid. Please enter a valid password value.";

        //        case MembershipCreateStatus.InvalidEmail:
        //            return "The e-mail address provided is invalid. Please check the value and try again.";

        //        case MembershipCreateStatus.InvalidAnswer:
        //            return "The password retrieval answer provided is invalid. Please check the value and try again.";

        //        case MembershipCreateStatus.InvalidQuestion:
        //            return "The password retrieval question provided is invalid. Please check the value and try again.";

        //        case MembershipCreateStatus.InvalidUserName:
        //            return "The user name provided is invalid. Please check the value and try again.";

        //        case MembershipCreateStatus.ProviderError:
        //            return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

        //        case MembershipCreateStatus.UserRejected:
        //            return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

        //        default:
        //            return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
        //    }
        //}

        #endregion

        #region ReadOnly Properties

        /// <summary>
        /// Gets the default admin user name
        /// </summary>
        //public static string DefaultAdminAccount
        //{
        //    get
        //    {
        //        return ConfigurationManager.AppSettings[DefaultAdminKey] ?? "admin@boadvisors.com";
        //    }
        //}

        /// <summary>
        /// Gets the default admin user name
        /// </summary>
        //public static string NotifyEmail
        //{
        //    get
        //    {
        //        return ConfigurationManager.AppSettings[NotifyEmailKey] ?? "info@boadvisors.com";
        //    }
        //}

        #endregion

        #region Global Variables

        /// <summary>
        /// global constant representing Complaints db ConnectionString key for web.config's connectionStrings section.
        /// </summary>
        public const string AppConnectionKey = "DefaultConnection";

        /// <summary>
        /// global constant representing DefaultAdminKey for web.config's appsettings section.
        /// </summary>
        public const string DefaultAdminKey = "DefaultAdminAccount";

        /// <summary>
        /// global constant representing NotifyEmailKey for web.config's appsettings section.
        /// </summary>
        public const string NotifyEmailKey = "NotifyEmail";

        #endregion

    }

}
