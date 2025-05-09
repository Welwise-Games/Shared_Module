using UnityEngine.Localization.Settings;

namespace MainHub.Modules.SharedModule.Scripts.Tools
{
    public static class LocalizationTools
    {
        public static string GetLocalizedString(string tableName, string key)
            => LocalizationSettings.StringDatabase.GetLocalizedString(tableName, key);

        public static string GetLocalizedString(string tableName, string key, string n1 = null, string n2 = null)
        {
            var localizedString = GetLocalizedString(tableName, key);

            if (n1 != null)
                localizedString = localizedString.Replace(LocalizationKeysHolder.FirstVariableName, n1);

            if (n2 != null)
                localizedString = localizedString.Replace(LocalizationKeysHolder.SecondVariableName, n2);

            return localizedString;
        }
    }
}