using Microsoft.AspNetCore.Identity;

namespace Sinema.MVCUI.Identity
{
    public class SinemaUser:IdentityUser
    {
        public string TcNo { get; set; }

    }
}
