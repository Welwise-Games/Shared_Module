using System;
using UnityEngine;
using WelwiseSharedModule.Runtime.Shared.Scripts.Observers;

namespace WelwiseSharedModule.Runtime.Client.Scripts.UI
{
    public class PlayerCollisionTouchingObserver
    {
        public event Action<RaycastHit> Touched;

        private readonly PhysicsScene _physicsScene;
        private readonly bool _shouldCheckOnlyGetKeyDown;

        private event Action _disposed;
        
        public PlayerCollisionTouchingObserver(MonoBehaviourObserver monoBehaviourObserver, Camera camera,
            float rayLength, LayerMask mask, PhysicsScene physicsScene, bool shouldCheckOnlyGetKeyDown)
        {
            _physicsScene = physicsScene;
            _shouldCheckOnlyGetKeyDown = shouldCheckOnlyGetKeyDown;
            void RayCast() => TryRayCastAndInvokeAction(camera, rayLength, mask);
            void UnsubscribeRaycast() => monoBehaviourObserver.Updated -= RayCast; 
            
            monoBehaviourObserver.Updated += RayCast;
            _disposed += UnsubscribeRaycast;
        }

        public void Dispose() => _disposed?.Invoke();

        private void TryRayCastAndInvokeAction(Camera camera, float rayLength, LayerMask layerMask)
        {
            if (!Input.GetKeyDown(KeyCode.Mouse0) && (_shouldCheckOnlyGetKeyDown || (!Input.GetKey(KeyCode.Mouse0) && 
                !Input.GetKeyUp(KeyCode.Mouse0))) || UITools.IsInteractWithUI())
                return;

            var ray = camera.ScreenPointToRay(Input.mousePosition);
            
            if (_physicsScene.Raycast(ray.origin, ray.direction, out var hit, rayLength, layerMask))
                Touched?.Invoke(hit);
        }
    }
}