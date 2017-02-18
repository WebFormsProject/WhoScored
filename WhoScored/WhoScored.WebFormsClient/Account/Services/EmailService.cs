using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace WhoScored.WebFormsClient.Account.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }
}