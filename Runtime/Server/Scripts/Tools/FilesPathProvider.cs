using System.IO;
using UnityEngine;

namespace WelwiseSharedModule.Runtime.Server.Scripts.Tools
{
    public static class FilesPathProvider
    {
        public static string GetDataPath(string fileName) => Path.GetFullPath(Path.Combine(Application.dataPath, "..", fileName));
    }
}