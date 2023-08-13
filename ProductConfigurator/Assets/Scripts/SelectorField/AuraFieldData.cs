using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class AuraFieldData : BaseFieldData
{
    [SerializeField]
    private AuraType aura;
    public AuraType Aura { get => aura; }

    public override string Name { get => aura.ToString(); }
}
