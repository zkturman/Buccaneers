using UnityEngine;

public abstract class TurnActionController : MonoBehaviour
{
    private TurnActionSequence actionSequence;
    private ITurnAction currentAction;
    [SerializeField]
    protected TurnContext turnContext;

    public void LoadActions(string[] actions)
    {
        actionSequence = new TurnActionSequence(turnContext);
        currentAction = actionSequence.GetUpcomingAction();
        currentAction?.ActionEnter();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCurrentAction())
        {
            performCurrentAction();
        }
    }

    private bool hasCurrentAction()
    {
        return currentAction != null;
    }

    private void performCurrentAction()
    {
        currentAction.ActionUpdate();
        if (currentAction.IsFinished())
        {
            string actionData = currentAction.SerialiseAction();
            currentAction.ActionExit();
            performAction(actionData);
            currentAction = actionSequence.GetUpcomingAction();
            currentAction?.ActionEnter();
        }
    }

    public bool HasTurnEnded()
    {
        bool hasTurnEnded = false;
        if (actionSequence != null)
        {
            hasTurnEnded = actionSequence.HasSequenceEnded();
        }
        return hasTurnEnded;
    }

    protected abstract void performAction(string actionData);
}
