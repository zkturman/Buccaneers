using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class GameStateHandler : BaseGameStateHandler
{
    [PunRPC]
    public void RegisterPlayerRemote(int playerId)
    {
        RegisterPlayer(playerId);
    }

    protected override void TriggerStartGame()
    {
        photonView.RPC("TriggerStartGameRemote", RpcTarget.All);
    }

    [PunRPC]
    public void TriggerStartGameRemote()
    {
        gameInitialiser.StartGame();
        if (isCurrentPlayer(firstPlayerId))
        {
            turnHandler.SetFirstTurn();
        }
    }

    [PunRPC]
    public void ConfigureBeastieRemote(int playerId, string beastieConfigData)
    {
        bool isFirstPlayer = isCurrentPlayer(playerId);
        ConfigureBeastie(isFirstPlayer, beastieConfigData);
    }

    protected override bool isCurrentPlayer(int playerId)
    {
        return playerId == PhotonNetwork.LocalPlayer.ActorNumber;
    }
}
