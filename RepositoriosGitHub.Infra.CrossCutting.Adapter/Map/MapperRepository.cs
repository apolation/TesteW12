using RepositorioGitHub.Dominio;
using RepositoriosGitHub.Infra.CrossCutting.Adapter.Interfaces;

namespace RepositoriosGitHub.Infra.CrossCutting.Adapter.Map
{
    public class MapperRepository : IMapperRepository
    {
        public RepositoryViewModel MapperToViewModel(RepositoryModel repositoryModel)
        {
            RepositoryViewModel repositoryViewModel = new RepositoryViewModel
            {
                TotalCount = repositoryModel.TotalCount,
                Repositories = repositoryModel.Repositories
            };
            return repositoryViewModel;
        }
    }
}
