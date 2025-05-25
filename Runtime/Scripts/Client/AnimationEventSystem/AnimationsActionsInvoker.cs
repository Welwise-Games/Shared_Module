using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WelwiseSharedModule.Runtime.Scripts.Client.Animator;
using WelwiseSharedModule.Runtime.Scripts.Tools;

namespace WelwiseSharedModule.Runtime.Scripts.Client.AnimationEventSystem
{
    public class AnimationsActionsInvoker
    {
        private readonly List<AnimationActionInfo> _animationActionsInfo;
        private readonly int _targetAnimationHash;

        public AnimationsActionsInvoker(AnimatorStateObserver animatorStateObserver, List<AnimationActionInfo> animationActionsInfo, int targetAnimationHash)
        {
            _animationActionsInfo = animationActionsInfo;
            _targetAnimationHash = targetAnimationHash;
            MakeAreNotInvokedAnimationActionsInfo(_targetAnimationHash);
            
            animatorStateObserver.ExitedState += MakeAreNotInvokedAnimationActionsInfo;
            animatorStateObserver.UpdatedState += TryInvokingAnimationsActions;
        }

        private void MakeAreNotInvokedAnimationActionsInfo(int hash)
        {
            if (_targetAnimationHash == hash)
                _animationActionsInfo.ForEach(info => info.IsInvoked = false);
        }

        private void TryInvokingAnimationsActions(AnimatorStateInfo animatorStateInfo)
        {
            if (animatorStateInfo.shortNameHash != _targetAnimationHash) return;

            var pastAnimationTime = animatorStateInfo.length * animatorStateInfo.normalizedTime;
            
            _animationActionsInfo.Where(info => !info.IsInvoked && pastAnimationTime >= info.StartTimeFunc.Invoke()).
                ForEach(info =>
            {
                info.IsInvoked = true;
                info.Action?.Invoke();
            });
        }
    }
}