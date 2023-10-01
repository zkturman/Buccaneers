using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurnAction
{
    public bool IsFinished();
    public void ActionEnter();
    public void ActionUpdate();
    public void ActionExit();
    public string SerialiseAction();

}
