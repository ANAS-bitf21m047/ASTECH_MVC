using Microsoft.AspNetCore.Identity;

namespace OKTECH.Models
{
    public class MyUsers : IdentityUser
    {
        public string FullName { get; set; }
    }
}
