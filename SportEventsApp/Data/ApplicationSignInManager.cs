using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace SportEventsApp.Data
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationSignInManager(
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<ApplicationUser>> logger,
            IAuthenticationSchemeProvider schemes,
            IUserConfirmation<ApplicationUser> confirmation)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
            _userManager = userManager;
        }

        public override async Task<SignInResult> PasswordSignInAsync(
            string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            
            var result = await base.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user.BlockDate != null)
                {
                    return SignInResult.NotAllowed;
                }
                if (user != null)
                {
                    user.LastLoggedTime = DateTime.Now;
                    await _userManager.UpdateAsync(user);
                }
            }

            return result;
        }
    }
}
