using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEventReceiver : MonoBehaviour
{
    public delegate void TileClickEvent(Vector2 tileCoordinates);
    private event TileClickEvent onClick;

    public void AddClickEvent(TileClickEvent eventToAdd)
    {
        onClick += eventToAdd;
    }

    public void RemoveClickEvent(TileClickEvent eventToRemove)
    {
        onClick -= eventToRemove;
    }

    public void HandleClickEvent(Vector2 tileCoordinates)
    {
        if (onClick != null)
        {
            onClick(tileCoordinates);
        }
    }
}
