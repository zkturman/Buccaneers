using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ColourFieldData : BaseFieldData
{
    [SerializeField]
    private ColourType colour;
    public ColourType Colour { get => colour; }
    public override string Name { get => colour.ToString(); }
}
