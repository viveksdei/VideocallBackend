using System.Security.Claims;

namespace Core.App.Common.Interfaces
{
    public interface IReadClaimsToken
    {
        IEnumerable<Claim> GetUserClaimsDetails(string Token);
    }
}