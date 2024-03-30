using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrintManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Infrastructure.DataContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {



        public async Task<int> CommitChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<TEntity> SetEntity<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
