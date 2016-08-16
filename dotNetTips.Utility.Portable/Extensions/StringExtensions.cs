﻿// *********************************************************************** Assembly :
// dotNetTips.Utility.Portable Author : David McCarter Created : 04-15-2016
//
// Last Modified By : David McCarter Last Modified On : 06-02-2016 ***********************************************************************
// <copyright file="StringExtensions.cs" company="dotNetTips.com">
//     Copyright Â© 2015
// </copyright>
// <summary>
// </summary>
// ***********************************************************************
using System;
using System.Diagnostics.Contracts;
using System.Text;

namespace dotNetTips.Utility.Portable.Extensions
{
    /// <summary>
    /// Class StringExtensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether the specified the string contains any.
        /// </summary>
        /// <param name="input">     The string.</param>
        /// <param name="characters">The characters.</param>
        /// <returns><c>true</c> if the specified characters contains any; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.ArgumentNullException">Null character.</exception>
        public static bool ContainsAny(this string input, params string[] characters)
        {
            Contract.Requires<ArgumentNullException>(characters != null && characters.Length > 0);

            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            foreach (var character in characters)
            {
                if (string.IsNullOrEmpty(character))
                {
                    throw new ArgumentNullException("Null character.");
                }

                if (input.Contains(character))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Defaults if null.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        public static string DefaultIfNull(this string s)
        {
            return s ?? string.Empty;
        }

        /// <summary>
        /// Defaults if null.
        /// </summary>
        /// <param name="s">           The s.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.String.</returns>
        public static string DefaultIfNull(this string s, string defaultValue)
        {
            return s ?? (defaultValue ?? string.Empty);
        }

        /// <summary>
        /// Defaults if null or empty.
        /// </summary>
        /// <param name="value">       The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.String.</returns>
        public static string DefaultIfNullOrEmpty(this string value, string defaultValue)
        {
            return string.IsNullOrEmpty(value) ? value : defaultValue;
        }

        /// <summary>
        /// Formats the size of the file.
        /// </summary>
        /// <param name="fileSize">Size of the file.</param>
        /// <returns>System.String.</returns>
        public static string FormatFileSize(this long fileSize)
        {
            Contract.Requires<ArgumentOutOfRangeException>(fileSize >= 0 && fileSize >= long.MinValue && fileSize <= long.MaxValue);

            var size = 0L;

            while (fileSize > 1024 && size < 4)
            {
                fileSize = Convert.ToInt64(fileSize / 1024);
                size += 1;
            }

            return ((fileSize + " ") + (new string[] {
            "bytes",
            "KB",
            "MB",
            "GB"
            })[Convert.ToInt32(size)]);
        }

        /// <summary>
        /// Indents the specified length.
        /// </summary>
        /// <param name="str">                 The string.</param>
        /// <param name="length">              The length.</param>
        /// <param name="indentationCharacter">The indentation character.</param>
        /// <returns>System.String.</returns>
        public static string Indent(this string str, int length, char indentationCharacter = ControlChars.Space)
        {
            Contract.Requires<ArgumentOutOfRangeException>(length > 0);

            var sb = new StringBuilder();

            if (length < 0)
            {
                sb.Append(str);
            }
            int i;

            for (i = 1; i <= Math.Abs(length); i++)
            {
                sb.Append(indentationCharacter);
            }

            if (length > 0)
            {
                sb.Append(str);
            }
            return sb.ToString();
        }
    }
}