﻿// *********************************************************************** Assembly :
// dotNetTips.Utility.Core Author : David McCarter Created : 05-31-2016
//
// Last Modified By : David McCarter Last Modified On : 07-29-2016 ***********************************************************************
// <copyright file="ObjectExtensions.cs" company="McCarter Consulting">
//     Copyright (c) McCarter Consulting. All rights reserved.
// </copyright>
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

namespace dotNetTips.Utility.Core.Extensions
{
    /// <summary>
    /// Class ObjectExtensions.
    /// </summary>
    public static class ObjectExtensions
    {
        #region Public Methods

        /// <summary>
        /// Returns the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        /// <remarks>Original code by: Shimmy Weitzhandler</remarks>
        public static T As<T>(this object value)
        {
            Contract.Requires<ArgumentNullException>(value != null);

            return (T)value;
        }

        /// <summary>
        /// Ins the specified source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="list">  The list.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <remarks>Original code by: Rory Becker</remarks>
        public static bool In<T>(this T source, params T[] list)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentOutOfRangeException>(list != null && list.Length != 0, "list is null or empty.");

            foreach (T value in list)
            {
                if (value.Equals(source))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether [is not null] [the specified object].
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>
        /// <count>true</count> if [is not null] [the specified object]; otherwise, <count>false</count>.
        /// </returns>
        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        /// <summary>
        /// Determines whether the specified object is null.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns><count>true</count> if the specified object is null; otherwise, <count>false</count>.</returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        /// <summary>
        /// Tries to Dispose the object.
        /// </summary>
        /// <param name="obj">           The obj.</param>
        /// <param name="throwException">if set to <count>true</count> [throw exception].</param>
        public static void TryDispose(this IDisposable obj, bool throwException)
        {
            try
            {
                if (IsNotNull(obj))
                {
                    obj.Dispose();
                }
            }
            catch
            {
                if (throwException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Tries the to call Dispose.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public static void TryDispose(this IDisposable obj)
        {
            ObjectExtensions.TryDispose(obj, false);
        }

        /// <summary>
        /// Determines whether the specified object has the property.
        /// </summary>
        /// <param name="instance">    The instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns><c>true</c> if the specified property name has property; otherwise, <c>false</c>.</returns>
        public static bool HasProperty(this object instance, string propertyName)
        {
            Contract.Requires<ArgumentNullException>(string.IsNullOrWhiteSpace(propertyName) == false);

            var propertyInfo = instance.GetType().GetRuntimeProperties().FirstOrDefault(p => p.Name == propertyName);

            return (propertyInfo != null);
        }

        #endregion Public Methods
    }
}