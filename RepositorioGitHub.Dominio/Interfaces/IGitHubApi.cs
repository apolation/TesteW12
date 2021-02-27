using System.Threading.Tasks;

namespace RepositorioGitHub.Dominio.Interfaces
{
    public interface IGitHubApi
    {
        Task<ActionResult<GitHubRepository>> GetRepositoryAsync(string owner);
        Task<ActionResult<GitHubRepository>> GetRepositoryIdAsync(long id);
        Task<ActionResult<RepositoryModel>> GetRepositoryByName(string name);
    }
}
