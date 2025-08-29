using System.Collections.Generic;
using System.Linq;
using FishNet.Connection;

namespace WelwiseSharedModule.Runtime.Server.Scripts
{
    public class VisibleClientsProviderService : IVisibleClientsProviderService
    {
        public IReadOnlyCollection<NetworkConnection> GetVisibleClientsForClient(NetworkConnection networkConnection) =>
            _roomsProviderService.RoomsByConnectedClientsNetworkConnections.GetValueOrDefault(networkConnection)
                ?.ConnectedClientsNetworkConnections
                .Where(connection => connection != networkConnection).ToHashSet();

        private readonly IRoomsProviderService _roomsProviderService;

        public VisibleClientsProviderService(IRoomsProviderService roomsProviderService)
        {
            _roomsProviderService = roomsProviderService;
        }
    }
}