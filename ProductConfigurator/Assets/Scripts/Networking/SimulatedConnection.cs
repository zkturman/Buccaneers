using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulatedConnection : ConnectionCreator
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        startGame();
    }
}
