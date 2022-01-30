using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixing : Minigame
{
    public const float FRICTION = 0.8f;
    public const int SHAKE_FOR_SCORE = 50;
    public const int SCORE_PER_SHAKE = 1;
    public const int MAX_SCORE = 100;

    private bool _monitoring = false;

    private GameObject _parent;
    private GameObject _bowl;
    private Vector3 _center;

    private double _lastangle = 0;
    private double _shake;

    private Vector3 _offset = Vector3.zero;

    private int _ticks;
    public override void Begin()
    {
        _bowl = GetMixingBowl();
        _bowl.SetActive(true);
        _center = _bowl.transform.position;

        _monitoring = true;
    }

    public override void Cleanup()
    {
        _monitoring = false;
        _ticks = 0;
        _score = 0;

        _bowl.SetActive(false);
    }

    void Start()
    {
        _parent = gameObject;
        //Begin();//debug
    }

    void Update()
    {
        if (!_monitoring)
            return;
        _shake *= FRICTION;

        //this is the most weird cursed maths ive ever written

        double angle = getAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        double delta =
            _lastangle > 180 && angle < 50 // guess if we've crossed 360 (wrap-around value)
            ? (360 - _lastangle) + angle // get cross-wrap delta
            : _lastangle - angle;
        _shake += 10 * delta;

        if (_shake > 100)
            _shake = 100;

        //downscale offset based on current size
        float size = Vector3.Magnitude(_offset);
        if (size > 1)
        {
            _offset /= size;
        }
        else if (size > 0.2)
        {
            _offset *= size;
        }

        //pick random direction and add offset to 'shake'
        if (_ticks++ % 30 == 0)
        {
            Vector3 shakeby = UnityEngine.Random.insideUnitSphere.normalized;
            shakeby.Scale(new Vector3((float)_shake / 100, (float)_shake / 100, 0));
            _offset += shakeby;

            if (_shake > SHAKE_FOR_SCORE)
                _score += SCORE_PER_SHAKE;
            if (_score > MAX_SCORE)
                _score = MAX_SCORE;
        }

        //update position
        _bowl.transform.position = _center + _offset;

        Debug.Log(_score);

        _lastangle = angle;
    }

    private GameObject GetMixingBowl()
    {
        for (int i = 0; i < _parent.transform.childCount; i++)
        {
            GameObject obj = _parent.transform.GetChild(i).gameObject;
            if (obj.name.Equals("MixingBowl"))
            {
                return obj;
            }
            obj.SetActive(true);
        }
        throw new SystemException("Could not find MixingBowl object for Mixing scene!");
    }

    private double getAngle(Vector3 point)
    {
        point.z = 0;//lol
        Vector3 delta = point - _center;
        return Vector3.SignedAngle(new Vector3(0, 1, 0), delta, new Vector3(0, 0, -1))+180;
    }
}
