using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(P_K_payment.Startup))]
namespace P_K_payment
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
