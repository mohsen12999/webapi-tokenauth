using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace webapi_tokenauth.Models
{
    public class Role: IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
