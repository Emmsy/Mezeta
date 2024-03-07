using Mezeta.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Core.Models.User
{
    public class RegisterModel
    {

        [StringLength(100, ErrorMessage = UserMessage.EmailLengthError, MinimumLength = 8)]
        public string Email { get; set; } = null!;

        [StringLength(300, ErrorMessage = UserMessage.PaswordLengthError, MinimumLength = 8)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password), ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
