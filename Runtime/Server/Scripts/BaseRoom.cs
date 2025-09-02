using System;
using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Managing.Scened;
using UnityEngine;
using WelwiseSharedModule.Runtime.Shared.Scripts.Tools;

namespace WelwiseSharedModule.Runtime.Server.Scripts
{
    public abstract class BaseRoom : IRoom
    {
        public IReadOnlyCollection<NetworkConnection> ConnectedClientsNetworkConnections =>
            _connectedClientsNetworkConnections;
        public SceneLoadData SceneLoadData { get; }
        public int PeopleCount => _connectedClientsNetworkConnections.Count;

        public event Action<NetworkConnection> ConnectedClient, DisconnectedClient;
        
        private readonly HashSet<NetworkConnection> _connectedClientsNetworkConnections =
            new HashSet<NetworkConnection>();

        protected BaseRoom(SceneLoadData sceneLoadData)
        {
            SceneLoadData = sceneLoadData;
        }

        public void AddConnectedClient(NetworkConnection conn)
        {
            if (_connectedClientsNetworkConnections.Add(conn))
                ConnectedClient?.Invoke(conn);
        }

        public void RemoveConnectedClient(NetworkConnection conn)
        {
            if (_connectedClientsNetworkConnections.Remove(conn))
            {
                DisconnectedClient?.Invoke(conn);
            }
        }
    }
}