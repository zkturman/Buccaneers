using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionSimulation
{
    public void SimulateAction(TurnContext context, bool isCurrentPlayer);
}
