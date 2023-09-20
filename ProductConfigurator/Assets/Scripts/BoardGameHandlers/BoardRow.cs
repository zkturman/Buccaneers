using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardRow: MonoBehaviour
{
    [SerializeField]
    private BoardTile[] rowTiles;
    public BoardTile[] RowTiles { get => rowTiles; }

    public Vector3 GetTileSize(int tileIndex)
    {
        if (tileIndex >= rowTiles.Length)
        {
            tileIndex = 0;
        }
        return RowTiles[tileIndex].GetPosition();
    }
}
