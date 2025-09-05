using UnityEngine;

namespace WelwiseSharedModule.Runtime.Shared.Scripts.Tools
{
    public static class RandomTools
    {
        public static bool UseAsChanceAndGetResult(this float chance) => Random.Range(0f, 100f) <= chance;
        public static bool GetFiftyToFiftyChanceResult() => Random.value >= 0.5f;
    }
}