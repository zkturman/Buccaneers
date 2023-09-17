using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cinemachine;
using Photon.Pun;
public class ConfirmConfigManager : MonoBehaviour
{
    [SerializeField]
    private string confirmButtonName;
    private Button confirmButton;
    [SerializeField]
    private CinemachineVirtualCamera waitingCamera;
    [SerializeField]
    private GameObject configMenu;
    [SerializeField]
    private UIUpdateController uiController;

    private void OnEnable()
    {
        VisualElement rootElement = GetComponent<UIDocument>().rootVisualElement;
        confirmButton = rootElement.Q<Button>(confirmButtonName);
        confirmButton.clicked += buttonClickAction;
    }

    private void buttonClickAction()
    {
        waitingCamera.Priority = 100;
        configMenu.SetActive(false);
        BeastieData configData = uiController.GetCurrentBeastieConfig();
        BeastieConfigSerialiser dataSerialiser = new BeastieConfigSerialiser();
        string serialisedData = dataSerialiser.SerialiseBeastieData(configData);
        GameStateHandler gameStateHandler = FindObjectOfType<GameStateHandler>();
        int playerId = PhotonNetwork.LocalPlayer.ActorNumber;
        gameStateHandler.photonView.RPC("ConfigureBeastie", RpcTarget.All, playerId, serialisedData);
        gameStateHandler.photonView.RPC("RegisterPlayer", RpcTarget.All, playerId);
    }
}
