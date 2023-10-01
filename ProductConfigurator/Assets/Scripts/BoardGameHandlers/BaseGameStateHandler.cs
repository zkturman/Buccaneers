using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public abstract class BaseGameStateHandler : MonoBehaviourPun
{
    [SerializeField]
    protected GameInitialiser gameInitialiser;
    [SerializeField]
    protected PlayerTurnActionHandler turnHandler;
    protected int readyPlayerCount = 0;
    protected int firstPlayerId = 0;
    protected int requiredPlayerCount = 2;
    protected BeastieConfigSerialiser beastieConfigSerialiser;

    protected abstract void TriggerStartGame();

    protected abstract bool isCurrentPlayer(int playerId);

    protected void Awake()
    {
        beastieConfigSerialiser = new BeastieConfigSerialiser();
    }

    public void RegisterPlayer(int playerId)
    {
        readyPlayerCount++;
        if (firstPlayerId == 0)
        {
            firstPlayerId = playerId;
        }
        if (readyPlayerCount == requiredPlayerCount)
        {
            TriggerStartGame();
        }
        else if (isCurrentPlayer(playerId))
        {
            gameInitialiser.ShowRegisteredWaitScene();
        }
    }

    public void ConfigureBeastie(bool isFirstPlayer, string beastieConfigData)
    {
        BeastieData configData = beastieConfigSerialiser.DeserialiseBeasieData(beastieConfigData);
        GameBeastieManager beastieManager = GetComponent<GameBeastieManager>();
        if (isFirstPlayer)
        {
            beastieManager.ConfigureMyBeastie(configData);
        }
        else
        {
            beastieManager.ConfigureOpponentBeastie(configData);
        }
    }
}
