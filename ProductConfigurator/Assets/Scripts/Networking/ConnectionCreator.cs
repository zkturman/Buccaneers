using UnityEngine;
using Cinemachine;
using Photon.Pun;
using Photon.Realtime;

public class ConnectionCreator : MonoBehaviourPunCallbacks, IInRoomCallbacks
{ 
    [SerializeField]
    protected GameObject connectingMenu;
    [SerializeField]
    protected GameObject lobbyInfoMenu;
    [SerializeField]
    protected GameObject loadingMenu;
    [SerializeField]
    protected CinemachineVirtualCamera menuCamera;

    protected virtual void Start()
    {
        connectingMenu.SetActive(true);
        lobbyInfoMenu.SetActive(false);
    }

    protected void startGame()
    {
        connectingMenu.SetActive(false);
        lobbyInfoMenu.SetActive(false);
        loadingMenu.SetActive(true);
        menuCamera.Priority = 0;
    }
}
