using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateCharacter : MonoBehaviour
{
    [SerializeField]
    private StatData defaultStats;
    public StatData DefaultStats { get => defaultStats; }
    [SerializeField]
    private int currentDoubloons = 250;
    public int CurrentDoubloons { get => currentDoubloons; }
}
