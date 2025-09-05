using System;
using System.IO;
using WelwiseSharedModule.Runtime.Shared.Scripts;

namespace WelwiseSharedModule.Runtime.Server.Scripts.Tools
{
    public static class JsonFileContentLoadingTools
    {
        public static T GetLoadedTContent<T>(string fileName, Func<T> defaultT)
        {
            var path = FilesPathProvider.GetDataPath(fileName + ".json");

            return File.Exists(path)
                ? File.ReadAllText(path).GetFromJsonDeserializedWithoutNulls<T>()
                : defaultT.Invoke();
        }
    }
}