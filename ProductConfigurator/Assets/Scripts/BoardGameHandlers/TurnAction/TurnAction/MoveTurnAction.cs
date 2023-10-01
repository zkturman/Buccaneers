using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTurnAction : ITurnAction
{
    private TurnContext context;
    private Vector2 moveTarget;
    private bool targetSelected = false;

    public MoveTurnAction(TurnContext context)
    {
        this.context = context;
    }
    
    public void ActionEnter()
    {
        context.GameBoard.HighlightMoveTiles(Vector2.zero, 3);
        context.EventReceiver.AddClickEvent(moveToPosition);
    }

    public void ActionUpdate()
    {
    }

    public void ActionExit()
    {
        context.GameBoard.ResetBoardHighlights();
    }

    public bool IsFinished()
    {
        return targetSelected;
    }

    public string SerialiseAction()
    {
        return string.Format("move {0} {1}", (int)moveTarget.x, (int)moveTarget.y);
    }

    private void moveToPosition(Vector2 targetPosition)
    {
        moveTarget = targetPosition;
        targetSelected = true;
        context.EventReceiver.RemoveClickEvent(moveToPosition);
    }
}
