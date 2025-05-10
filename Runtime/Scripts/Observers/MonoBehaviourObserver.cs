using System;
using UnityEngine;

namespace Observers
{
    public class MonoBehaviourObserver : MonoBehaviour
    {
        public event Action Updated;
        
        public void Update() => Updated?.Invoke();
    }
}