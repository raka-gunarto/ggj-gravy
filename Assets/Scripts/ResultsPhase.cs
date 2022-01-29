using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsPhase : GamePhase
{
    public override void Start()
    {
        //show customer
        //show plate
        //show results gui e.g. happy face etc.
        //wait for input
        GameManager.Instance.SetPhase(new CookingPhase());
    }

    public override void Stop()
    {
        //
    }
}
