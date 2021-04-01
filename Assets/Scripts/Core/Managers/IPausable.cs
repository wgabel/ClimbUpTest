namespace Assets.Scripts.Core
{
    public interface IPausable
    {
        void Pause ( );
        void UnPause ( );
        EPauseState PauseState { get; }
        event System.Action<EPauseState> OnChangePauseState;
    }
}