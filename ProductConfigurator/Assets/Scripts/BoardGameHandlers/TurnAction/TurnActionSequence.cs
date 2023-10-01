using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnActionSequence
{
    private Queue<ITurnAction> turnActions;

    public TurnActionSequence(TurnContext actionContext)
    {
        turnActions = new Queue<ITurnAction>();
        turnActions.Enqueue(new MoveTurnAction(actionContext));
    }

    public ITurnAction GetUpcomingAction()
    {
        ITurnAction upcomingAction = turnActions.Peek(); // [currentActionIndex];
        if (upcomingAction.IsFinished())
        {
            turnActions.Dequeue();
            upcomingAction = null;
            turnActions.TryDequeue(out upcomingAction);
        }
        return upcomingAction;
    }

    public bool HasSequenceEnded()
    {
        return turnActions.Count == 0;
    }
}
