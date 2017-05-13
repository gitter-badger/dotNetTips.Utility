﻿// ***********************************************************************
// Assembly         : dotNetTips.Utility.Portable
// Author           : David McCarter
// Created          : 02-02-2017
//
// Last Modified By : David McCarter
// Last Modified On : 04-18-2017
// ***********************************************************************
// <copyright file="Encapsulation.cs" company="dotNetTips.Utility.Portable">
//     Copyright (c) dotNetTips.com - McCarter Consulting. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using dotNetTips.Utility.Portable.Extensions;
using System;
using System.Collections;

namespace dotNetTips.Utility.Portable.OOP
{
    /// <summary>
    /// Class Encapsulation.
    /// </summary>
    public static class Encapsulation
    {
        /// <summary>
        /// Tries the validate parameter.
        /// </summary>
        /// <typeparam name="TException">The type of the t exception.</typeparam>
        /// <param name="condition">The condition.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="System.InvalidCastException"></exception>
        public static void TryValidateParam<TException>(bool condition, string message = "") where TException : ArgumentException, new()
        {
            // Validate proper Exception type
            var t = typeof(TException);

            if (t.Name == nameof(Exception))
            {
                throw new InvalidCastException(String.Format(Properties.Resources.CannotBeOfTypeException, nameof(TException)));
            }

            var defaultMessage = Properties.Resources.ParameterIsInvalid;

            if (String.IsNullOrEmpty(message) == false)
            {
                defaultMessage = message;
            }

            if (condition == false)
            {
                var ex = Activator.CreateInstance(typeof(TException), message).As<TException>();
                throw ex;
            }
        }

        /// <summary>
        /// Tries the validate parameter.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryValidateParam(IEnumerable collection, string paramName, string message = "")
        {
            if (collection.IsValid() == false)
            {
                if (message.IsNull())
                {
                    message = Properties.Resources.CollectionIsNullOrHasNoItems;
                }

                throw new ArgumentNullException(paramName, message);
            }
        }

        /// <summary>
        /// Tries the validate parameter.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void TryValidateParam(string value, string paramName, string message = "")
        {
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                if (message.IsNull())
                {
                    message = Properties.Resources.StringIsNullOrEmpty;
                }

                throw new ArgumentNullException(paramName, message);
            }
        }

        /// <summary>
        /// Tries the validate parameter.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void TryValidateParam(Enum value, string paramName, string message = "")
        {
            TryValidateParam(paramName, nameof(paramName));

            if (Enum.IsDefined(value.GetType(), value) == false)
            {
                if (message.IsNull())
                {
                    message = "The value is not defined in the enumeration.";
                }

                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }
    }

}