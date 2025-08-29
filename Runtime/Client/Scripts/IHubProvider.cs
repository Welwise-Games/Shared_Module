using UnityEngine;

namespace WelwiseSharedModule.Runtime.Client.Scripts
{
    public interface IHubProvider
    {
        GameObject HubInstance { get; }
    }
}