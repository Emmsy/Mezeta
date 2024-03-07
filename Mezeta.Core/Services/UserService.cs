using Mezeta.Core.Contracts;
using Mezeta.Core.Models.User;
using Mezeta.Infrastructure.Data.Entities;
using Mezeta.Infrastrucute.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext data;

        public UserService(ApplicationDbContext _data)
        {
            data = _data;
        }

        public async Task CreateUser(RegisterModel model)
        {

            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName=model.Email,
                EmailConfirmed=true,
                Email = model.Email,
                Favorites = new List<Recipe>(),
                Prepairing = new List<RecipePrepairing>(),
            };
            var passwordHash = new PasswordHasher<User>().HashPassword(user, model.Password);
            user.PasswordHash = passwordHash;
            await data.Users.AddAsync(user);
            await data.SaveChangesAsync();

        }

        public async Task<User> ReturnUser(LoginModel model)
        {
            var user = await data.Users.Where(d => d.Email == model.Email).FirstOrDefaultAsync();
          
            return user;
        }


    }
}
