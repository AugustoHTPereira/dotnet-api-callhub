using Callhub.Application.ViewModels;

namespace Callhub.Application.Interfaces
{
    public interface ITokenService
    {
        TokenViewModel Generate(UserViewModel Model);
    }
}
