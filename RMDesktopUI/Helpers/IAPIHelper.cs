using RMDesktopUI.Models;
using System.Threading.Tasks;

namespace RMDesktopUI.Helpers
{
    /// <summary>
    /// Implements an contract that ever APIHelper Should implement in order to make HTPP requests for our api.
    /// </summary>
    /// <param name="username">The username</param>
    /// <param name="password">The Password</param>
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}