using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Cooking Task", order = 51)]
public class CookingTask : ScriptableObject
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int pointsBase;
}
