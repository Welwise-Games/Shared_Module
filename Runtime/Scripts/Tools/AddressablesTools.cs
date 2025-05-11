using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Tools
{
    public static class AddressablesTools
    {
        public static async UniTask<string> GetAssetIdAsync(this AssetReference assetReference)
        {
            var resourceLocations = await Addressables.LoadResourceLocationsAsync(assetReference);
            return resourceLocations is { Count: > 0 } ? resourceLocations[0].PrimaryKey : null;
        }
    }
}