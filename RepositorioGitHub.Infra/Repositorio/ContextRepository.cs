using Newtonsoft.Json;
using RepositorioGitHub.Dominio;
using RepositorioGitHub.Infra.Contract;
using System;
using System.Collections.Generic;
using System.IO;

namespace RepositorioGitHub.Infra.Repositorio
{
    public class ContextRepository : IContextRepository
    {
        private readonly string _path = $"{AppDomain.CurrentDomain.BaseDirectory}Favorito.json";

        public bool ExistsByCheckAlready(Favorite favorite)
        {
            List<Favorite> favorites = GetAll();

            if (favorites == null)
            {
                return false;
            }
            if (favorites.Exists(f => f.Owner == favorite.Owner && f.Name == favorite.Name))
            {
                return true;
            }
            return false;
        }

        public List<Favorite> GetAll()
        {
            List<Favorite> favorites = new List<Favorite>();
            try
            {
                if (File.Exists(_path))
                {
                    using (TextReader tr = File.OpenText(_path))
                    {
                        string s;
                        while ((s = tr.ReadLine()) != null)
                        {
                            var result = JsonConvert.DeserializeObject<Favorite>(s);
                            favorites.Add(result);
                        }
                        return favorites;
                    }
                }
                using (StreamWriter sw = File.CreateText(_path))
                {
                    return favorites;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Insert(Favorite favorite)
        {
            try
            {
                if (!File.Exists(_path))
                {
                    using (StreamWriter sw = File.CreateText(_path))
                    {
                        var result = JsonConvert.SerializeObject(favorite);
                        sw.WriteLineAsync(result);
                        return true;
                    }
                }
                using (StreamWriter sw = new StreamWriter(_path, true))
                {
                    var result = JsonConvert.SerializeObject(favorite);
                    sw.WriteLineAsync(result);
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
