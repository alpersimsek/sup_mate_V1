// <copyright file="UserRepository.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.FAQPlusPlus.Configuration.NextVersion.Repositories
{
    using Microsoft.Teams.Apps.FAQPlusPlus.Configuration.NextVersion.Models;
    using System.Threading.Tasks;

    /// <summary>
    /// Repository of the user data stored in the table storage.
    /// </summary>
    public class ConfigurationInfoRepository : BaseRepository<ConfigurationInfoEntity>
    {
        /// <summary>
        /// Table name for user data table
        /// </summary>
        public static readonly string TableName = "ConfigurationInfo";

        /// <summary>
        /// Users data partition key name.
        /// </summary>
        public static readonly string PartitionKey = "ConfigurationInfo";

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationInfoRepository"/> class.
        /// </summary>
        public ConfigurationInfoRepository()
            : base(
                ConfigurationInfoRepository.TableName,
                ConfigurationInfoRepository.PartitionKey,
                false)
        {
        }
    }
}
