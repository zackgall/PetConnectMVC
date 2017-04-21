using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetConnect.Models
{
    public class UserFriends
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }

        public virtual User User { get; set; }
    }
}