using Sinema.Core.Abstract;
using Sinema.DAL.Contexts;
using Sinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinema.DAL.Abstract.PostgreSql
{
    public interface IFilmPorstgreDAL:IRepositoryBase<Film,PostgreDbContext>
    {
    }
}
