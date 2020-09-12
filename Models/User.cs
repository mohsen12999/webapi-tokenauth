using System;
using Microsoft.AspNetCore.Identity;

namespace webapi_tokenauth.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Role Role { get; set; }
    }
}
