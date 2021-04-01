using Assets.Scripts.Core;
using UnityEngine;

public class TestSingleton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputEventHandler.Instance.OnChangePauseState += Instance_OnChangePauseState;
        InputEventHandler.Instance.OnChangeInitialisationState += Instance_OnChangeInitialisationState;
    }

    private void Instance_OnChangeInitialisationState(bool obj)
    {
        Debug.Log($"Change initialisation state confirmed. Current state: {obj}");
    }

    private void Instance_OnChangePauseState(EPauseState obj)
    {
        Debug.Log($"Change Pause state confirmed. Current state: {obj}");
    }

    private void Instance_OnPress()
    {
        Debug.Log("hello");
    }
     
    [ContextMenu("TestPause")]
    public void TestPause()
    {
        InputEventHandler.Instance.Pause();
    }

    [ContextMenu("TestUnPause")]
    public void TestUnPause()
    {
        InputEventHandler.Instance.UnPause();
    }

    [ContextMenu("TestInitialization")]
    public void TestInitialization()
    {
        InputEventHandler.Instance.Initialize();
    }
}
