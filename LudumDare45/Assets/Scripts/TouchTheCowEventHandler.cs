using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[EventHandlerInfo("MyHandler", "TouchTheCow", "Set the touchTheCow to control blocks.")]
public class TouchTheCowEventHandler : EventHandler
{
    public bool touchTheCow; // static

    private void Update()
    {
        if (touchTheCow)
        {
            ExecuteBlock();
        }
    }
}
