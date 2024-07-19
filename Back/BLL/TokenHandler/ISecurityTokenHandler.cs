using System.Security.Claims;

namespace BLL.TokenHandler
{
    public interface ISecurityTokenHandler
    {
        string CreateToken(IEnumerable<Claim> claims);
    }
}
