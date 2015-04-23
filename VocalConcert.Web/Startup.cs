using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VocalConcert.Web.Startup))]
namespace VocalConcert.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
        }
    }
}
