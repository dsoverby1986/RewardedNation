using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RewardedNation.Startup))]
namespace RewardedNation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
