using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Extensions;
using API.Identity;
using API.Models;
using AutoMapper;
using Core.Common;
using Core.Entities.Identity;
using Core.Infrastructure.ErrorHandler;

using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IConfiguration _config;
        private readonly RoleManager<IdentityRole> _roleManager;

        public TokenOption TokenOption { get; set; }
        private readonly IErrorHandler _errorHandler;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService, IMapper mapper,
            RoleManager<IdentityRole> roleManager,
            IErrorHandler errorHandler, IConfiguration config

)
        {

            _mapper = mapper;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
            _errorHandler = errorHandler;
            _roleManager = roleManager;
            _config = config;
        }

        //[Authorize]
        //[HttpGet]
        //public async Task<ActionResult<UserDto>> GetCurrentUser()
        //{
        //    var user = await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);

        //    return new UserDto
        //    {
        //        Email = user.Email,
        //        Token = _tokenService.CreateToken(user),
        //        DisplayName = user.DisplayName
        //    };
        //}

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;

        }

        //[Authorize]
        //[HttpGet("address")]
        //public async Task<ActionResult<AddressDto>> GetUserAddress()
        //{
        //    var user = await _userManager.FindByUserByClaimsPrincipleWithAddressAsync(HttpContext.User);

        //    return _mapper.Map<Address, AddressDto>(user.Address);
        //}

        //[Authorize]
        //[HttpPut("address")]
        //public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto address)
        //{
        //    var user = await _userManager.FindByUserByClaimsPrincipleWithAddressAsync(HttpContext.User);

        //    user.Address = _mapper.Map<AddressDto, Address>(address);

        //    var result = await _userManager.UpdateAsync(user);

        //    if (result.Succeeded) return Ok(_mapper.Map<Address, AddressDto>(user.Address));

        //    return BadRequest("Problem updating the user");
        //}


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                    var aspNetUser = await _userManager.FindByEmailAsync(model.UserName);
                    var role = await _userManager.GetRolesAsync(aspNetUser);
                    var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.UserName);
                    TokenOption = new TokenOption();
                    TokenOption.Issuer = _config["TokenOption:Issuer"];
                    TokenOption.Audience = _config["TokenOption:Audience"];
                    TokenOption.Key = _config["TokenOption:Key"];
                    var expiry = _config["TokenOption:ExpireMinutes"];
                    TokenOption.ExpireMinutes = Convert.ToInt32(expiry);
                    return Ok(Identity.Security.GenerateJwtToken(model.UserName, aspNetUser, TokenOption, role.FirstOrDefault()));
                }
                else
                {
                    return Unauthorized(new ErrorResponseModel { Code = (int)HttpStatusCode.Unauthorized, Message = _errorHandler.GetMessage(ErrorMessagesEnum.AuthWrongCredentials) });
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (CheckEmailExistsAsync(registerDto.Email).Result.Value)
                {
                    return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = new[] { "Email address is in use" } });
                }
                ApplicationUser _applicationUser = new ApplicationUser
                {

                    Email = registerDto.Email,
                    UserName = registerDto.Email,
                    NormalizedUserName = registerDto.Email.ToUpper(),
                    NormalizedEmail = registerDto.Email.ToUpper(),
                    PasswordHash = Utility.GenerateRandomPassword()

                };
                var result = await _userManager.CreateAsync(_applicationUser, registerDto.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(_applicationUser, Enums.ApplicationRole.User.ToString());
                }
                if (!result.Succeeded)
                {
                    return BadRequest(new { message = result.Errors.Select(a => a.Description) });
                }

                return Ok(result.Succeeded);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}