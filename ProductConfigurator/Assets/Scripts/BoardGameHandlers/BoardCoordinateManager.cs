using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCoordinateManager : MonoBehaviour
{
    [SerializeField]
    private BoardRow[] gameBoard;

    private void Awake()
    {
        for (int i = 0; i < gameBoard.Length; i++)
        {
            gameBoard[i].SetRowIds(i);  
        }
    }

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

    public void HighlightMoveTiles(Vector2 startingPosition, int range)
    {
        int minRow = getMinIndex((int)startingPosition.x, range);
        int minCol = getMinIndex((int)startingPosition.x, range);
        int maxRow = getMaxIndex((int)startingPosition.y, range);
        int maxCol = getMaxIndex((int)startingPosition.y, range);
        for (int i = minRow; i <= maxRow; i++)
        {
            for (int j = minCol; j <= maxCol; j++)
            {
                if (i + j < range)
                {
                    gameBoard[i].HighlightMoveTile(j);
                }
            }
        }
    }

    private int getMinIndex(int startingIndex, int range)
    {
        int minIndex = startingIndex - range;
        if (minIndex < 0)
        {
            minIndex = 0;
        }
        return minIndex;
    }

    private int getMaxIndex(int startingIndex, int range)
    {
        int maxIndex = startingIndex + range;
        if (maxIndex >= gameBoard.Length)
        {
            maxIndex = gameBoard.Length - 1;
        }
        return maxIndex;
    }

    public void ResetBoardHighlights()
    {
        for (int i = 0; i < gameBoard.Length; i++)
        {
            gameBoard[i].ResetHighlights();
        }
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
