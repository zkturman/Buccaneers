using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnActionHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerTurnStateHandler myPlayer;
    [SerializeField]
    private PlayerTurnStateHandler opponentPlayer;
    [SerializeField]
    private TurnActionController turnActionController;
    [SerializeField]
    private GameObject waitingMenu;
    [SerializeField]
    private GameObject actingMenu;

    public void SetFirstTurn() 
    {
        myPlayer.SetPlayerActing();
        actingMenu.SetActive(true);
        turnActionController.LoadActions(null);
    }


    public void EndTurn()
    {
        myPlayer.SwitchPlayerStatus();
        if (myPlayer.PlayerStatus == PlayerTurnState.Waiting)
        {
            waitingMenu.SetActive(true);
            actingMenu.SetActive(false);
        }
        else
        {
            waitingMenu.SetActive(false);
            actingMenu.SetActive(true);
            turnActionController.LoadActions(null);
        }
    }

    private void Update()
    {
        if (myPlayer.PlayerStatus == PlayerTurnState.Acting && turnActionController.HasTurnEnded())
        {
            EndTurn();
        }
    }
}
