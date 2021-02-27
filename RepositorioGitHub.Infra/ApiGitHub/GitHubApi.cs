using Newtonsoft.Json;
using RepositorioGitHub.Dominio;
using RepositorioGitHub.Dominio.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RepositorioGitHub.Infra.ApiGitHub
{
    public class GitHubApi : IGitHubApi
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;


        public GitHubApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Awesome-Octocat-App");
            _apiUrl = "https://api.github.com/";
        }

        public async Task<ActionResult<GitHubRepository>> GetRepositoryAsync(string owner)
        {
            var _actionResult = new ActionResult<GitHubRepository>();

            using (var response = await _httpClient.GetAsync($"{_apiUrl}users/{owner}/repos"))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return new ActionResult<GitHubRepository>()
                    {
                        IsValid = false,
                        Message = response.ReasonPhrase
                    };
                }
                var apiResposta = await response.Content.ReadAsStringAsync();
                _actionResult.Results = JsonConvert.DeserializeObject<IList<GitHubRepository>>(apiResposta);
                _actionResult.IsValid = true;
                _actionResult.Message = response.ReasonPhrase;
            }
            return _actionResult;
        }

        public async Task<ActionResult<RepositoryModel>> GetRepositoryByName(string name)
        {
            var _actionResult = new ActionResult<RepositoryModel>();

            using (var response = await _httpClient.GetAsync($"{_apiUrl}search/repositories?q={name}"))
            {

                if (!response.IsSuccessStatusCode)
                {
                    return new ActionResult<RepositoryModel>()
                    {
                        IsValid = false,
                        Message = response.ReasonPhrase
                    };
                }
                var apiResposta = await response.Content.ReadAsStringAsync();
                _actionResult.Result = JsonConvert.DeserializeObject<RepositoryModel>(apiResposta);
                _actionResult.IsValid = true;
                if (_actionResult.Result.TotalCount > 0)
                {
                    _actionResult.Message = response.ReasonPhrase;
                }
                else
                {
                    _actionResult.Message = "Não existe repositórios com esse nome";
                }
            }
            return _actionResult;
        }

        public async Task<ActionResult<GitHubRepository>> GetRepositoryIdAsync(long id)
        {
            var _actionResult = new ActionResult<GitHubRepository>();

            using (var response = await _httpClient.GetAsync($"{_apiUrl}repositories/{id}"))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return new ActionResult<GitHubRepository>()
                    {
                        IsValid = false,
                        Message = response.ReasonPhrase
                    };
                }
                var apiResposta = await response.Content.ReadAsStringAsync();
                _actionResult.Result = JsonConvert.DeserializeObject<GitHubRepository>(apiResposta);
                _actionResult.IsValid = true;
                _actionResult.Message = response.ReasonPhrase;
            }
            return _actionResult;
        }
    }
}
