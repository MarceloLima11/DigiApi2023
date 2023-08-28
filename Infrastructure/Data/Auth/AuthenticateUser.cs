using Core.Interfaces.Auth;
using Infrastructure.Data.Context;

namespace Infrastructure.Data.Auth
{
    public class AuthenticateUser : IAuthenticateUser
    {
        private readonly ApplicationDbContext _context;
        public AuthenticateUser(ApplicationDbContext context)
        { _context = context; }

        public bool IsDeveloperAuthorized(string developerId)
        {
            var resultdebug = _context.AuthorizedDevelopers.Any(x => x.NickName == developerId);

            return resultdebug;
        }
    }
}