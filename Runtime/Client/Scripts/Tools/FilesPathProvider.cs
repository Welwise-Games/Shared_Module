using System.IO;
using UnityEngine;

namespace WelwiseSharedModule.Runtime.Client.Scripts.Tools
{
    public static class FilesPathProvider
    {
        public static string GetStreamingAssetsPath(string fileName) => Path.Combine(Application.streamingAssetsPath, fileName);
        public static string GetDataPath(string fileName) => Path.Combine(Application.dataPath, fileName);
    }
}