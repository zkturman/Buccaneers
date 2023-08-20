using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class ServerConnector : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        createRoomWithMaxPlayers(2);
    }

    private void createRoomWithMaxPlayers(byte maxNumberOfPlayers)
    {
        RoomOptions roomSettings = new RoomOptions();
        roomSettings.MaxPlayers = 2;
        PhotonNetwork.JoinRandomOrCreateRoom(null, 0, MatchmakingMode.FillRoom, null, null, null, roomSettings);
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("LobbyJoining");
    }
}
