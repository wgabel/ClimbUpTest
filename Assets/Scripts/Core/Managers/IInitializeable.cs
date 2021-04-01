namespace Assets.Scripts.Core
{
    public interface IInitializeable
    {
        bool Initialize();
        bool IsInitialized { get; }
        event System.Action<bool> OnChangeInitialisationState;
    }
}
