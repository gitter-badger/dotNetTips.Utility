﻿// ***********************************************************************
// Assembly         : dotNetTips.Utility.Portable
// Author           : david
// Created          : 06-02-2017
//
// Last Modified By : david
// Last Modified On : 07-09-2017
// ***********************************************************************
// <copyright file="DataEntity.cs" company="dotNetTips.com">
//     David McCarter - dotNetTips.com © 2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetTips.Utility.Portable.Data
{
    /// <summary>
    /// Base Class for Entity Framework Data Entities.
    /// </summary>
    /// <seealso cref="dotNetTips.Utility.Portable.Data.IDataEntity" />
    public abstract class DataEntity : IDataEntity
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DataEntity" /> class.
        /// </summary>
        protected DataEntity()
        {
            this.CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the created at date.
        /// </summary>
        /// <value>The created at.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DataEntity" /> is deleted.
        /// </summary>
        /// <value><c>true</c> if deleted; otherwise, <c>false</c>.</value>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the public key.
        /// </summary>
        /// <value>The public key.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid PublicKey { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>The updated at.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public byte[] Version { get; set; }


        /// <summary>
        /// Checks to make sure entity is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public virtual bool IsValid
        {
            get
            {
                return IsEntityValid();
            }
        }

        /// <summary>
        /// Determines whether [is entity valid].
        /// </summary>
        /// <returns><c>true</c> if [is entity valid]; otherwise, <c>false</c>.</returns>
        private bool IsEntityValid()
        {
            var returnValue = false;

            if (this.UpdatedAt.HasValue)
            {
                if (this.CreatedAt > this.UpdatedAt)
                {
                    returnValue = false;
                }
            }

            return returnValue;
        }

    }
}
