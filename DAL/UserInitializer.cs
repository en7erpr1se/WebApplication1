using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class UserInitializer : DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var groups = new List<Group>
            {
                new Models.Group {Name="administrator" },
                new Models.Group {Name="moderator" },
                new Models.Group {Name="client" },
            };
            groups.ForEach(s => context.Group.Add(s));
            context.SaveChanges();

            var users = new List<User>
            {
                new Models.User {FirstName="Petr",LastName="Petrov",Age=25,GroupId=1 },
                new Models.User  {FirstName="Ivan",LastName="PIvanov",Age=66,GroupId=2 },
                new Models.User  {FirstName="Jeka",LastName="Petrovich",Age=3,GroupId=3  },
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
        }
        }
}