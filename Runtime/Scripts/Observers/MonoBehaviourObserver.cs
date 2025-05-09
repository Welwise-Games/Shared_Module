using System;
using UnityEngine;

namespace WelwiseSharedModule.Runtime.Scripts.Observers
{
    public class MonoBehaviourObserver : MonoBehaviour
    {
        public event Action Updated;
        
        public void Update() => Updated?.Invoke();
    }
}