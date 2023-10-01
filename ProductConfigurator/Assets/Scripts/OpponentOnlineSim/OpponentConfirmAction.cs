using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentConfirmAction : MonoBehaviour
{
    [SerializeField]
    private BeastieType beastieType;
    [SerializeField]
    private ColourType colour;
    [SerializeField]
    private AuraType aura;

    public void ConfirmOpponent()
    {
        BeastieData beastieConfig = new BeastieData(beastieType, colour, aura);
        BeastieConfigSerialiser serialiser = new BeastieConfigSerialiser();
        string serialisedConfig = serialiser.SerialiseBeastieData(beastieConfig);
        BaseGameStateHandler gameStateHandler = FindObjectOfType<BaseGameStateHandler>();
        gameStateHandler.RegisterPlayer(0);
        gameStateHandler.ConfigureBeastie(false, serialisedConfig);
    }
}
