using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item", order = 51)]
public class Item : ScriptableObject
{
    [SerializeField]
    private string name;
    [SerializeField]
    private string taskAffect;
    [SerializeField]
    private float effectMagnitude;

    public enum EffectorType
    {
        DIFFICULTY,
        SCORE
    }
}
