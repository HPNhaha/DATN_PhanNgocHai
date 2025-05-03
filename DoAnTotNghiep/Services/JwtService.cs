namespace DoAnTotNghiep.Services
{
    using DoAnTotNghiep.Data;
    using DoAnTotNghiep.Models;
    using DoAnTotNghiep.Models.API;
    using Microsoft.AspNetCore.Http.HttpResults;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class JwtService
    {
        private readonly RestaurantContext _hospitalContext;
        private readonly IConfiguration _configuaration;

        public JwtService(RestaurantContext hospitalContext, IConfiguration configuaration)
        {
            _hospitalContext = hospitalContext;
            _configuaration = configuaration;
        }
        public async Task<LoginResponseModel> Authenticate(LoginRequestModel req)
        {
            if (string.IsNullOrWhiteSpace(req.userName) || string.IsNullOrWhiteSpace(req.password))
            {
                return new LoginResponseModel
                {
                    success = false,
                    message = "ban can nhap username va password"
                }; 
            }
            var Account = await _hospitalContext.Accounts.FirstOrDefaultAsync(x => x.userName == req.userName);
            if(Account != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,_configuaration["JwtConfig:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim("userName",req.userName.ToString()),
                    new Claim(ClaimTypes.Role,Account.role.ToString())
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuaration["JwtConfig:Key"]));
                var tokenValidityMins = _configuaration.GetValue<int>("JwtConfig:TokenValidityMins");
                var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(tokenValidityMins);
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _configuaration["JwtConfig:Issuer"],
                    _configuaration["JwtConfig:Audience"],
                    claims,
                    expires: tokenExpiryTimeStamp,
                    signingCredentials: signIn
                    );

                string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                return new LoginResponseModel
                {
                    success = true,
                    message = "dang nhap thanh cong",
                    accessToken = tokenValue,
                    userName = req.userName,
                    expiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.UtcNow).TotalSeconds
                };

            }
            return new LoginResponseModel
            {
                success = false,
                message = "dang nhap that bai"
            };
            
        }
       
    }
}
