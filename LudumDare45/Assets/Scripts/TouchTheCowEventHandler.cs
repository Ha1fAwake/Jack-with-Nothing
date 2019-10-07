using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[EventHandlerInfo("MyHandler", "TouchTheCow", "Set the touchTheCow to control blocks.")]
public class TouchTheCowEventHandler : EventHandler
{
    public static bool touchTheCow = false;
    private bool firstTime = false;

    private void Update()
    {
        if (touchTheCow && firstTime == false)
        {
            ExecuteBlock();
        }
        firstTime = true;
    }
}
