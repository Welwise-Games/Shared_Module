using System;
using UnityEngine;

namespace MainHub.Modules.EmotionsModule.Scripts.Animations.SettingEmotions
{
    [Serializable]
    public class ErrorTextConfig
    {
        [field: SerializeField] [field: Min(0.5f)] public float FadeInTime { get; private set; } = 0.5f;  
        [field: SerializeField] [field: Min(0.5f)] public float FadeOutTime { get; private set; } = 0.5f;  
    }
}