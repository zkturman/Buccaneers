using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDeserialiser
{
    public ActionDeserialiser() { }

    public IActionSimulation GenerateSimulation(string actionData)
    {
        IActionSimulation playerAction = null;
        string[] actionParts = findActionParts(actionData);
        if (actionParts.Length > 0)
        {
            string actionName = actionParts[0].ToUpper();
            switch (actionName)
            {
                case "MOVE":
                    playerAction = createMoveAction(actionParts);
                    break;
                default:
                    throw new System.Exception("Unhandled actions received.");
            }
        }
        return playerAction;
    }

    private string[] findActionParts(string actionData)
    {
        string[] actionParts;
        if (actionData != string.Empty)
        {
            actionParts = actionData.Split(' ');
        }
        else
        {
            actionParts = new string[0];
        }
        return actionParts;
    }

    private MoveSimulator createMoveAction(string[] actionParts)
    {
        Vector2 newCoordinates = Vector2.zero;
        if (actionParts.Length == 3)
        { 
            newCoordinates = parseCoordinates(actionParts[1], actionParts[2]);
        }
        return new MoveSimulator(newCoordinates);
    }

    private Vector2 parseCoordinates(string rowValue, string columnValue)
    {
        int rowId;
        int columnId;
        Vector2 newCoordinates;
        if (int.TryParse(rowValue, out rowId) && int.TryParse(columnValue, out columnId))
        {
            newCoordinates = new Vector2(rowId, columnId);
        }
        else
        {
            newCoordinates = Vector2.zero;
        }
        return newCoordinates;
    }
}
