using System;
using UnityEngine;
using Assets.Scripts.Core;

public class InputEventHandler : ManagerBase<InputEventHandler>
{
    public event Action OnPress;
    public event Action OnRelease;

    public enum MyMouseButton
    {
        Left = 0,
        Right = 1
    }

    void Update()
    {
        if (Input.GetMouseButtonDown((int)MyMouseButton.Left) &&
            OnPress != null)
            OnPress();

        if (Input.GetMouseButtonDown((int)MyMouseButton.Right) &&
            OnRelease != null)
            OnRelease();


    }
}
