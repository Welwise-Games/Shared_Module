using UnityEngine;

namespace WelwiseSharedModule.Runtime.Scripts.Client.Animator
{
    public interface IAnimationStateReader : IExitedAnimatorStateReader
    {
        void OnEnterState(int stateHash);
        void OnUpdateState(AnimatorStateInfo animatorStateInfo);
    }
}