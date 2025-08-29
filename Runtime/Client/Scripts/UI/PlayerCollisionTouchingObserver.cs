using System;
using UnityEngine;
using WelwiseSharedModule.Runtime.Shared.Scripts.Observers;

namespace WelwiseSharedModule.Runtime.Client.Scripts.UI
{
    public class PlayerCollisionTouchingObserver
    {
        public event Action<RaycastHit> Touched;

        private readonly PhysicsScene _physicsScene;

        public PlayerCollisionTouchingObserver(MonoBehaviourObserver monoBehaviourObserver, Camera camera,
            float rayLength, LayerMask mask, PhysicsScene physicsScene)
        {
            _physicsScene = physicsScene;
            void RayCast() => TryRayCastAndInvokeAction(camera, rayLength, mask);

            monoBehaviourObserver.Updated += RayCast;
        }

        private void TryRayCastAndInvokeAction(Camera camera, float rayLength, LayerMask layerMask)
        {
            if (!Input.GetKey(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Mouse0) && 
                !Input.GetKeyUp(KeyCode.Mouse0) || UITools.IsInteractWithUI())
                return;

            var ray = camera.ScreenPointToRay(Input.mousePosition);
            
            if (_physicsScene.Raycast(ray.origin, ray.direction, out var hit, rayLength, layerMask))
                Touched?.Invoke(hit);
        }
    }
}