using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sinema.MVCUI.Identity
{
    public class SinemaIdentityDbContext : IdentityDbContext<SinemaUser>
    {
        public SinemaIdentityDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
