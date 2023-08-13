using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BeastieAuraObjectKeyValue
{
    [SerializeField]
    private AuraType key;
    public AuraType Key { get => key; }
    [SerializeField]
    private GameObject value;
    public GameObject Value { get => value; }
}
