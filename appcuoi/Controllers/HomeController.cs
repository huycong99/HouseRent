using appcuoi.Bussiness.DTOs;
using appcuoi.Bussiness.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace appcuoi.Controllers
{
    [Route("home/")]
    [ApiController]
    [Authorize(Roles ="Active")]
    
    public class HomeController : Controller
    {

        IUserService _userService;
        
        public HomeController(IUserService userService)
        {
            
            _userService = userService;
        }


        [Authorize(Roles ="Admin")]
        [Route("ShowAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _userService.GetAllAsync();

            return Ok(list);
        }




        [Authorize(Roles = "Admin")]
        [Route("ShowAllInactive")]
        public async Task<IActionResult> GetAllInactive()
        {
            var list = await _userService.GetInactiveAsync();
            return Ok(list);
        }

        [HttpPatch]
        [Authorize(Roles = "Admin")]
        [Route("Active/{username}")]
        public async Task<IActionResult> ActiveUser([FromBody] Microsoft.AspNetCore.JsonPatch.JsonPatchDocument useractive,[FromRoute] string username)
        {
            var result = await _userService.ActiveUserAsync(useractive,username);
            return Ok(result);
        }



        [HttpPost]        
        
        [Authorize(Roles = "Admin")]
        [Route("Delete/{username}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string username)
        {
            var result = await _userService.DeleteAsync(username);
            return Ok(result);

        }
        [Route("MyProfile/")]
        public async Task<IActionResult> GetMyProfile()
        {
            var jwtToken = Request.Headers["Authorization"];
            var handler = new JwtSecurityTokenHandler();
            var jwtTokenString = jwtToken.ToString().Substring(7);
            
            var TokenDecoded = handler.ReadJwtToken(jwtTokenString);
            var username =TokenDecoded.Claims.First(c=>c.Type==ClaimTypes.Name).Value;
            var user = await _userService.GetAsync(username);
            return Ok(user);

        }






        [Authorize(Roles ="Admin,Student,Landlord")]
        [Route("{username}")]
        public async Task<IActionResult> GetUserName([FromRoute] string username)
        {
            var user = await _userService.GetAsync(username);
            return Ok(user);
        }
        
    }
}
