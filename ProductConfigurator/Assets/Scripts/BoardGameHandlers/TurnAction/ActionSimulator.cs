using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSimulator : MonoBehaviour
{
    [SerializeField]
    private TurnContext turnContext;
    private ActionDeserialiser actionDeserialiser;
    private void Awake()
    {
        actionDeserialiser = new ActionDeserialiser();
    }

    public void SimulateAction(string actionData, bool isCurrentPlayer)
    {
        IActionSimulation playerAction = actionDeserialiser.GenerateSimulation(actionData);
        playerAction.SimulateAction(turnContext, isCurrentPlayer);
    }
}
