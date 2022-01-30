using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chopping : Minigame
{
    private bool _monitoring = false;
    private bool _mousedown = false;
    private int _linecount = 0;

    private UnityEngine.GameObject _parent;
    private List<UnityEngine.GameObject> rendererObjects = new List<UnityEngine.GameObject>();

    private Vector3 _mousedownPos;

    private int _score = 100;

    public override void Begin()
    {
        //update ingredient texture
        GameObject ingredient = GetIngredientObject();
        SpriteRenderer sprite = ingredient.GetComponent<SpriteRenderer>();
        MaterialPropertyBlock b = new MaterialPropertyBlock();
        b.SetTexture("_MainTex", task.ingredients[0].Tex);
        sprite.SetPropertyBlock(b);
        //show sprite
        ingredient.SetActive(true);

        _monitoring = true;
    }

    public override void Cleanup()
    {
        _monitoring = false;
        _mousedown = false;
        foreach (GameObject rendererObject in rendererObjects)
        {
            Destroy(rendererObject);
        }
        //hide ingredient
        GetIngredientObject().SetActive(false);
    }

    private void Start()
    {
        _parent = gameObject;
        Begin();
    }

    void Update()
    {
        if (!_mousedown && Input.GetMouseButtonDown(0))
        {
            _mousedown = true;
            _mousedownPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (_mousedown && Input.GetMouseButtonUp(0))
        {
            Vector3 p2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            DrawLine(_mousedownPos, p2);
            double angle = GetAngle(_mousedownPos, p2);
            _score -= (int) (50 * (angle / 30.0));
            _score = Math.Max(_score, 0);
            Debug.Log(_score.ToString());
            _mousedown = false;

            if (_linecount >= 3)
            {
                _monitoring = false;
                //base.CompleteTask();
            }
        }
    }

    private void DrawLine(Vector3 p1, Vector3 p2)
    {
        LineRenderer renderer = new GameObject().AddComponent<LineRenderer>();
        renderer.gameObject.transform.SetParent(transform);
        renderer.gameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        rendererObjects.Add(renderer.gameObject);
        //idk but they were -10 so fk it B)
        p1.z = -1;
        p2.z = -1;
        renderer.SetPosition(0, p1);
        renderer.SetPosition(1, p2);
        renderer.startWidth = 0.2f;
        renderer.endWidth = 0.2f;
        _linecount++;
    }

    private double GetAngle(Vector3 p1, Vector3 p2)
    {
        Vector3 delta = p1 - p2;
        Vector3 up = new Vector3(0, 1, 0);
        return Vector3.Angle(delta, up);
    }

    private GameObject GetIngredientObject()
    {
        for (int i = 0; i < _parent.transform.childCount; i++)
        {
            GameObject obj = _parent.transform.GetChild(i).gameObject;
            if (obj.name.Equals("Ingredient"))
            {
                return obj;
            }
            obj.SetActive(true);
        }
        throw new SystemException("Could not find Ingredient object for Chopping scene!");
    }
}
