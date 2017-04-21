using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetConnect.Models
{
    public class Chirps
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int Liked { get; set; }

        public virtual User User { get; set; }
    }
}