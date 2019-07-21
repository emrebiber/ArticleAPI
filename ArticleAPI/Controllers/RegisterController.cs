using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using ArticleAPI.DAL.Models;
using ArticleAPI.DAL.Repositories.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;

namespace ArticleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public RegisterController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(User user)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var salt = Salt.Create();
                    
                    user.Salt = salt;
                    user.IsActive = true;
                    user.IsDeleted = false;
                    user.CreatedDate = DateTime.Now;
                    user.Password = Salt.Create(user.Password, salt);
                    user.ActivationGuid = Guid.NewGuid().ToString();

                    _userRepository.AddUser(user);
                    var toList = new List<string> {user.Email};

                    scope.Complete();
                }

                return Ok(new { result = true });
            }
            catch (Exception ex)
            {
                return Ok(new { result = false, message = ex.Message });
            }
        }
    }
}