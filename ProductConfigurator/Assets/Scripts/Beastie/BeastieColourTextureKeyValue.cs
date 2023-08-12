using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BeastieColourTextureKeyValue
{
    [SerializeField]
    private ColourType key;
    public ColourType Key { get => key; }

    [SerializeField]
    private Texture2D value;
    public Texture2D Value { get => value; }
}
