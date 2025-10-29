using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Users
{
    public class ApplicationUser : IdentityUser
    {
        public string FristName { get; set; } = null!;

        public string LastName { get; set; } = null!;
    }
}
