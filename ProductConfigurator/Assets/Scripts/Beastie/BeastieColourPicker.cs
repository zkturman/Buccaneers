using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastieColourPicker : MonoBehaviour
{
    private Renderer beastieModel;
    private Material defaultMaterial;
    private BeastieColourManager colourManager;

    void Awake()
    {
        beastieModel = GetComponentInChildren<Renderer>();
        colourManager = GetComponentInParent<BeastieColourManager>();
        defaultMaterial = new Material(beastieModel.material);
    }

    public void SetColourMaterial(ColourType colourToSet)
    {
        Texture2D colourTexture = colourManager.GetTexture(colourToSet);
        if (colourTexture == null)
        {
            beastieModel.material = defaultMaterial;
        }
        else
        {
            beastieModel.material = new Material(defaultMaterial);
            beastieModel.material.mainTexture = colourTexture;
        }
    }
}
