using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(W2022A6AZB.Startup))]

namespace W2022A6AZB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
