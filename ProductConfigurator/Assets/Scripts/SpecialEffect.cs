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
}
