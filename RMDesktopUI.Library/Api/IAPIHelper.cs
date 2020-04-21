using RMDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api
{
    /// <summary>
    /// Implements an contract that ever APIHelper Should implement in order to make HTPP requests for our api.
    /// </summary>
    /// <param name="username">The username</param>
    /// <param name="password">The Password</param>
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);

        Task GetLoggedInUserInfo(string token);
    }
}