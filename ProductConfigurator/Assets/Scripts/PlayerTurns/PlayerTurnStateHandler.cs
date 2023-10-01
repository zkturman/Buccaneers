using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnStateHandler : MonoBehaviour
{
    [SerializeReference]
    private PlayerTurnState playerStatus;
    public PlayerTurnState PlayerStatus { get => playerStatus; }  

    public void SetPlayerActing()
    {
        playerStatus = PlayerTurnState.Acting;
    }

    public void SwitchPlayerStatus()
    {
        if (playerStatus == PlayerTurnState.Waiting)
        {
            playerStatus = PlayerTurnState.Acting;
        }
        else
        {
            playerStatus = PlayerTurnState.Waiting;
        }
    }
}
