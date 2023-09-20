using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBeastieManager : MonoBehaviour
{
    [SerializeField]
    private BeastieModelPicker myBeastie;
    [SerializeField]
    private BeastieModelPicker opponentBeastie;
    [SerializeField]
    private BoardCoordinateManager gameBoard;

    public void ConfigureMyBeastie(BeastieData beastieInfo)
    {
        configureBeastie(myBeastie, beastieInfo);
    }

    public void ConfigureOpponentBeastie(BeastieData beastieInfo)
    {
        configureBeastie(opponentBeastie, beastieInfo);
    }

    private void configureBeastie(BeastieModelPicker modelToConfigure, BeastieData beastieInfo)
    {
        modelToConfigure.SelectModel(beastieInfo.AnimalType);
        modelToConfigure.SetColour(beastieInfo.Colour);
        modelToConfigure.SetAura(beastieInfo.Aura);
    }

    public void PlaceMyBeastieAtStart()
    {
        Vector3 startPosition = gameBoard.GetMyStartingCoordinates();
        placeBeastieAtCoordinates(startPosition, myBeastie.gameObject);
    }

    public void PlaceOpponentBeastieAtStart()
    {
        Vector3 startPosition = gameBoard.GetOpponentStartingCoordinates();
        placeBeastieAtCoordinates(startPosition, opponentBeastie.gameObject);
    }

    public void PlaceMyBeastie(int rowIndex, int tileIndex)
    {

    }

    public void PlaceOpponentBeastie(int rowIndex, int tileIndex)
    {

    }

    private void placeBeastieAtCoordinates(Vector3 newLocation, GameObject beastieToPlace)
    {
        Vector3 placementPosition = new Vector3(newLocation.x, beastieToPlace.transform.position.y, newLocation.z);
        beastieToPlace.transform.position = placementPosition;
    }

}
