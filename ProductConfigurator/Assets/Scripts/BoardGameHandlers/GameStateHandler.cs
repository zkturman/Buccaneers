using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class GameStateHandler : MonoBehaviourPun
{
    [SerializeField]
    private GameInitialiser gameInitialiser;
    private BeastieConfigSerialiser beastieConfigSerialiser;
    private int readyPlayerCount = 0;
    private int firstPlayerId = 0;
    private int requiredPlayerCount = 2;

    private void Awake()
    {
        beastieConfigSerialiser = new BeastieConfigSerialiser();
    }

    [PunRPC]
    public void RegisterPlayer(int playerId)
    {
        readyPlayerCount++;
        if (firstPlayerId == 0)
        {
            firstPlayerId = playerId;
        }
        if (readyPlayerCount == requiredPlayerCount)
        {
            photonView.RPC("TriggerStartGame", RpcTarget.All);
        }
        else if (playerId == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            gameInitialiser.ShowRegisteredWaitScene();
        }
    }

    [PunRPC]
    public void TriggerStartGame()
    {
        gameInitialiser.StartGame();
    }

    [PunRPC]
    public void ConfigureBeastie(int playerId, string beastieConfigData)
    {

        BeastieData configData = beastieConfigSerialiser.DeserialiseBeasieData(beastieConfigData);
        GameBeastieManager beastieManager = GetComponent<GameBeastieManager>();
        if (playerId == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            beastieManager.ConfigureMyBeastie(configData);
        }
        else
        {
            beastieManager.ConfigureOpponentBeastie(configData);
        }
    }
}
