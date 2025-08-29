using System;
using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Managing.Scened;

namespace WelwiseSharedModule.Runtime.Server.Scripts
{
    public interface IRoom
    {
        IReadOnlyCollection<NetworkConnection> ConnectedClientsNetworkConnections { get; }
        SceneLoadData SceneLoadData { get; }
        event Action<NetworkConnection> ConnectedClient, DisconnectedClient;
        void AddConnectedClient(NetworkConnection networkConnection);
        void RemoveConnectedClient(NetworkConnection networkConnection);
    }
}