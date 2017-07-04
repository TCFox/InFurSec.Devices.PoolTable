using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using Windows.ApplicationModel.Background;
using IotWeb.Server;
using IotWeb.Common.Util;
using IotWeb.Common.Http;
using System.Reflection;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace InFurSec.Devices.PoolTable
{
    public sealed class StartupTask : IBackgroundTask
    {
        private BackgroundTaskDeferral deferral;
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // Get deferral, so the task doesn't just immediately exit
            deferral = taskInstance.GetDeferral();

            HttpServer server = new HttpServer(8040);
            server.AddHttpRequestHandler(
                "/",
                new HttpResourceHandler(
                    typeof(StartupTask).GetTypeInfo().Assembly, // Utilities.GetContainingAssembly(typeof(StartupTask)),
                    "wwwroot",
                    "index.html"
                )
            );
            server.AddWebSocketRequestHandler(
                "/sockets/",
                new WebSocketHandler()
            );

            server.Start();
        }
    }
}
