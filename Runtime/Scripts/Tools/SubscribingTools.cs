using System;
using Observers;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace Tools
{
    public static class SubscribingTools
    {
        public static void SubscribeToLocalizationAndSubscribeOnDestroy(this GameObject gameObject,
            Action<Locale> actions)
        {
            if (!gameObject)
                return;

            LocalizationSettings.SelectedLocaleChanged += actions;
            
            gameObject.GetOrAddComponent<DestroyObserver>().Destroyed += () => LocalizationSettings.SelectedLocaleChanged -= actions;
        }
    }
}