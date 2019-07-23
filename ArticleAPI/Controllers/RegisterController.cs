using System;
using System.Transactions;
using ArticleAPI.DAL.Models;
using ArticleAPI.DAL.Repositories.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ArticleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly Logger.Logger _logger;

        public RegisterController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _logger = new Logger.Logger($"{_configuration.GetSection("Logging").GetSection("LogPath").Value}",
                Convert.ToInt32(_configuration.GetSection("Logging").GetSection("LogLevel").Value));
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

                    scope.Complete();
                }

                return Ok(new { result = true, message =  "Yeni user eklendi." });
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString(), Logger.LogType.Error);
                return Ok(new { result = false, message = ex.Message });
            }
        }
    }
}