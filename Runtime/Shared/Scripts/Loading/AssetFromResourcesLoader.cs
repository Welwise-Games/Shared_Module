using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace WelwiseSharedModule.Runtime.Shared.Scripts.Loading
{
    public class AssetFromResourcesLoader : IAssetLoader
    {
        public async UniTask<GameObject> GetInstantiatedGameObjectAsync(string assetId, Vector3? position = null, Quaternion? rotation = null,
            Transform parent = null)
        {
            var instance = UnityEngine.Object.Instantiate(await Resources.LoadAsync(assetId),
                position ?? Vector3.zero,
                rotation ?? Quaternion.identity, parent) as GameObject;

            if (!instance)
                throw new NullReferenceException($"Asset as resources with path {assetId} not found");

            return instance;
        }

        public async UniTask<T> GetLoadedAssetAsync<T>(string assetId) where T : Object => await Resources.LoadAsync(assetId) as T;

        public async UniTask<IEnumerable<T>> GetLoadedAssetsAsync<T>(string labelOrFolderPath) where T : Object
        {
            return Resources.LoadAll<T>(labelOrFolderPath);
        }
    }
}