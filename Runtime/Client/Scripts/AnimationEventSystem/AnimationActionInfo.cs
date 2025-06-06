using System;

namespace WelwiseSharedModule.Runtime.Client.Scripts.AnimationEventSystem
{
    public class AnimationActionInfo
    {
        public bool IsInvoked { get; set; }
        public Func<float> StartTimeFunc { get; private set; }
        public Action Action { get; private set; }

        public AnimationActionInfo(Func<float> startTimeFunc, Action action, bool isInvoked = false)
        {
            IsInvoked = isInvoked;
            StartTimeFunc = startTimeFunc;
            Action = action;
        }
    }
}