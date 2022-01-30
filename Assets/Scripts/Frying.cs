using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frying : Minigame
{
    private GameObject _parent;

    private GameObject _minipan;
    private GameObject _window;
    private GameObject _container;

    private int _ticks = 0;

    public override void Begin()
    {
        _minipan.SetActive(true);
        _window.SetActive(true);
    }

    public override void Cleanup()
    {
        _minipan.SetActive(false);
        _window.SetActive(true);
    }

    void Start()
    {
        _parent = gameObject;
        _minipan = GameObject.FindGameObjectWithTag("FryingUIPan");
        _window = GameObject.FindGameObjectWithTag("FryingUIWindow");
        _container = GameObject.FindGameObjectWithTag("FryingUIContainer");

        //Begin();//debug
    }

    void Update()
    {
        if (_ticks++ > (60*3))
        {
            GameObject.FindGameObjectWithTag("Timertext");
            GameObject obj;
        }
    }
}
