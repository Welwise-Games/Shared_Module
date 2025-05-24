using System;
using UnityEngine;

namespace MainHub.Modules.WelwiseSharedModule.Runtime.Scripts.Observers
{
    public class DestroyObserver : MonoBehaviour
    {
        public event Action Destroyed;
        private void OnDestroy() => Destroyed?.Invoke();
    }
}