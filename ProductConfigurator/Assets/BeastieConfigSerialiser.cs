using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class BeastieConfigSerialiser
{
    private char delimiter = '|';
    public BeastieConfigSerialiser() { }
    public string SerialiseBeastieData(BeastieData dataToSerialise)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(dataToSerialise.AnimalType);
        builder.Append(delimiter);
        builder.Append(dataToSerialise.Colour);
        builder.Append(delimiter);
        builder.Append(dataToSerialise.Aura);
        return builder.ToString();
    }

    public BeastieData DeserialiseBeasieData(string dataToDeserialise)
    {
        BeastieType configBeastie = BeastieType.None;
        ColourType configColour = ColourType.None;
        AuraType configAura = AuraType.None;
        string[] dataPieces = dataToDeserialise.Split(delimiter);
        if (dataPieces.Length == 3)
        {
            configBeastie = StringToBeastieType(dataPieces[0]);
            configColour = StringToColourType(dataPieces[1]);
            configAura = StringToAuraType(dataPieces[2]);
        }
        return new BeastieData(configBeastie, configColour, configAura);
    }

    private BeastieType StringToBeastieType(string typeName)
    {
        object convertedType;
        BeastieType beastieValue;
        if (Enum.TryParse(typeof(BeastieType), typeName, out convertedType))
        {
            beastieValue = (BeastieType)convertedType;
        }
        else
        {
            beastieValue = BeastieType.None;
        }
        return beastieValue;

    }

    private ColourType StringToColourType(string typeName)
    {
        object convertedType;
        ColourType colourValue;
        if (Enum.TryParse(typeof(ColourType), typeName, out convertedType))
        {
            colourValue = (ColourType)convertedType;
        }
        else
        {
            colourValue = ColourType.None;
        }
        return colourValue;
    }

    private AuraType StringToAuraType(string typeName)
    {
        object convertedType;
        AuraType auraValue;
        if (Enum.TryParse(typeof(AuraType), typeName, out convertedType))
        {
            auraValue = (AuraType)convertedType;
        }
        else
        {
            auraValue = AuraType.None;
        }
        return auraValue;
    }
}
