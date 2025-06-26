using Cysharp.Threading.Tasks;
using UnityEngine;
using WelwiseSharedModule.Runtime.Shared.Scripts;

namespace WelwiseSharedModule.Runtime.Client.Scripts
{
    public class CameraFactory
    {
        private readonly Container _container = new Container();

        public async UniTask<Camera> GetMainCameraAsync() =>
            await _container.GetOrLoadAndRegisterObjectAsync<Camera>("MainCamera",
                shouldMakeDontDestroyOnLoad: true);
    }
}