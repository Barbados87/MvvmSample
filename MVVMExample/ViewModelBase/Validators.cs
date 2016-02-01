using System;
using System.Text;

namespace MVVMExample.ViewModelBase
{
    public class Validators
    {
        public static string SqlIdentifierName(string value, bool allowSpaces, string memberName)
        {
            StringBuilder errorMessage = new StringBuilder("");

            if (!string.IsNullOrEmpty(value) && !char.IsLetter(value[0]) && value[0] != '@' && value[0] != '#' && value[0] != '_')
            {
                errorMessage.AppendInNewLine(String.Format("", memberName));
            }

            if (!string.IsNullOrEmpty(value) && value.Length > 1)
            {
                string symbols = "";

                foreach (char c in value)
                {
                    if (char.IsLetter(c)) continue;

                    if (char.IsDigit(c)) continue;

                    if (c == '@' || c == '$' || c == '#' || c == '_' || c == ' ') continue;

                    symbols += c;
                }

                if (symbols.Length > 0) errorMessage.AppendInNewLine(String.Format("", memberName, symbols));
            }

            if (!string.IsNullOrEmpty(value) && !allowSpaces && value.IndexOf(' ') != -1)
            {
                errorMessage.AppendInNewLine(String.Format("", memberName));
            }

            if (value.Length > 116)
            {
                errorMessage.AppendInNewLine(String.Format("", memberName));
            }

            return errorMessage.ToString();
        }

        /// <summary>
        /// Returns true if the inputname contains just characters that fall within A-Z, a-z, 0-9, and SPACE
        /// If any other characters are found this method returns false. If the input name also starts with 0-9, it will also
        /// return false as this will be deemed invalid. SQL Doesn't like column names starting with a number.
        /// </summary>
        /// <param name="value">Input Name</param>
        /// <param name="memberName">Member Name</param>
        /// <returns>True or False depending if any invalid characters are found</returns>
        public static string IsStrictNameCompliant(string value, string memberName)
        {
            int validcharcount = 0;
            StringBuilder errorMessage = new StringBuilder("");

            char[] chars = value.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];

                if (i == 0)
                {
                    if (c >= 48 && c <= 57) // 0 to 9
                    {
                        errorMessage.AppendInNewLine(String.Format("", memberName));
                        return errorMessage.ToString(); // starts with a number - can't allow this.
                    }
                }

                if (c >= 97 && c <= 122) // a to z - lowercase
                {
                    validcharcount++;
                }

                if (c >= 65 && c <= 90) // A to Z - uppercase
                {
                    validcharcount++;
                }

                if (c >= 48 && c <= 57) // 0 to 9
                {
                    validcharcount++;
                }

                if (c == 32) // SPACE
                {
                    validcharcount++;
                }
            }

            if (validcharcount != chars.Length)
            {
                errorMessage.AppendInNewLine(String.Format("", memberName));
            }

            return errorMessage.ToString();
        }

        /// <summary>
        /// Same as the IsStringNameComplient validator with the exception of disallowing SPACE character
        /// </summary>
        /// <param name="value"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public static string IsStrictIdentifierCompliant(string value, string memberName)
        {
            int validcharcount = 0;
            StringBuilder errorMessage = new StringBuilder("");

            char[] chars = value.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];

                if (i == 0)
                {
                    if (c >= 48 && c <= 57) // 0 to 9
                    {
                        errorMessage.AppendInNewLine(String.Format("", memberName));
                        return errorMessage.ToString(); // starts with a number - can't allow this.
                    }
                }

                if (c >= 97 && c <= 122) // a to z - lowercase
                {
                    validcharcount++;
                }

                if (c >= 65 && c <= 90) // A to Z - uppercase
                {
                    validcharcount++;
                }

                if (c >= 48 && c <= 57) // 0 to 9
                {
                    validcharcount++;
                }

                if (c == 95) // _ (underscore)
                {
                    validcharcount++;
                }
            }

            if (validcharcount != chars.Length)
            {
                errorMessage.AppendInNewLine(String.Format("", memberName));
            }

            return errorMessage.ToString();
        }
    }
}