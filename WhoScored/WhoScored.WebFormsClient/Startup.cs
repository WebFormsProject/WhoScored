using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhoScored.WebFormsClient.Startup))]
namespace WhoScored.WebFormsClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
