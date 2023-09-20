using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    [SerializeField]
    private Collider tileBox;
    [SerializeField]
    private Collider borderBox;

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
