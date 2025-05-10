using System;
using UnityEngine;

namespace Observers
{
    public class DestroyObserver : MonoBehaviour
    {
        public event Action Destroyed;
        private void OnDestroy() => Destroyed?.Invoke();
    }
}