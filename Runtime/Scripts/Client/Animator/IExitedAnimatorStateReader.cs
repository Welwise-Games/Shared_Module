namespace WelwiseSharedModule.Runtime.Scripts.Client.Animator
{
    public interface IExitedAnimatorStateReader
    {
        void OnExitState(int stateHash);
        void OnEndState(int stateHash);
    }
}