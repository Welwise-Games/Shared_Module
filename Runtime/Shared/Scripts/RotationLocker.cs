using UnityEngine;

namespace WelwiseSharedModule.Runtime.Shared.Scripts
{
    public class RotationLocker : MonoBehaviour
    {
        private Quaternion _startRotation;

        private void Awake() => _startRotation = transform.rotation;

        private void Update() => transform.rotation = _startRotation;
    }
}