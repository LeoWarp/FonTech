using System.Security.Claims;
using FonTech.Domain.Dto;
using FonTech.Domain.Result;

namespace FonTech.Domain.Interfaces.Services;

public interface ITokenService
{
    string GenerateAccessToken(IEnumerable<Claim> claims);

    string GenerateRefreshToken();

    ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken);
    
    Task<BaseResult<TokenDto>> RefreshToken(TokenDto dto);
}