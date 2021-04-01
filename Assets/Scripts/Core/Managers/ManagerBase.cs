using Assets.Scripts.Core.Internal;
using System;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public abstract class ManagerBase<T> : Singleton<T>, IInitializeable, IPausable where T : MonoBehaviour
    {
        public bool IsInitialized { get; private set; }

        public EPauseState PauseState { get; private set; }

        public event Action<EPauseState> OnChangePauseState;
        public event Action<bool> OnChangeInitialisationState;

        public virtual bool Initialize()
        {
            IsInitialized = true;
            if (OnChangeInitialisationState != null) OnChangeInitialisationState(IsInitialized);
            Debug.Log($"{typeof(T).Name} initialized. Current state: {IsInitialized}");
            return IsInitialized;
        }

        public virtual void Pause()
        {
            PauseState = EPauseState.paused;
            if (OnChangePauseState != null) OnChangePauseState(PauseState);
            Debug.Log($"{typeof(T).Name} Paused. Current state: {PauseState}");
        }

        public virtual void UnPause()
        {
            PauseState = EPauseState.unpaused;
            if (OnChangePauseState != null) OnChangePauseState(PauseState);
            Debug.Log($"{typeof(T).Name} UnPaused. Current state: {PauseState}");
        }
    }
}

    
