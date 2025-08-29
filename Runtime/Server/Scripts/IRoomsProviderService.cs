using System;
using System.Collections.Generic;
using FishNet.Connection;

namespace WelwiseSharedModule.Runtime.Server.Scripts
{
    public interface IRoomsProviderService
    {
        IReadOnlyDictionary<NetworkConnection, IRoom> RoomsByConnectedClientsNetworkConnections { get; }
        event Action<IRoom> RemovedRoom, AddedRoom;
        event Action<NetworkConnection, IRoom> ConnectedClientToRoom, DisconnectedClientFromRoom;
        void AddRoom(IRoom room);
        void RemoveRoom(IRoom room);
        void TryRemovingClientFromRoom(NetworkConnection networkConnection);
    }
}