using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace WelwiseSharedModule.Runtime.Client.Scripts.Tools
{
    public static class FilesLoadingTools
    {
        public static async UniTask<string> GetFileContentAsync(string filePath)
        {
            string defaultValue = null;

            using var request = UnityWebRequest.Get(filePath);
            try
            {
                await request.SendWebRequest();
                    
                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Failed to load text file from {filePath}: " + request.error);
                }
                else
                {
                    defaultValue = request.downloadHandler.text;
                    Debug.Log($"Loaded text file: Address = {filePath}");
                }   
            }
            catch
            {
                Debug.LogError($"Failed to load text file from {filePath}: " + request.error);
            }

            return defaultValue;
        }
    }
}