using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WelwiseSharedModule.Runtime.Shared.Scripts
{
    public static class JsonTools
    {
        public static readonly JsonSerializerSettings JsonSerializerSettings =
            new()
            {
                NullValueHandling = NullValueHandling.Ignore, TypeNameHandling = TypeNameHandling.Auto,
                SerializationBinder = new KnownTypesBinder
                {
                    KnownTypes = GetKnownTypes()
                }
            };

        public static string GetJsonSerializedObjectWithoutNulls(this object obj) =>
            JsonConvert.SerializeObject(obj, JsonSerializerSettings);


        public static T GetFromJsonDeserializedWithoutNulls<T>(this string str, Func<T> defaultValue = null) =>
            str == null ? defaultValue == null ? default : defaultValue.Invoke() : JsonConvert.DeserializeObject<T>(str, JsonSerializerSettings);

        public static object GetFromJsonDeserializedWithoutNulls(this string str, Type type) =>
            JsonConvert.DeserializeObject(str, type, JsonSerializerSettings);

        private static List<Type> GetKnownTypes() => new();
    }
}