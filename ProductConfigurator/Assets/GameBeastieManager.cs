using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBeastieManager : MonoBehaviour
{
    [SerializeField]
    private BeastieModelPicker myBeastie;
    [SerializeField]
    private BeastieModelPicker opponentBeastie;

    public void ConfigureMyBeastie(BeastieData beastieInfo)
    {
        configureBeastie(myBeastie, beastieInfo);
    }

    public void ConfigureOpponentBeastie(BeastieData beastieInfo)
    {
        configureBeastie(opponentBeastie, beastieInfo);
    }

    private void configureBeastie(BeastieModelPicker modelToConfigure, BeastieData beastieInfo)
    {
        modelToConfigure.SelectModel(beastieInfo.AnimalType);
        modelToConfigure.SetColour(beastieInfo.Colour);
        modelToConfigure.SetAura(beastieInfo.Aura);
    }
}
