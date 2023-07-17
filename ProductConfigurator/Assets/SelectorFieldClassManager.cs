using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorFieldClassManager : MonoBehaviour
{
    [SerializeField]
    private string nameLabelClass = "NameLabel";
    public string NameLabelClass { get => nameLabelClass; }
    [SerializeField]
    private string mainIconClass = "MainIcon";
    public string MainIconClass { get => mainIconClass; }
    [SerializeField]
    private string effectIconClass = "SpecialEffectIcon";
    public string EffectIconClass { get => effectIconClass; }
    [SerializeField]
    private string statBonusValueClass = "StatBonusValue";
    public string StatBonusValueClass { get => statBonusValueClass; }
    [SerializeField]
    private string statBonusIconClass = "StatBonusIcon";
    public string StatBonusIconClass { get => statBonusIconClass; }
    [SerializeField]
    private string costLabelClass = "CostLabel";
    public string CostLabelClass { get => costLabelClass; }

}
