using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(atAcc.Startup))]
namespace atAcc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
