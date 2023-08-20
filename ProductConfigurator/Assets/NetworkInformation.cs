using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Text;
using Photon.Pun;

public class NetworkInformation : MonoBehaviour
{
    private Label dataLabel;
    private void OnEnable()
    {
        VisualElement rootDocument = GetComponent<UIDocument>().rootVisualElement;
        dataLabel = rootDocument.Q<Label>("LobbyData");
        dataLabel.text = generateServerInformation();
    }

    private string generateServerInformation()
    {
        StringBuilder dataBuilder = new StringBuilder();
        dataBuilder.AppendLine(string.Format("Lobby name: {0}", PhotonNetwork.CurrentLobby.Name));
        dataBuilder.AppendLine(string.Format("Room name: {0}", PhotonNetwork.CurrentRoom?.Name));
        dataBuilder.AppendLine(string.Format("Maximum number of players: {0}", PhotonNetwork.CurrentRoom.MaxPlayers));
        dataBuilder.AppendLine(string.Format("Current number of players: {0}", PhotonNetwork.CurrentRoom.PlayerCount));
        return dataBuilder.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        dataLabel.text = generateServerInformation();   
    }
}
