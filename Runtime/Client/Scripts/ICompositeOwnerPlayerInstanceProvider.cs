using UnityEngine;

namespace WelwiseSharedModule.Runtime.Client.Scripts
{
    public interface ICompositeOwnerPlayerInstanceProvider
    {
        GameObject OwnerPlayerInstance { get; }   
        IOwnerPlayerMovementStateProvider MovementStateProvider { get; }
    }
}