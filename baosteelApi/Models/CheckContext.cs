using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace baosteelApi.Models
{
    public class CheckContext : DbContext
    {
        public CheckContext(DbContextOptions<CheckContext> options)
            : base(options)
        {
        }

        public DbSet<MaintenanceItem> MAINTENANCE_ITEMS { get; set; }
        public DbSet<InfoItem> INFO_ITEMS { get; set; }
    }
}
