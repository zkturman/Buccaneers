using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineSimTurnController : TurnActionController
{
    protected override void performAction(string actionData)
    {
        Debug.Log(actionData);
        turnContext.Simulator.SimulateAction(actionData, true);
    }
}
