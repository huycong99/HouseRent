using appcuoi.Bussiness.DTOs.Request;
using appcuoi.Bussiness.IServices;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.JsonPatch;

using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace appcuoi.Controllers
{
    [Route("house/")]
    [ApiController]
    public class HouseController : Controller
    {
        IUserService _userService;
        IHouseService _houseService;
        public HouseController(IUserService userService, IHouseService houseService)
        {
            _userService = userService;
            _houseService = houseService;
        }
        [HttpPost]
        [Route("AddHouse")]
        [Authorize(Roles = "Landlord")]
        [Authorize(Roles = "Active")]
        public async Task<IActionResult> Addhouse([FromBody] HouseDTOs houseDTOs)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jwtToken = Request.Headers["Authorization"];
            var handler = new JwtSecurityTokenHandler();
            var jwtTokenString = jwtToken.ToString().Substring(7);

            var TokenDecoded = handler.ReadJwtToken(jwtTokenString);
            var username = TokenDecoded.Claims.First(c => c.Type == ClaimTypes.Name).Value;
            var user = await _userService.GetAsync(username);
            await _houseService.Addasync(houseDTOs, user.UserId);

            return Ok("successfully");
        }
        [HttpGet]
        [Route("FindAllHouse")]
        public async Task<IActionResult> FindAllHouse()
        {
            var list = await _houseService.FindAllAsync();
            return Ok(list);
        }
        [HttpGet]
        [Route("Find/{landlordname}")]
        public async Task<IActionResult> FindByName([FromRoute] string landlordname)
        {
            var list = await _houseService.FindByStreetAsync(landlordname);
            return Ok(list);
        }
        [HttpGet]
        [Route("Find/{districtname}")]
        public async Task<IActionResult> FindByDistrict([FromRoute] string districtname)
        {
            var list = await _houseService.FindByDistrictAsync(districtname);
            return Ok(list);
        }
        [HttpGet]
        [Route("Find/{wardname}")]
        public async Task<IActionResult> FindByWard([FromRoute] string wardname)
        {
            var list = await _houseService.FindByWardAsync(wardname);
            return Ok(list);
        }
        [HttpGet]
        [Route("Find/{streetname}")]
        public async Task<IActionResult> FindByStreet([FromRoute] string streetname)
        {
            var list = await _houseService.FindByStreetAsync(streetname);
            return Ok(list);
        }
        [HttpPatch]
        [Route("Update/{houseId}")]
        [Authorize(Roles ="Landlord")]
        
        public async Task<IActionResult> Updatehouse([FromBody] Microsoft.AspNetCore.JsonPatch.JsonPatchDocument houseupdate, [FromRoute] int houseId)
        {
            var jwtToken = Request.Headers["Authorization"];
            var handler = new JwtSecurityTokenHandler();
            var jwtTokenString = jwtToken.ToString().Substring(7);

            var TokenDecoded = handler.ReadJwtToken(jwtTokenString);
            var username = TokenDecoded.Claims.First(c => c.Type == ClaimTypes.Name).Value;
            
            var result = await _houseService.UpdateAsync(houseupdate, houseId,username);
            return Ok(result);

        }



    }
}
