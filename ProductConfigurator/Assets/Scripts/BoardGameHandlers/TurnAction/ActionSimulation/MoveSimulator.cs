using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSimulator : IActionSimulation
{
    private Vector2 targetLocation;
    public MoveSimulator(Vector2 targetLocation)
    {
        this.targetLocation = targetLocation;
    }

    public void SimulateAction(TurnContext context, bool isCurrentPlayer)
    {
        if (isCurrentPlayer)
        {
            context.BeastieBoardManager.PlaceMyBeastie((int)targetLocation.x, (int)targetLocation.y);
        }
        else
        {
            context.BeastieBoardManager.PlaceOpponentBeastie((int)targetLocation.x, (int)targetLocation.y);
        }
    }
}
