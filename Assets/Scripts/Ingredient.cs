using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient", order = 51)]
public class Ingredient : ScriptableObject
{
    [SerializeField]
    private string name;
    [SerializeField]
    private Texture tex;

    public Texture Tex { get { return tex; } }
}
