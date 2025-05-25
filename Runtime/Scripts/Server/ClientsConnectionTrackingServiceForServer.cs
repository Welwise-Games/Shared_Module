using System;
using FishNet.Connection;
using FishNet.Transporting;

namespace MainHub.Server.Scripts.Infrastructure.Services
{
    public class ClientsConnectionTrackingServiceForServer
    {
        public event Action<NetworkConnection> Disconnected, Connected;

        public void TryInvokeActionByConnectionState(NetworkConnection conn, RemoteConnectionStateArgs args)
        {
            if (args.ConnectionId == -1)
                return;
            
            if (args.ConnectionState == RemoteConnectionState.Started)
                Connected?.Invoke(conn);
            else
                Disconnected?.Invoke(conn);
        }
    }
}