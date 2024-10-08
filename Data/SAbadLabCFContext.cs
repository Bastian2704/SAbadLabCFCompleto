using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAbadLabCF.Models;

namespace SAbadLabCF.Data
{
    public class SAbadLabCFContext : DbContext
    {
        public SAbadLabCFContext (DbContextOptions<SAbadLabCFContext> options)
            : base(options)
        {
        }

        public DbSet<SAbadLabCF.Models.Burguers> Burguers { get; set; } = default!;
    }
}
