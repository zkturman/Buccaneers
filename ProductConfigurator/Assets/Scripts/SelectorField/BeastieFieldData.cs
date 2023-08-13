using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BeastieFieldData : BaseFieldData
{
    [SerializeField]
    private BeastieType type;
    public BeastieType Type { get => type; }
    public override string Name { get => BeastieUtils.TypeToString(type); }

    [SerializeField]
    private ColourType[] availableColours;
    public ColourType[] AvailableColours { get => availableColours; }

    [SerializeField]
    private AuraType[] availableAuras;
    public AuraType[] AvailableAura { get => availableAuras; }
}
