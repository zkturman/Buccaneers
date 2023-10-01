using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    [SerializeField]
    private Collider tileBox;
    [SerializeField]
    private Collider borderBox;
    [SerializeField]
    private TileHighlighter highlighter;
    private bool isTileAvailable = false;

    public int RowId { get; set; }
    public int ColumnId { get; set; }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public bool HasBeastie()
    {
        bool hasBeastie = false;
        if (Physics.Raycast(transform.position, transform.up, out RaycastHit hitInfo, Mathf.Infinity))
        {
            if (hitInfo.collider.gameObject.TryGetComponent<BeastieModelPicker>(out BeastieModelPicker modelPicker))
            {
                hasBeastie = true;
            }
        }
        return hasBeastie;
    }

    public void HighlightForMoving()
    {
        isTileAvailable = true;
        highlighter.HighlightTileForMoving();
    }

    public void ResetHighlight()
    {
        isTileAvailable = false;
        highlighter.ResetHighlight();
    }

    private void OnMouseDown()
    {
        if (isTileAvailable)
        {
            BoardEventReceiver eventReceiver = FindObjectOfType<BoardEventReceiver>();
            eventReceiver.HandleClickEvent(new Vector2(RowId, ColumnId));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(transform.position, transform.up);
    }
}
