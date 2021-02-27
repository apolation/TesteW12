using RepositorioGitHub.Business.Contract;
using RepositorioGitHub.Dominio;
using RepositorioGitHub.Dominio.Interfaces;
using RepositorioGitHub.Infra.Contract;
using RepositoriosGitHub.Infra.CrossCutting.Adapter.Interfaces;
using System.Threading.Tasks;

namespace RepositorioGitHub.Business
{
    public class GitHubApiBusiness : IGitHubApiBusiness
    {
        private readonly IContextRepository _context;
        private readonly IGitHubApi _gitHubApi;
        private readonly IMapperGitHubRepository _mapperGitHubRepository;
        private readonly IMapperRepository _mapperRepository;
        private readonly IMapperFavorite _mapperFavorite;
        public GitHubApiBusiness(IContextRepository context, IGitHubApi gitHubApi, IMapperGitHubRepository mapperGitHubRepository, IMapperRepository mapperRepository, IMapperFavorite mapperFavorite)
        {
            _context = context;
            _gitHubApi = gitHubApi;
            _mapperRepository = mapperRepository;
            _mapperGitHubRepository = mapperGitHubRepository;
            _mapperFavorite = mapperFavorite;
        }

        public async Task<ActionResult<GitHubRepositoryViewModel>> GetAsync()
        {
            var repositories = await _gitHubApi.GetRepositoryAsync("diogocavassani");
            if (!repositories.IsValid)
            {
                return new ActionResult<GitHubRepositoryViewModel>()
                {
                    IsValid = repositories.IsValid,
                    Message = repositories.Message
                };
            }
            return new ActionResult<GitHubRepositoryViewModel>()
            {
                IsValid = repositories.IsValid,
                Message = repositories.Message,
                Results = _mapperGitHubRepository.MapperListGitHubRepositories(repositories.Results)
            };
        }

        public async Task<ActionResult<GitHubRepositoryViewModel>> GetById(long id)
        {
            var repository = await _gitHubApi.GetRepositoryIdAsync(id);
            if (!repository.IsValid)
            {
                return new ActionResult<GitHubRepositoryViewModel>()
                {
                    IsValid = repository.IsValid,
                    Message = repository.Message
                };
            }
            return new ActionResult<GitHubRepositoryViewModel>()
            {
                IsValid = repository.IsValid,
                Message = repository.Message,
                Result = _mapperGitHubRepository.MapperToViewModel(repository.Result)
            };
        }

        public async Task<ActionResult<RepositoryViewModel>> GetByName(string name)
        {
            var repository = await _gitHubApi.GetRepositoryByName(name);
            if (!repository.IsValid)
            {
                return new ActionResult<RepositoryViewModel>()
                {
                    IsValid = repository.IsValid,
                    Message = repository.Message
                };
            }
            return new ActionResult<RepositoryViewModel>()
            {
                IsValid = repository.IsValid,
                Message = repository.Message,
                Result = _mapperRepository.MapperToViewModel(repository.Result)
            };
        }

        public ActionResult<FavoriteViewModel> GetFavoriteRepository()
        {
            var response = _context.GetAll();
            if (response == null)
            {
                return new ActionResult<FavoriteViewModel>
                {
                    IsValid = false,
                    Message = "Ocorreu um erro na busca dos favoritos",
                };
            }
            if (response.Count > 0)
            {
                return new ActionResult<FavoriteViewModel>
                {
                    IsValid = true,
                    Message = "Ok",
                    Results = _mapperFavorite.MapperToListFavoriteViewModel(response)
                };
            }
            return new ActionResult<FavoriteViewModel>
            {
                IsValid = false,
                Message = "Não há repositórios favoritos",
                Results = _mapperFavorite.MapperToListFavoriteViewModel(response)
            };
        }

        public async Task<ActionResult<GitHubRepositoryViewModel>> GetRepository(string owner, long id)
        {
            var repository = await _gitHubApi.GetRepositoryIdAsync(id);
            if (!repository.IsValid)
            {
                return new ActionResult<GitHubRepositoryViewModel>()
                {
                    IsValid = repository.IsValid,
                    Message = repository.Message
                };
            }
            return new ActionResult<GitHubRepositoryViewModel>()
            {
                IsValid = repository.IsValid,
                Message = repository.Message,
                Result = _mapperGitHubRepository.MapperToViewModel(repository.Result)
            };
        }

        public ActionResult<FavoriteViewModel> SaveFavoriteRepository(FavoriteViewModel view)
        {
            if (_context.ExistsByCheckAlready(_mapperFavorite.MapperToFavorite(view)))
            {
                return new ActionResult<FavoriteViewModel>
                {
                    IsValid = false,
                    Message = "Esse repositório ja existe",
                };
            }
            if (_context.Insert(_mapperFavorite.MapperToFavorite(view)))
            {
                return new ActionResult<FavoriteViewModel>
                {
                    IsValid = true,
                    Message = "Ok"
                };
            }
            return new ActionResult<FavoriteViewModel>
            {
                IsValid = false,
                Message = "Ocorreu um erro ao salvar o repositório",
            };
        }
    }
}
