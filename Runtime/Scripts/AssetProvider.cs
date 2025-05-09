using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using Object = UnityEngine.Object;

namespace MainHub.Modules.SharedModule.Scripts
{
    public static class AssetProvider
    {
        public static async UniTask<GameObject> InstantiateGameObjectByPrefabRotationAsync(string assetId,
            Vector3 position = default)
        {
            var prefab = await LoadAsync<GameObject>(assetId);
            return Object.Instantiate(prefab, position, prefab.transform.rotation);
        }
        
        public static async UniTask<T> InstantiateAsync<T>(string assetId, Vector3? position = null,
            Quaternion? rotation = null, Transform parent = null, bool shouldMakeDontDestroyOnLoad = false,
            Type type = null, string name = null, bool shouldAppointParentAfterInstantiate = false) where T : Object
        {
            var handle = position.HasValue || rotation.HasValue
                ? Addressables.InstantiateAsync(assetId, new InstantiationParameters(
                    position ?? Vector3.zero, rotation ?? Quaternion.identity, shouldAppointParentAfterInstantiate ? null : parent))
                : Addressables.InstantiateAsync(assetId, shouldAppointParentAfterInstantiate ? null : parent);

            var instance = await handle;

            if (!instance)
                throw new NullReferenceException($"Asset as addressable with assetId {assetId} not found");
            
            if (shouldAppointParentAfterInstantiate)
                instance.transform.SetParent(parent);

            if (typeof(T) == typeof(GameObject))
                return instance as T;

            var targetComponent = instance.GetComponent<T>(type, assetId);

            instance.GetOrAddComponent<DestroyObserver>().Destroyed
                += () => Addressables.Release(handle);

            if (shouldMakeDontDestroyOnLoad)
                Object.DontDestroyOnLoad(targetComponent);

            if (name != null)
                instance.name = name;

            return targetComponent;
        }

        public static T GetOrAddComponent<T>(this GameObject instance) where T : Component
        {
            instance.TryGetComponent<T>(out var component);
            return component ? component : instance.AddComponent<T>();
        }

        public static async UniTask<IEnumerable<T>> LoadAllAsync<T>(string assetLabelId)
        {
            var locations = await Addressables.LoadResourceLocationsAsync(assetLabelId, typeof(T)).Task;
            var tasks = locations.Select(location => Addressables.LoadAssetAsync<T>(location).Task.AsUniTask());

            return await UniTask.WhenAll(tasks);
        }

        public static async UniTask<Object> LoadAsync(string assetId, Type type = null)
        {
            if (type == typeof(Sprite))
                return await LoadAsync<Sprite>(assetId);

            return await LoadAsync<Object>(assetId, type);
        }


        public static async UniTask<T> LoadAsync<T>(string assetId, Type type = null) where T : Object
        {
            if (string.IsNullOrEmpty(assetId))
                return null;
            
            try
            {
                if (typeof(T).IsSubclassOf(typeof(Component)))
                    return GetComponent<T>(await Addressables.LoadAssetAsync<GameObject>(assetId).Task,
                        type ?? typeof(T),
                        assetId);

                var handle = Addressables.LoadAssetAsync<T>(assetId).Task;

                var @object = await handle;

                if (@object == null)
                    return null;

                if (type == null || type.IsInstanceOfType(@object))
                    return @object;

                if (!(@object is GameObject gameObject))
                {
                    Debug.LogError($"Object with type {type} and assetId {assetId} isn't found");
                    return null;
                }

                return GetComponent<T>(gameObject, type, assetId);
            }
            catch
            {
                return null;
            }
        }

        private static T GetComponent<T>(this GameObject gameObject, Type type, string assetId) where T : class
        {
            try
            {
                T targetComponent;

                if (type == null)
                    gameObject.TryGetComponent(out targetComponent);
                else
                {
                    var components = gameObject.GetComponents<Component>();
                    targetComponent = components.FirstOrDefault(type.IsInstanceOfType) as T;
                }

                if (targetComponent == null)
                    throw new NullReferenceException(
                        $"Component {type ?? typeof(T)} on gameObject with assetId {assetId} not found");

                return targetComponent;
            }
            catch (Exception exception)
            {
                Debug.LogError(exception);
            }

            return default;
        }
    }
}