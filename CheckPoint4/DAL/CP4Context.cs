using CheckPoint4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CheckPoint4.DAL
{
    public class CP4Context : DbContext
    {
        public CP4Context() : base("CP4Context")
        {

        }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Client> Clients { get; set; }

    }
}