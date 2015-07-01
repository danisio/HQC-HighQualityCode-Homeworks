namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Library with string extension methods.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns a copy of this string hashed with MD5 algorithm.
        /// </summary>
        /// <param name="input">Initial string</param>
        /// <returns>a MD5 hashed string</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Indicates whether the specified string is a positive respond.
        /// "true", "ok", "yes", "1", "да" 
        /// </summary>
        /// <param name="input">A string for checking(case insensitive).</param>
        /// <returns>true if find match, otherwise false</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit signed integer equivalent.
        /// <para>&#160;</para>
        /// The conversion fails if the input parameter is null, is not of the correct format, or represents a number less than System.Int16.MinValue or greater than System.Int16.MaxValue.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <returns>16-bit signed integer value equivalent to the number contained in input, or zero if the conversion failed.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer equivalent.
        /// <para>&#160;</para>
        /// The conversion fails if the s parameter is null, is not of the correct format, or represents a number less than System.Int32.MinValue or greater than System.Int32.MaxValue.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <returns>32-bit signed integer value equivalent to the number contained in input, or zero if the conversion failed.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts the string representation of a number to its 64-bit signed integer equivalent.
        /// <para>&#160;</para>
        /// The conversion fails if the input parameter is null, is not of the correct format, or represents a number less than System.Int64.MinValue or greater than System.Int64.MaxValue.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <returns>64-bit signed integer value equivalent to the number contained in input, or zero if the conversion failed.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the specified string representation of a date and time to its System.DateTime equivalent.
        /// </summary>
        /// <param name="input">A string containing a date and time to convert.</param>
        /// <remarks>The conversion fails if the input parameter is null, is an empty string (""), or does not contain a valid string representation of a date and time.</remarks>
        /// <returns>System.DateTime value equivalent to the date and time contained in input, if the conversion succeeded, or System.DateTime.MinValue if the conversion failed.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Returns a copy of this string with the first letter capitalized, using the casing rules of the specified culture.
        /// </summary>
        /// <param name="input">Initial string</param>
        /// <returns>a string with the first letter capitalized.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Retrieves a substring between 2 strings from this instance. The substring starts at a specific position.
        /// <para>&#160;</para>
        /// If substring is not found it returns an empty string.
        /// </summary>
        /// <param name="input">Initial string</param>
        /// <param name="startString">A string used for start position.</param>
        /// <param name="endString">A string used for end position.</param>
        /// <param name="startFrom">The zero-based starting character position of a substring in this instance.</param>
        /// <returns>returns found substring</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Returns a new string in which all occurrences of cyrillic characters are replaced with latin characters.
        /// </summary>
        /// <param name="input">Initial string</param>
        /// <returns>A string that is equivalent to the current string except that all instances of cyrillic are replaced with latin.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Returns a new string in which all occurrences of latin characters are replaced with cyrillic characters.
        /// </summary>
        /// <param name="input">Initial string</param>
        /// <returns>A string that is equivalent to the current string except that all instances of latin are replaced with cyrillic.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Returns a new string in which are deleted all invalid characters.
        /// <para>&#160;</para>
        /// i.g. special characters except "_" and "."
        /// </summary>
        /// <param name="input">Initial string</param>
        /// <returns>a valid string that becomes a username</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Returns a new string in which are deleted all invalid characters. All spaces are replaced with "-".
        /// <para>&#160;</para>
        /// i.g. special characters except "_", "-" and "."
        /// </summary>
        /// <param name="input">Initial string</param>
        /// <returns>a valid string that becomes a file name</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at the beginning and has a specified length.
        /// </summary>
        /// <param name="input">Initial string.</param>
        /// <param name="charsCount">The length of the substring.</param>
        /// <returns>return а new string of length equal to charsCount</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Returns the extension of a file. It returns an empty string if the supplied string is null or is empty or has no extension.
        /// </summary>
        /// <param name="fileName">Name of a file.</param>
        /// <returns>The extension of fileName.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns the content type of a file extension.
        /// </summary>
        /// <param name="fileExtension">The extension of a file.</param>
        /// <returns>The content type, or if not found - "application/octet-stream"</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Returns a converted string to byte array.
        /// </summary>
        /// <param name="input">Initial string.</param>
        /// <returns>Converted string to byte array.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
