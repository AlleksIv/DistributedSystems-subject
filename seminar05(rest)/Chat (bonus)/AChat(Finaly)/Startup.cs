using Microsoft.Owin;
using Owin;
using Alachisoft.NCache.SignalR;
using Microsoft.AspNet.SignalR;
using System.Configuration;

[assembly: OwinStartup(typeof(AChat_Finaly_.Startup))]

namespace AChat_Finaly_
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
