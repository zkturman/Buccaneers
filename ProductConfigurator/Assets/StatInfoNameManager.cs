using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatInfoNameManager : MonoBehaviour
{
    [SerializeField]
    private string healthStatValueName = "HealthStatValue";
    public string HealthStatValueName { get => healthStatValueName; }

    [SerializeField]
    private string healthStatBonusName = "HealthStatBonus";
    public string HealthStatBonusName { get => healthStatBonusName; }
    
    [SerializeField]
    private string speedStatValueName = "SpeedStatValue";
    public string SpeedStatValueName { get => speedStatValueName; }
    
    [SerializeField]
    private string speedStatBonusName = "SpeedStatBonus";
    public string SpeedStatBonusName { get => speedStatBonusName; }

    [SerializeField]
    private string attackStatValueName = "AttackStatValue";
    public string AttackStatValueName { get => attackStatValueName; }

    [SerializeField]
    private string attackStatBonusName = "AttackStatBonus";
    public string AttackStatBonusName { get => AttackStatBonusName; }

    [SerializeField]
    private string rangeStatValueName = "RangeStatValue";
    public string RangeStatValueName { get => rangeStatValueName; }

    [SerializeField]
    private string rangeStatBonuseName = "RangeStatBonus";
    public string RangeStatBonusName { get => rangeStatBonuseName; }

    public static StatInfoNameManager Names;

    void Awake()
    {
        Names = this;
    }
}
