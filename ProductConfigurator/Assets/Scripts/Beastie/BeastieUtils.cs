using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastieUtils
{
    public static string TypeToString(BeastieType typeToGenerate)
    {
        string beastieType;
        switch (typeToGenerate)
        {
            default:
                beastieType = typeToGenerate.ToString();
                break;
        }
        return beastieType;
    }
}
