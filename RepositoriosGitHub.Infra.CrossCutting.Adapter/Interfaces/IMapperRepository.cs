using RepositorioGitHub.Dominio;

namespace RepositoriosGitHub.Infra.CrossCutting.Adapter.Interfaces
{
    public interface IMapperRepository
    {
        RepositoryViewModel MapperToViewModel(RepositoryModel repositoryModel);
    }
}
