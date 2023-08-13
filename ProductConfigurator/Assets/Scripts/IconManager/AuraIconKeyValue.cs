using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class AuraIconKeyValue
{
    [SerializeField]
    private AuraType type;
    public AuraType Type { get => type; }
    [SerializeField]
    private Sprite value;
    public Sprite Value { get => value; }
}
