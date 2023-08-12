using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastieColourManager : MonoBehaviour
{
    [SerializeField]
    private BeastieColourTextureKeyValue[] colourTextures;

    public Texture2D GetTexture(ColourType keyToRetrieve)
    {
        Texture2D foundTexture = null;
        int i = 0;
        bool isFound = false;
        while (!isFound && i < colourTextures.Length)
        {
            if (colourTextures[i].Key == keyToRetrieve)
            {
                foundTexture = colourTextures[i].Value;
                isFound = true;
            }
            i++;
        }
        return foundTexture;
    }
}
