using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {

            if (!builder.IsConfigured)
                builder.UseSqlServer(Configuration.ConnectionString);
        }
    }
}
