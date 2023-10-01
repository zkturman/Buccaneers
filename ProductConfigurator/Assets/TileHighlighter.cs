using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlighter : MonoBehaviour
{
    [SerializeField]
    private Renderer tileRender;
    private Color defaultColor;
    [SerializeField]
    private Color highlightColor = Color.yellow;

    private void Awake()
    {
        defaultColor = tileRender.material.color;
        tileRender.material = new Material(tileRender.material);     
    }

    public void HighlightTileForMoving()
    {
        tileRender.material.color = highlightColor;
    }

    public void ResetHighlight()
    {
        tileRender.material.color = defaultColor;
    }
}
