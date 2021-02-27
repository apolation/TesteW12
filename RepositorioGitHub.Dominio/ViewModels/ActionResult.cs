using System.Collections.Generic;

namespace RepositorioGitHub.Dominio
{
    public class ActionResult<TModel> where TModel : class
    {
        public ActionResult()
        {

        }

        public bool IsValid { get; set; }
        public string Message { get; set; }
        public IList<TModel> Results { get; set; }

        public TModel Result { get; set; }
    }
}
