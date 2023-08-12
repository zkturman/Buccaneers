using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BeastieModelKeyValue
{
    [SerializeField]
    private BeastieType key;
    public BeastieType Key { get => key; }
    [SerializeField]
    private GameObject model;
    public GameObject Model { get => model; }
}
