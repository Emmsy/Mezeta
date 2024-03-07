using Mezeta.Core.Models.User;
using Mezeta.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Core.Contracts
{
    public interface IUserService
    {
        Task CreateUser(RegisterModel model);

        Task<User> ReturnUser(LoginModel model);
    }
}
