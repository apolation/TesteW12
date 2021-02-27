using Newtonsoft.Json;

namespace RepositorioGitHub.Dominio
{
    public class RepositoryModel
    {
        [JsonProperty("total_count")]
        public long TotalCount { get; set; }

        [JsonProperty("incomplete_results")]
        public bool IncompleteResults { get; set; }

        [JsonProperty("items")]
        public GitHubRepository[] Repositories { get; set; }
    }
}
