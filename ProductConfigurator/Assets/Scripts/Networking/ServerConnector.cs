using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Cinemachine;


public class ServerConnector : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    [SerializeField]
    private GameObject connectingMenu;
    [SerializeField]
    private GameObject lobbyInfoMenu;
    [SerializeField]
    private GameObject loadingMenu;
    [SerializeField]
    private int secondsOfInactivityBeforeDisconnect = 10;
    private const int MAX_PLAYERS = 2;
    [SerializeField]
    private CinemachineVirtualCamera menuCamera;


    void Start()
    {
        connectingMenu.SetActive(true);
        lobbyInfoMenu.SetActive(false);
        DontDestroyOnLoad(gameObject);
        PhotonNetwork.ConnectUsingSettings();
    }
    private void Update()
    {
        PhotonNetwork.NetworkingClient.Service();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        createRoomWithMaxPlayers(MAX_PLAYERS);
    }

    private void createRoomWithMaxPlayers(byte maxNumberOfPlayers)
    {
        RoomOptions roomSettings = new RoomOptions();
        roomSettings.MaxPlayers = 2;
        roomSettings.PlayerTtl = 1000 * secondsOfInactivityBeforeDisconnect;
        roomSettings.PublishUserId = true;
        PhotonNetwork.JoinRandomOrCreateRoom(null, 0, MatchmakingMode.FillRoom, null, null, null, roomSettings);
    }

    public override void OnJoinedRoom()
    {
        connectingMenu.SetActive(false);
        lobbyInfoMenu.SetActive(true);
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            startGame();
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Room currentRoom = PhotonNetwork.CurrentRoom;
        if (currentRoom.PlayerCount == MAX_PLAYERS)
        {
            startGame();
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Player left the room");
    }

    private void startGame()
    {
        lobbyInfoMenu.SetActive(false);
        loadingMenu.SetActive(true);
        menuCamera.Priority = 0;
    }
}
