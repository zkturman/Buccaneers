using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastieColourPicker : MonoBehaviour
{
    [SerializeField]
    private Renderer beastieModel;
    private Material defaultMaterial;

    void Awake()
    {
        defaultMaterial = getDefaultMaterial();
    }

    public void SetColourMaterial(Texture2D textureToSet)
    {
        if (textureToSet == null)
        {
            beastieModel.material = getDefaultMaterial();
        }
        else
        {
            beastieModel.material = new Material(defaultMaterial);
            beastieModel.material.mainTexture = textureToSet;
        }
    }

    private Material getDefaultMaterial()
    {
        if (defaultMaterial == null) 
        {
            defaultMaterial = new Material(beastieModel.material);
        }
        return defaultMaterial;
    }
}
