using Microsoft.Teams.Apps.FAQPlusPlus.Configuration.NextVersion.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Teams.Apps.FAQPlusPlus.Configuration.NextVersion.Repositories
{
    public class FAQPlusPlusConfigurationService
    {
        private readonly ConfigurationInfoRepository configurationInfoRepository;

        public FAQPlusPlusConfigurationService(ConfigurationInfoRepository configurationInfoRepository)
        {
            this.configurationInfoRepository = configurationInfoRepository;
        }

        public async Task<FAQPlusPlusConfiguration> GetAsync()
        {
            var configurationInfoEntities = await this.configurationInfoRepository.GetAllAsync();
            var result = new FAQPlusPlusConfiguration();
            foreach (var configurationInfoEntity in configurationInfoEntities)
            {
                switch (configurationInfoEntity.RowKey)
                {
                    case nameof(FAQPlusPlusConfiguration.TeamId):
                        result.TeamId = configurationInfoEntity.Data;
                        break;
                    case nameof(FAQPlusPlusConfiguration.KnowledgeBaseId):
                        result.KnowledgeBaseId = configurationInfoEntity.Data;
                        break;
                    case nameof(FAQPlusPlusConfiguration.WelcomeMessageText):
                        result.WelcomeMessageText = configurationInfoEntity.Data;
                        break;
                    case nameof(FAQPlusPlusConfiguration.HelpTabText):
                        result.HelpTabText = configurationInfoEntity.Data;
                        break;
                }
            }

            return result;
        }

        public async Task SaveAsync(FAQPlusPlusConfiguration faqPlusPlusConfiguration)
        {
            var configurationInfoEntities = new List<ConfigurationInfoEntity>
            {
                this.ToConfigurationInfoEntity(
                    nameof(faqPlusPlusConfiguration.TeamId),
                    faqPlusPlusConfiguration.TeamId),
                this.ToConfigurationInfoEntity(
                    nameof(faqPlusPlusConfiguration.KnowledgeBaseId),
                    faqPlusPlusConfiguration.KnowledgeBaseId),
                this.ToConfigurationInfoEntity(
                    nameof(faqPlusPlusConfiguration.WelcomeMessageText),
                    faqPlusPlusConfiguration.WelcomeMessageText),
                this.ToConfigurationInfoEntity(
                    nameof(faqPlusPlusConfiguration.HelpTabText),
                    faqPlusPlusConfiguration.HelpTabText),
            };

            await this.configurationInfoRepository.BatchInserOrReplaceAsync(configurationInfoEntities);
        }

        private ConfigurationInfoEntity ToConfigurationInfoEntity(string rowKey, string data)
        {
            return new ConfigurationInfoEntity
            {
                PartitionKey = ConfigurationInfoRepository.PartitionKey,
                RowKey = rowKey,
                Data = data,
            };
        }
    }
}
