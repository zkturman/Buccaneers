using Photon.Pun;
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
        PhotonNetwork.JoinRandomOrCreateRoom(null, maxNumberOfPlayers);
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("LobbyJoining");
    }
}
