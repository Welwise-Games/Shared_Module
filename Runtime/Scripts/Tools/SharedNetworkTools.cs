using System.Collections.Generic;
using FishNet;
using FishNet.Connection;

namespace WelwiseSharedModule.Runtime.Scripts.Tools
{
    public static class SharedNetworkTools
    {
        public static bool IsOwners(this NetworkConnection networkConnection) => OwnerConnection == networkConnection;
        public static NetworkConnection OwnerConnection => InstanceFinder.ClientManager.Connection;
        public static T GetOwners<T>(this IReadOnlyDictionary<NetworkConnection, T> data) => data.GetValueOrDefault(OwnerConnection);
    }
}