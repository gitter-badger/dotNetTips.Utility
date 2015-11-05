﻿// ***********************************************************************
// Assembly         : dotNetTips.Utility.Portable
// Author           : David McCarter
// Created          : 10-27-2014
//
// Last Modified By : David McCarter
// Last Modified On : 10-27-2014
// ***********************************************************************
// <copyright file="TypeExtensions.cs" company="David McCarter Consulting">
//     David McCarter Consulting. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics.Contracts;

namespace dotNetTips.Utility.Portable.Extensions
{
    /// <summary>
    /// Class TypeExtensions.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Return maximum type. Works with value and reference types.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>T.</returns>
        /// <remarks>Original code by: Jeremy Clark</remarks>
        public static T Max<T>(this T obj1, T obj2) where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(obj1 != null);
            Contract.Requires<ArgumentNullException>(obj2 != null);

            return obj1.CompareTo(obj2) >= 0 ? obj1 : obj2;
        }
    }
}