using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frying : Minigame
{
    private GameObject _parent;

    private GameObject _minipan;
    private GameObject _window;
    private GameObject _container;

    private float _posXStart;
    private float _velocity;

    private bool begin = false;
    private bool stop = false;

    private int _ticks = 0;

    public float acceleration;

    public override void Begin()
    {
        _minipan.SetActive(true);
        _window.SetActive(true);
        begin = true;
    }

    public override void Cleanup()
    {
        _minipan.SetActive(false);
        _window.SetActive(false);
        begin = false;
    }

    void Start()
    {
        _parent = gameObject;
        _minipan = GameObject.FindGameObjectWithTag("FryingUIPan");
        _window = GameObject.FindGameObjectWithTag("FryingUIWindow");
        _container = GameObject.FindGameObjectWithTag("FryingUIContainer");

        _posXStart = _minipan.GetComponent<RectTransform>().position.x;
        Begin();//debug
    }

    void Update()
    {
        if (!begin) return;
        RectTransform panTransform = _minipan.GetComponent<RectTransform>();

        if (Input.GetKeyDown(KeyCode.E))
            stop = true;

        if (!stop)
        {
            _velocity += -Mathf.Sign(panTransform.anchoredPosition.x) * acceleration * Time.deltaTime;
            panTransform.anchoredPosition += new Vector2(_velocity * Time.deltaTime, 0);
            return;
        }

        
    }
}
