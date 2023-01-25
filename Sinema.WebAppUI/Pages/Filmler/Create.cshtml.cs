using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sinema.DAL.Abstract.PostgreSql;
using Sinema.Entities.Concrete;
namespace Sinema.WebAppUI.Pages.Filmler
{
    public class CreateModel : PageModel
    {
        private readonly IFilmPorstgreDAL postgreDAL;

       
        public CreateModel(IFilmPorstgreDAL postgreDAL)
        {
            this.postgreDAL = postgreDAL;
        }

        public async Task OnGet()
        {
         

        }
        public void OnPost() 
        { 
        
        }
    }
}
