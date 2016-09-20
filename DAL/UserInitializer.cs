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
            var roles = new List<Role>
            {
                new Models.Role {Name="administrator" },
                new Models.Role {Name="notarius" },
                new Models.Role {Name="client" },
            };
            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();
            var addresses = new List<Address>
            {
                new Models.Address {Country="Russia",Region="Krum",City="Simferopol", Street="Lenina 12",ZipCode=89877},
            };
            addresses.ForEach(s => context.Addresses.Add(s));
            context.SaveChanges();
            var users = new List<User>
            {
                new Models.User {FirstName="Petr",LastName="Petrov",RoleId=1, Phone="79780001110", Email="Petriv@mail.ru",AddressId=1},
                new Models.User  {FirstName="Ivan",LastName="PIvanov",RoleId=2, Phone="79780001133", Email="PIvanov@mail.ru",AddressId=1},
                new Models.User  {FirstName="Jeka",LastName="Petrovich",RoleId=3, Phone="79780001155", Email="Petrovich@mail.ru",AddressId=1},
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();    
        }
        }
}