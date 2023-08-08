using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffect
{
    public static string TypeToText(SpecialEffectType typeToConvert)
    {
        string typeText;
        switch (typeToConvert)
        {
            case SpecialEffectType.None:
                typeText = typeToConvert.ToString();
                break;
            case SpecialEffectType.Reverse:
                typeText = typeToConvert.ToString();
                break;
            case SpecialEffectType.Toxic:
                typeText = typeToConvert.ToString();
                break;
            case SpecialEffectType.DoubleHit:
                typeText = "Double Hit";
                break;
            case SpecialEffectType.Swift:
                typeText = typeToConvert.ToString();
                break;
            case SpecialEffectType.Guard:
                typeText = typeToConvert.ToString();
                break;
            default:
                throw new System.Exception("Invalid Special Effect type parsed.");
        }
        return typeText;
    }

    public static Dictionary<SpecialEffectType, int> GenerateCounterMap()
    {
        Dictionary<SpecialEffectType, int> counterMap = new Dictionary<SpecialEffectType, int>();
        counterMap.Add(SpecialEffectType.Reverse, 0);
        counterMap.Add(SpecialEffectType.Toxic, 0);
        counterMap.Add(SpecialEffectType.DoubleHit, 0);
        counterMap.Add(SpecialEffectType.Swift, 0);
        counterMap.Add(SpecialEffectType.Guard, 0);
        counterMap.Add(SpecialEffectType.None, 0);
        return counterMap;
    }
}
