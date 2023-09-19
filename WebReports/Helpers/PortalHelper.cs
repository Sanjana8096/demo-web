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
        /// Gets the domain part of the email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static string GetDomainFromEmail(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                int index = email.IndexOf("@");
                if (index > 0)
                {
                    return email.Substring(index+1);
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
        public const string DefaultAdminKey = "DefaultAdminAccounts";

        #endregion

    }

}
