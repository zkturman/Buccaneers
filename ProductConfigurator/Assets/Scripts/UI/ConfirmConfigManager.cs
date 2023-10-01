using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cinemachine;
using Photon.Pun;
public class ConfirmConfigManager : ConfirmButton
{
    protected override void buttonClickAction()
    {
        updateUIAfterConfirm();
        string serialisedData = getSerialisedBeastieConfig();
        int playerId = PhotonNetwork.LocalPlayer.ActorNumber;
        gameStateHandler.photonView.RPC("RegisterPlayerRemote", RpcTarget.All, playerId);
        gameStateHandler.photonView.RPC("ConfigureBeastieRemote", RpcTarget.All, playerId, serialisedData);
    }
}
