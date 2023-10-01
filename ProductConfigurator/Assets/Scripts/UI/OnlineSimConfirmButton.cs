using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineSimConfirmButton : ConfirmButton
{
    protected override void buttonClickAction()
    {
        updateUIAfterConfirm();
        string serialisedData = getSerialisedBeastieConfig();
        gameStateHandler.RegisterPlayer(1);
        gameStateHandler.ConfigureBeastie(true, serialisedData);
    }
}
