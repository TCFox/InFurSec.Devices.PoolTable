using IotWeb.Common.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InFurSec.Devices.PoolTable
{
    class WebSocketHandler : IWebSocketRequestHandler
    {
        public bool WillAcceptRequest(string uri, string protocol)
        {
            return (uri.Length == 0) && (protocol == "echo");
        }

        public void Connected(WebSocket socket)
        {
            socket.DataReceived += OnDataReceived;
        }

        void OnDataReceived(WebSocket socket, string frame)
        {
            socket.Send(frame);
        }
    }
}
