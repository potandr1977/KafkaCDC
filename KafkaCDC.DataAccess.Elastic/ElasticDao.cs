using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;
using KafkaCDC.Domain.Elastic;

namespace KafkaCDC.DataAccess.Elastic
{
    public class ElasticDao
    {
        private readonly IElasticClient elasticClient;

        public ElasticDao(IElasticClient elasticClient)
        {
            this.elasticClient = elasticClient;
        }

        public Task Save(Account account) => elasticClient.IndexDocumentAsync(account);

        public async Task<IReadOnlyCollection<Account>> GetAllMessages()
        {
            var resp = await elasticClient.SearchAsync<Account>(s => s
                .From(0)
                .Size(10)
                .Query(q => q
                    .MatchAll()
                )
            );

            return resp.Documents;
        }
    }
}
