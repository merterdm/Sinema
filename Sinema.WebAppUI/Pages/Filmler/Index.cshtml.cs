using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sinema.DAL.Abstract.PostgreSql;
using Sinema.Entities.Concrete;

namespace Sinema.WebAppUI.Pages.Filmler
{
    public class IndexModel : PageModel
    {
        private readonly IFilmPorstgreDAL postgreDAL;

        public IList<Film> Filmler { get; set; }

        public IndexModel(IFilmPorstgreDAL postgreDAL)
        {
            this.postgreDAL = postgreDAL;
        }
        public async Task  OnGet()
        {
            Filmler = await postgreDAL.FindAllAsnyc(null);

        }
       
    }
}
