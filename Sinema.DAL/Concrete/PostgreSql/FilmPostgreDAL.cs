using Sinema.Core.Concrete;
using Sinema.DAL.Abstract.PostgreSql;
using Sinema.DAL.Contexts;
using Sinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinema.DAL.Concrete.PostgreSql
{
    public class FilmPostgreDAL:RepositoryBase<Film,PostgreDbContext>,IFilmPorstgreDAL
    {
    }
}
