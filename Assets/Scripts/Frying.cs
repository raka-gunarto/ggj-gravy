using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frying : Minigame
{
    private GameObject _parent;

    public override void Begin()
    {
    }

    public override void Cleanup()
    {
    }

    void Start()
    {
        _parent = gameObject;
        Begin();//debug
    }

    void Update()
    {
        
    }
}
