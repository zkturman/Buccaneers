using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnContext : MonoBehaviour
{
    [SerializeField]
    private BoardCoordinateManager gameBoard;
    public BoardCoordinateManager GameBoard { get => gameBoard; }

    [SerializeField]
    private BoardEventReceiver eventReceiver;
    public BoardEventReceiver EventReceiver { get => eventReceiver; }

    [SerializeField]
    private GameBeastieManager beastieBoardManager;
    public GameBeastieManager BeastieBoardManager { get => beastieBoardManager; }

    [SerializeField]
    private GameObject myBeastie;
    public GameObject MyBeastie { get => myBeastie; }

    [SerializeField]
    private GameObject opponentBeastie;
    public GameObject OpponentBeastie { get => opponentBeastie; }

    [SerializeField]
    private ActionSimulator simulator;
    public ActionSimulator Simulator { get => simulator; }
}
