using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class GameInitialiser : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera gameCamera;
    [SerializeField]
    private int startCameraPriority = 200;
    [SerializeField]
    private GameObject[] objectsToEnableAtRegistered;
    [SerializeField]
    private GameObject[] objectsToDisableAtRegistered;
    [SerializeField]
    private GameObject[] objectsToEnableAtStart;
    [SerializeField]
    private GameObject[] objectsToDisableAtStart;
    [SerializeField]
    private PirateCharacter pirateInfo;
    private StatInfoDisplay statInfo;
    private DoubloonCostManager costManager;
    private GameBeastieManager beastieManager;

    private void Start()
    {
        statInfo = FindObjectOfType<StatInfoDisplay>(true);
        statInfo.PirateInfo = pirateInfo;
        costManager = FindObjectOfType<DoubloonCostManager>(true);
        costManager.PirateInfo = pirateInfo;
        beastieManager = FindObjectOfType<GameBeastieManager>();
    }

    public void ShowRegisteredWaitScene()
    {
        for (int i = 0; i < objectsToEnableAtRegistered.Length; i++)
        {
            objectsToEnableAtRegistered[i].SetActive(true);
        }
        for (int i = 0; i < objectsToDisableAtRegistered.Length; i++)
        {
            objectsToDisableAtRegistered[i].SetActive(false);
        }
        beastieManager.PlaceMyBeastieAtStart();
    }

    public void StartGame()
    {
        gameCamera.Priority = startCameraPriority;
        for (int i = 0; i < objectsToEnableAtStart.Length; i++)
        {
            objectsToEnableAtStart[i].SetActive(true);
        }
        for (int i =0; i < objectsToDisableAtStart.Length; i++)
        {
            objectsToDisableAtStart[i].SetActive(false);
        }
        beastieManager.PlaceMyBeastieAtStart();
        beastieManager.PlaceOpponentBeastieAtStart();
    }
}
