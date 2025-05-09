using System;
using UnityEngine;

namespace MainHub.Modules.SharedModule.Scripts
{
    public class DestroyObserver : MonoBehaviour
    {
        public event Action Destroyed;
        private void OnDestroy() => Destroyed?.Invoke();
    }
}