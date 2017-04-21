using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Collections;

namespace PetConnect.Models
{
    public enum Species
    {
        Cat, Dog, Bird, Rabbit, Duck
    }

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string ProfilePicUrl { get; set; }
        public Species? Species { get; set; }

        public List<Chirps> Chirps { get; set; }
        public ICollection<UserFriends> Friends { get; set; }
    }
}