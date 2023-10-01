using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardRow: MonoBehaviour
{
    [SerializeField]
    private BoardTile[] rowTiles;
    public BoardTile[] RowTiles { get => rowTiles; }
    public int RowId { get; set; }

    public void SetRowIds(int rowId)
    {
        RowId = rowId;
        for (int i = 0; i < RowTiles.Length; i++)
        {
            RowTiles[i].RowId = rowId;
            RowTiles[i].ColumnId = i;
        }
    }

    public Vector3 GetTileSize(int tileIndex)
    {
        if (tileIndex >= rowTiles.Length)
        {
            tileIndex = 0;
        }
        return RowTiles[tileIndex].GetPosition();
    }

    public void HighlightMoveTile(int tileIndex)
    {
        if (tileIndex < rowTiles.Length)
        {
            if (!RowTiles[tileIndex].HasBeastie())
            {
                RowTiles[tileIndex].HighlightForMoving();
            }
        }
    }

    public void ResetHighlights()
    {
        for (int i = 0; i < RowTiles.Length; i++)
        {
            RowTiles[i].ResetHighlight();
        }
    }
}
