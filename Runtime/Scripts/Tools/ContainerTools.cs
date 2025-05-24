using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MainHub.Modules.WelwiseSharedModule.Runtime.Scripts.Tools
{
    public static class ContainerTools
    {
        public static async UniTask<TController> GetControllerAsync<TController, TView>(this Container container,
            string viewAssetId, Func<TView, UniTask> created,
            bool shouldMakeDontDestroyOnLoad = false, Transform parent = null)
            where TView : MonoBehaviour where TController : class
        {
            var viewInstance = await container.GetSingleByAssetIdAsync<TView>(viewAssetId);
            
            if (!viewInstance)
            {
                await container.GetOrLoadAndRegisterObjectAsync(viewAssetId, created, shouldCreate: true,
                    parent: parent, shouldMakeDontDestroyOnLoad: shouldMakeDontDestroyOnLoad);
            }

            return container.GetSingleByType<TController>();
        }
    }
}