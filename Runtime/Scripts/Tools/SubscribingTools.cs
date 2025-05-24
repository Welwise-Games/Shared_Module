using System;
using MainHub.Modules.WelwiseSharedModule.Runtime.Scripts.Observers;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace MainHub.Modules.WelwiseSharedModule.Runtime.Scripts.Tools
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