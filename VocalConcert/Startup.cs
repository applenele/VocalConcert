using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using CodeComb.Yuuko;

[assembly: OwinStartup(typeof(VocalConcert.Startup))]

namespace VocalConcert
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapYuuko(); //调用Yuuko框架
        }
    }
}
