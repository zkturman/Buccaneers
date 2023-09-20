using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCoordinateManager : MonoBehaviour
{
    [SerializeField]
    private BoardRow[] gameBoard;
    
    public Vector3 GetMyStartingCoordinates()
    {
        return GetCoordinates(0, 0);
    }

    public Vector3 GetOpponentStartingCoordinates()
    {
        int lastIndex = gameBoard.Length - 1;
        return GetCoordinates(lastIndex, lastIndex);
    }

    public Vector3 GetCoordinates(int rowIndex, int tileIndex)
    {
        if (rowIndex >= gameBoard.Length)
        {
            rowIndex = 0;
        }
        return gameBoard[rowIndex].GetTileSize(tileIndex);
    }

    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < gameBoard.Length; i++)
        {
            for (int j = 0; j < gameBoard.Length; j++)
            {
                Vector3 startingPosition = GetCoordinates(i, j);
                Gizmos.DrawSphere(startingPosition, 0.05f);
            }
        }
    }

}
