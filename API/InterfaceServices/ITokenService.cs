using API.Entities;

namespace API.InterfaceServices
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
