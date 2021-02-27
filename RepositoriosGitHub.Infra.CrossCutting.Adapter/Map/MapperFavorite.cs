using RepositorioGitHub.Dominio;
using RepositoriosGitHub.Infra.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace RepositoriosGitHub.Infra.CrossCutting.Adapter.Map
{
    public class MapperFavorite : IMapperFavorite
    {
        List<FavoriteViewModel> favoritesViewModel = new List<FavoriteViewModel>();
        public Favorite MapperToFavorite(FavoriteViewModel favoriteViewModel)
        {
            Favorite favorite = new Favorite
            {
                Description = favoriteViewModel.Description,
                Id = favoriteViewModel.Id,
                Language = favoriteViewModel.Language,
                Name = favoriteViewModel.Name,
                Owner = favoriteViewModel.Owner,
                UpdateLast = favoriteViewModel.UpdateLast
            };
            return favorite;
        }

        public List<FavoriteViewModel> MapperToListFavoriteViewModel(List<Favorite> favortes)
        {
            foreach (var favorite in favortes)
            {
                FavoriteViewModel favoriteViewModel = new FavoriteViewModel
                {
                    Description = favorite.Description,
                    Id = favorite.Id,
                    Language = favorite.Language,
                    Name = favorite.Name,
                    Owner = favorite.Owner,
                    UpdateLast = favorite.UpdateLast
                };
                favoritesViewModel.Add(favoriteViewModel);
            }
            return favoritesViewModel;
        }
    }
}
