using RepositorioGitHub.Dominio;
using System.Threading.Tasks;

namespace RepositorioGitHub.Business.Contract
{
    public interface IGitHubApiBusiness
    {
        Task<ActionResult<GitHubRepositoryViewModel>> GetAsync();
        Task<ActionResult<RepositoryViewModel>> GetByName(string name);
        Task<ActionResult<GitHubRepositoryViewModel>> GetById(long id);
        Task<ActionResult<GitHubRepositoryViewModel>> GetRepository(string owner, long id);
        ActionResult<FavoriteViewModel> GetFavoriteRepository();
        ActionResult<FavoriteViewModel> SaveFavoriteRepository(FavoriteViewModel view);
    }
}
