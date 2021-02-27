using RepositorioGitHub.Dominio;
using System.Collections.Generic;

namespace RepositoriosGitHub.Infra.CrossCutting.Adapter.Interfaces
{
    public interface IMapperFavorite
    {
        Favorite MapperToFavorite(FavoriteViewModel favoriteViewModel);
        List<FavoriteViewModel> MapperToListFavoriteViewModel(List<Favorite> favortes);
    }
}
