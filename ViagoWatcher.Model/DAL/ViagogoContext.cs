using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagogoWatcher.Model.Alerts;

namespace ViagogoWatcher.Model.DAL
{
    public class ViagogoContext:DbContext
    {
        public ViagogoContext():base("ViagogoContext")
        {
            
        }

        public DbSet<Alert> Alerts { get; set; }


    }
}
