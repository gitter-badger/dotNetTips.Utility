﻿// ***********************************************************************
// Assembly         : dotNetTips.Utility.Standard
// Author           : David McCarter
// Created          : 06-26-2017
//
// Last Modified By : David McCarter
// Last Modified On : 10-25-2017
// ***********************************************************************
// <copyright file="XmlHelper.cs" company="dotNetTips.com - David McCarter">
//     dotNetTips.com - David McCarter
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using dotNetTips.Utility.Standard.OOP;

namespace dotNetTips.Utility.Standard.Xml
{
    /// <summary>
    /// Class XmlHelper.
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// Deserializes the specified XML.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="xml">The XML.</param>
        /// <returns>T.</returns>
        /// <exception cref="ArgumentNullException">xml</exception>
        public static T Deserialize<T>(string xml)
        {
            Encapsulation.TryValidateParam(xml, nameof(xml));
           
            try
            {
                using (var sr = new StringReader(xml))
                {
                    var xs = new XmlSerializer(typeof(T));
                    return (T)xs.Deserialize(sr);
                }
            }
            catch (InvalidOperationException ex)
            {
                Trace.WriteLine(ex.Message);

                return default(T);
            }
        }

        /// <summary>
        /// De-serializes from XML file.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>T.</returns>
        public static T DeserializeFromXmlFile<T>(string fileName)
        {
            Encapsulation.TryValidateParam(fileName, nameof(fileName));

            if (File.Exists(fileName) == false)
            {
                throw new FileNotFoundException("File not found. Cannot deserialize from XML.", fileName);
            }

            return Deserialize<T>(File.ReadAllText(fileName));
        }

        /// <summary>
        /// Serializes the specified obj to xml.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">obj</exception>
        public static string Serialize(object obj)
        {
            Encapsulation.TryValidateParam<ArgumentNullException>(obj != null, nameof(obj));

            try
            {
                using (var writer = new StringWriter())
                {
                    using (var xmlWriter = XmlWriter.Create(writer))
                    {
                        var serializer = new XmlSerializer(obj.GetType());
                        serializer.Serialize(xmlWriter, obj);

                        return writer.ToString();
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                Trace.WriteLine(ex.Message);

                return string.Empty;
            }
        }

        /// <summary>
        /// Serializes obj to XML file.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="fileName">Name of the file.</param>
        public static void SerializeToXmlFile(object obj, string fileName)
        {
            Encapsulation.TryValidateParam<ArgumentNullException>(obj != null, nameof(obj));
            Encapsulation.TryValidateParam(fileName, nameof(fileName));

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            File.WriteAllText(fileName, Serialize(obj));
        }
    }
}
