﻿// ***********************************************************************
// Assembly         : dotNetTips.Utility.Standard
// Author           : David McCarter
// Created          : 06-26-2017
//
// Last Modified By : David McCarter
// Last Modified On : 09-16-2017
// ***********************************************************************
// <copyright file="JsonSerializer.cs" company="dotNetTips.com - David McCarter">
//     dotNetTips.com - David McCarter
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using dotNetTips.Utility.Standard.OOP;

namespace dotNetTips.Utility.Standard.Serialization
{
    /// <summary>
    /// Class JsonSerializer.
    /// </summary>
    public static class JsonSerializer
    {
        /// <summary>
        /// Deserializes the specified Json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">The json.</param>
        /// <returns>T.</returns>
        public static T Deserialize<T>(string json) where T : class
        {
            Encapsulation.TryValidateParam(json, nameof(json));

            var obj = TypeHelper.Create<T>();

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var ser = new DataContractJsonSerializer(obj.GetType());
                obj = ser.ReadObject(ms) as T;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.String.</returns>
        public static string Serialize(object obj)
        {
            Encapsulation.TryValidateParam<ArgumentNullException>(obj != null);

            string json;

            using (var ms = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(obj.GetType(), new DataContractJsonSerializerSettings { SerializeReadOnlyTypes = true, UseSimpleDictionaryFormat = true, EmitTypeInformation = System.Runtime.Serialization.EmitTypeInformation.AsNeeded });

                ser.WriteObject(ms, obj);

                json = Encoding.UTF8.GetString(ms.ToArray());
            }

            return json;
        }
    }
}