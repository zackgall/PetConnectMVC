using PetConnect.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace PetConnect.DAL
{
    public class PetInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<PetConnectDBContext>
    {
        protected override void Seed(PetConnectDBContext context)
        {
            context.Users.AddOrUpdate(x => x.Id,
                new User() { Id = 1, UserName = "stripes", NickName = "@StripesDaCat", Species = Species.Cat },
                new User() { Id = 2, UserName = "bailey", NickName = "@BaileyCute99", Species = Species.Cat },
                new User() { Id = 3, UserName = "reggie", NickName = "@Regmeister", Species = Species.Cat }
                );

            context.Chirps.AddOrUpdate(x => x.Id,
                new Chirps() { Id = 1, UserId = 1, Text = "Meowwww!!! I love treats!" },
                new Chirps() { Id = 2, UserId = 2, Text = "Meowwww!!! I love treats!" }
            );

            context.UserFriends.AddOrUpdate(x => x.Id,
                new UserFriends() { Id = 1, UserId = 1, FriendId = 2 },
                new UserFriends() { Id = 1, UserId = 1, FriendId = 3 },
                new UserFriends() { Id = 1, UserId = 2, FriendId = 1 },
                new UserFriends() { Id = 1, UserId = 2, FriendId = 3 },
                new UserFriends() { Id = 1, UserId = 3, FriendId = 1 },
                new UserFriends() { Id = 1, UserId = 3, FriendId = 2 }
                );
        }
    }
}