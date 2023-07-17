using UnityEngine;
using System;

public class EffectIconKeyValue : MonoBehaviour
{
    [SerializeField]
    private SpecialEffectType type;
    public SpecialEffectType Type { get => type; }
    [SerializeField]
    private Sprite value;
    public Sprite Value { get => value; }
}
