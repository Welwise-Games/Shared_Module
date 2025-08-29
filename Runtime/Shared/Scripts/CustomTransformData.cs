using System;
using UnityEngine;

namespace WelwiseSharedModule.Runtime.Shared.Scripts
{
    [Serializable]
    public struct CustomTransformData
    {
        [field: SerializeField] public Vector3 Position { get; private set; }
        [field: SerializeField] public Vector3 Rotation { get; private set; }
    }
}