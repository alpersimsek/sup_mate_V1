// <copyright file="UserEntity.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.FAQPlusPlus.Configuration.NextVersion.Repositories
{
    using Microsoft.Azure.Cosmos.Table;

    /// <summary>
    /// User data entity class.
    /// </summary>
    public class ConfigurationInfoEntity : TableEntity
    {
        /// <summary>
        /// Gets or sets data.
        /// </summary>
        public string Data { get; set; }
    }
}
