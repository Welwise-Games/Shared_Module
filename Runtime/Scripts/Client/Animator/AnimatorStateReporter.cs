using System.Collections.Generic;
using System.Linq;
using MainHub.Modules.WelwiseSharedModule.Runtime.Scripts.Tools;
using UnityEngine;

namespace MainHub.Modules.WelwiseSharedModule.Runtime.Scripts.Client.Animator
{
    public class AnimatorStateReporter : StateMachineBehaviour
    {
        private List<IExitedAnimatorStateReader> _exitedStateReaders;

        private bool _isInvokedEndedState;

        public override void OnStateEnter(UnityEngine.Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            FindReaders(animator);

            _exitedStateReaders.OfType<IAnimationStateReader>().ForEach(reader => reader.OnEnterState(stateInfo.shortNameHash));
        }

        public override void OnStateExit(UnityEngine.Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            FindReaders(animator);

            _exitedStateReaders.ForEach(stateReader => stateReader?.OnExitState(stateInfo.shortNameHash));
        }

        public override void OnStateUpdate(UnityEngine.Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);

            _exitedStateReaders.OfType<IAnimationStateReader>().ForEach(reader => reader.OnUpdateState(stateInfo));

            if (!(stateInfo.normalizedTime >= 1) || _isInvokedEndedState) return;

            _exitedStateReaders.ForEach(reader => reader.OnEndState(stateInfo.shortNameHash));
            _isInvokedEndedState = true;
        }

        private void FindReaders(UnityEngine.Animator animator)
        {
            if (_exitedStateReaders != null)
                return;

            _exitedStateReaders = animator.transform.GetComponents<IExitedAnimatorStateReader>().ToList();
            
            if (animator.transform.parent)
                _exitedStateReaders.AddRange(animator.transform.parent.GetComponents<IExitedAnimatorStateReader>());
            
            _exitedStateReaders = _exitedStateReaders.GroupBy(x => x).Select(x => x.First()).ToList();
        }
    }
}