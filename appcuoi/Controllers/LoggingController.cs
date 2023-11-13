using appcuoi.Bussiness.DTOs;
using appcuoi.Bussiness.DTOs.Respond;
using appcuoi.Bussiness.IServices;
using appcuoi.Bussiness.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appcuoi.Controllers
{
    [Route("loggin/")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        IAuthenservice _authenservice;
        IUserService _userService;
        public LoggingController(IAuthenservice authenservice, IUserService userService)
        {
            _authenservice = authenservice;
            _userService = userService;
        }
        [HttpPost]
        [Route("loggin")]
        public async Task<IActionResult> loggin([FromBody] UserLoginDTO userLoginDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            UserLoginResondDTO userLoginResondDTO =await _authenservice.loginAsync(userLoginDTO);
            if(userLoginResondDTO == null)
            {
                return Unauthorized();
            }    
            return Ok(userLoginResondDTO);
            
            
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTOs userRegisterDTOs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            if (userRegisterDTOs.Password != userRegisterDTOs.ReInputPassword)
            {
                return BadRequest();
            }
            var userexist = _userService.GetAsync(userRegisterDTOs.Username);
            if (userexist != null)
            {
                return BadRequest();
            }    
            await _userService.AddAsync(userRegisterDTOs);



            return Ok("successfully");
        }

    }
}
