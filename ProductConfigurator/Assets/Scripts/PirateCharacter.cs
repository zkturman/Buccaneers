using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PirateCharacter : MonoBehaviourPun
{
    [SerializeField]
    private StatData defaultStats;
    public StatData DefaultStats { get => defaultStats; }
    [SerializeField]
    private int currentDoubloons = 250;
    public int CurrentDoubloons { get => currentDoubloons; }

    public void SetBeastie(BeastieData beastieInfo)
    {

    }
}
