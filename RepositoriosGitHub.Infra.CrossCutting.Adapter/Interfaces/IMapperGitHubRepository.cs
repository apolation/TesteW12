using RepositorioGitHub.Dominio;
using System.Collections.Generic;

namespace RepositoriosGitHub.Infra.CrossCutting.Adapter.Interfaces
{
    public interface IMapperGitHubRepository
    {
        GitHubRepositoryViewModel MapperToViewModel(GitHubRepository gitHubRepository);
        IList<GitHubRepositoryViewModel> MapperListGitHubRepositories(IList<GitHubRepository> gitHubRepositories);

    }
}
