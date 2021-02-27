using RepositorioGitHub.Dominio;
using System.Collections.Generic;

namespace RepositorioGitHub.Infra.Contract
{
    public interface IContextRepository
    {
        bool Insert(Favorite favorite);
        List<Favorite> GetAll();
        bool ExistsByCheckAlready(Favorite favorite);

    }
}
