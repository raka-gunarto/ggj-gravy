using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Baking : Minigame
{
    public int TICKS_SPAN = 500;

    public Color HOTZONE_COLOR = new Color(1.0f, 0.5f, 0.5f, 0.9f);
    public Color HOTZONE_COLOR_HOVER = new Color(1.0f, 0.0f, 0.0f, 0.9f);

    private GameObject _parent;

    private GameObject _uiContainer;
    private GameObject _uiHotZone;

    private GameObject _oven;
    private GameObject _ingredient;

    private bool _monitoring;
    private int _ticks = 0;

    public override void Begin()
    {
        _oven.SetActive(true);
        _ingredient.SetActive(true);
        _monitoring = true;
    }

    public override void Cleanup()
    {
        _oven.SetActive(false);
        _ingredient.SetActive(false);
        _monitoring = false;
        _ticks = 0;
    }

    void Start()
    {
        _parent = gameObject;
        _uiContainer = GameObject.FindGameObjectWithTag("BakingUIContainer");
        _uiHotZone = GameObject.FindGameObjectWithTag("BakingUIHotZone");

        _oven = GetChildByName("Oven");
        _ingredient = GetChildByName("Ingredient");

        Begin();//Debug
    }

    void Update()
    {
        if (!_monitoring)
            return;

        float across;
        if (_ticks <= TICKS_SPAN)
        {
            across = _ticks / (float)TICKS_SPAN;
        }
        else
        {
            across = (TICKS_SPAN * 2 - _ticks) / (float)TICKS_SPAN;
        }

        if (_ticks > TICKS_SPAN * 2)
            _ticks = 0;

        Vector3 containerSize = _uiContainer.GetComponent<RectTransform>().rect.size;
        Vector3 containerPos = _uiContainer.transform.position;

        Vector3 zoneSize = _uiHotZone.GetComponent<RectTransform>().rect.size;
        //idk whats going on anymore but apparently this works
        Vector3 zonePos = containerPos + zoneSize / 2 - (containerSize / 2) + ((containerSize - zoneSize) * across);

        zonePos.y = containerPos.y;

        _uiHotZone.transform.position = zonePos;

        Vector3 mousePos = Input.mousePosition;

        Debug.Log(mousePos);
        Debug.Log(zonePos);

        if (mousePos.x >= (zonePos.x-zoneSize.x/2) && mousePos.x < (zonePos.x+zoneSize.x/2) &&
            mousePos.y >= (zonePos.y-zoneSize.y/2) && mousePos.y < (zonePos.y+zoneSize.y/2))
        {
            //intersecting with hot zone
            _uiHotZone.GetComponent<Image>().color = HOTZONE_COLOR_HOVER;
            if (_ticks % 25 == 0)
                _score += 1;
        } else
        {
            _uiHotZone.GetComponent<Image>().color = HOTZONE_COLOR;
        }

        if (_score > 100)
            _score = 100;

        _ticks++;
    }

    private GameObject GetChildByName(string name)
    {
        for (int i = 0; i < _parent.transform.childCount; i++)
        {
            GameObject obj = _parent.transform.GetChild(i).gameObject;
            if (obj.name.Equals(name))
            {
                return obj;
            }
            obj.SetActive(true);
        }
        throw new SystemException("Could not find " + name + " object for Baking scene!");
    }
}
