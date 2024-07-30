﻿using Microsoft.AspNetCore.Identity;

namespace Vimenpaq.Infrastructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
