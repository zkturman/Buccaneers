using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineSimGameStateHandler : BaseGameStateHandler
{

    protected override void TriggerStartGame()
    {
        gameInitialiser.StartGame();
        turnHandler.SetFirstTurn();
    }

    protected override bool isCurrentPlayer(int playerId)
    {
        return playerId > 0;
    }
}
