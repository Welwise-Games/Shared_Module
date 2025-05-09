using System;
using UnityEngine;

namespace MainHub.Modules.SharedModule.Scripts
{
    public class MonoBehaviourObserver : MonoBehaviour
    {
        public event Action Updated;
        
        public void Update() => Updated?.Invoke();
    }
}