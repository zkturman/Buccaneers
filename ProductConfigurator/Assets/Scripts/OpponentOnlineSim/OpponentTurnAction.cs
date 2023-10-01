using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentTurnAction : MonoBehaviour
{
    [SerializeField]
    private string commandArgs;

    [SerializeField]
    private PlayerTurnActionHandler turnHandler;
    [SerializeField]
    private ActionSimulator simulator;

    public void MoveBeastie()
    {
        try
        {
            simulator.SimulateAction(string.Format("move {0}", commandArgs), false);
            turnHandler.EndTurn();
        }
        catch
        {
            Debug.Log("Invalid move arguments.");
        }
    }
}
