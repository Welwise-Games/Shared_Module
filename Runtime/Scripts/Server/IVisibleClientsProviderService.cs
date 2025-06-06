using System.Collections.Generic;
using FishNet.Connection;

namespace WelwiseSharedModule.Runtime.Scripts.Server
{
    public interface IVisibleClientsProviderService
    {
        IReadOnlyCollection<NetworkConnection> GetVisibleClientsForClient(NetworkConnection networkConnection);
    }
}