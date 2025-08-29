using System;
using FishNet.Connection;
using FishNet.Transporting;
using UnityEngine;

namespace WelwiseSharedModule.Runtime.Server.Scripts
{
    public class ClientsConnectionTrackingServiceForServer
    {
        public event Action<NetworkConnection> Disconnected, Connected;

        public void TryInvokeActionByConnectionState(NetworkConnection conn, RemoteConnectionStateArgs args)
        {
            if (args.ConnectionId == -1)
            {
                Debug.Log("EXX");
                return;
            }
            
            if (args.ConnectionState == RemoteConnectionState.Started)
                Connected?.Invoke(conn);
            else
                Disconnected?.Invoke(conn);
        }
    }
}