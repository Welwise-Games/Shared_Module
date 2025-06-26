using System;
using FishNet.Connection;
using FishNet.Object;

namespace MainHub.Client.Scripts.Systems.PlayerSystem
{
    public class NetworkBehaviourObserver : NetworkBehaviour
    {
        public event Action<NetworkConnection> OnSpawnedServer;
        
        public override void OnSpawnServer(NetworkConnection connection)
        {
            OnSpawnedServer?.Invoke(connection);
            base.OnSpawnServer(connection);
        }
    }
}