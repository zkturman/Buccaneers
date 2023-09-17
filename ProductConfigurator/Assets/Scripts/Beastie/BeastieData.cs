using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastieData
{
    public BeastieType AnimalType { get; private set; }
    public ColourType Colour { get; private set; }
    public AuraType Aura { get; private set; }
    
    public BeastieData(BeastieType animalType, ColourType colour, AuraType aura) 
    {
        AnimalType = animalType;
        Colour = colour;
        Aura = aura;
    }

}
