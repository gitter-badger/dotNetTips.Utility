﻿// ***********************************************************************
// Assembly         : dotNetTips.Utility.Standard
// Author           : David McCarter
// Created          : 02-11-2017
//
// Last Modified By : David McCarter
// Last Modified On : 09-16-2017
// ***********************************************************************
// <copyright file="FileHelper.cs" company="dotNetTips.com - David McCarter">
//     dotNetTips.com - David McCarter
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using dotNetTips.Utility.Standard.Extensions;
using dotNetTips.Utility.Standard.OOP;

namespace dotNetTips.Utility.Standard.IO
{
    /// <summary>
    /// Class FileHelper.
    /// </summary>
    public static class FileHelper
    {
        #region Public Events

        #endregion Public Events

        #region Public Methods

        /// <summary>
        /// Deletes the files.
        /// </summary>
        /// <param name="files">The files.</param>
        /// <returns>IEnumerable&lt;KeyValuePair&lt;System.String, System.String&gt;&gt;.</returns>
        public static IEnumerable<KeyValuePair<string, string>> DeleteFiles(this IEnumerable<string> files)
        {
            var errors = new SortedDictionary<string, string>();

            System.Threading.Tasks.Parallel.ForEach(files, (information) =>
            {
                try
                {
                    File.Delete(information);
                }
                catch (IOException fileIOException)
                {
                    errors.AddIfNotExists(new KeyValuePair<string, string>(information, fileIOException.Message));
                }
                catch (UnauthorizedAccessException notAuthorizedException)
                {
                    errors.AddIfNotExists(new KeyValuePair<string, string>(information, notAuthorizedException.Message));
                }
            });



            return errors.AsEnumerable();
        }

        /// <summary>
        /// Copies a file as an asynchronous operation.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="destinationFolder">The destination folder.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public static async Task<long> CopyFileAsync(FileInfo file, DirectoryInfo destinationFolder)
        {
            Encapsulation.TryValidateParam(file, nameof(file));
            Encapsulation.TryValidateParam(destinationFolder, nameof(destinationFolder));

            var backUpFolderRoot = destinationFolder.FullName.Split(ControlChars.BackSlash).Last().Trim();

            var newFileName = file.FullName.Replace(destinationFolder.FullName, backUpFolderRoot);

            using (var sourceStream = File.Open(file.FullName, FileMode.Open))
            {
                if (File.Exists(newFileName))
                {
                    File.Delete(newFileName);
                }

                using (var destinationStream = File.Create(newFileName))
                {
                    await sourceStream.CopyToAsync(destinationStream);
                    await destinationStream.FlushAsync();
                }
            }

            return file.Length;

        }
        #endregion Public Methods
    }
}