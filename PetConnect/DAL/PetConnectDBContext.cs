using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PetConnect.Models;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace PetConnect.DAL
{
    public class PetConnectDBContext : DbContext
    {
        public PetConnectDBContext() : base ("PetConnectDBContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Chirps> Chirps { get; set; }
        public DbSet<UserFriends> UserFriends { get; set; }

    }
}