using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace WhoScored.MVP.Models.Auth
{
    public class ManagePasswordViewModel
    {
        public bool HasPassword { get; set; }

        public SignInStatus SignInStatus { get; set; }

        public IdentityResult IdentityResult { get; set; }
    }
}
