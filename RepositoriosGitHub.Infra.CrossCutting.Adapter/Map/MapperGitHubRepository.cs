using RepositorioGitHub.Dominio;
using RepositoriosGitHub.Infra.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace RepositoriosGitHub.Infra.CrossCutting.Adapter.Map
{
    public class MapperGitHubRepository : IMapperGitHubRepository
    {
        IList<GitHubRepositoryViewModel> gitHubRepositoriesViewModel = new List<GitHubRepositoryViewModel>();


        public IList<GitHubRepositoryViewModel> MapperListGitHubRepositories(IList<GitHubRepository> gitHubRepositories)
        {

            foreach (var item in gitHubRepositories)
            {
                gitHubRepositoriesViewModel.Add(MapperToViewModel(item));
            }
            return gitHubRepositoriesViewModel;
        }

        public GitHubRepositoryViewModel MapperToViewModel(GitHubRepository gitHubRepository)
        {
            GitHubRepositoryViewModel gitHubRepositoryViewModel = new GitHubRepositoryViewModel
            {
                Id = gitHubRepository.Id,
                Description = gitHubRepository.Description,
                FullName = gitHubRepository.FullName,
                Homepage = gitHubRepository.Homepage,
                Language = gitHubRepository.Language,
                Name = gitHubRepository.Name,
                Owner = gitHubRepository.Owner,
                UpdatedAt = gitHubRepository.UpdatedAt,
                Url = gitHubRepository.Url
            };

            return gitHubRepositoryViewModel;

        }
    }
}
