using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcCore.Models
{
    public class MvcCoreContext : DbContext
    {
        public MvcCoreContext (DbContextOptions<MvcCoreContext> options)
            : base(options)
        {
        }

        public DbSet<MvcCore.Models.UserViewModel> UserViewModel { get; set; }
    }
}
