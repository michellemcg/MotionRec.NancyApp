using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MotionRec.NancyApp.Models;

namespace MotionRec.NancyApp.DAL
{
    public class NancyAppContext : DbContext
    {
        public DbSet<User> User { get; set; }
    }
}
