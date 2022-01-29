using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe", order = 51)]
public class Recipe : ScriptableObject
{
    [SerializeField]
    private string name;
    [SerializeField]
    private Texture foodTex;
    [System.Serializable]
    public struct Task {
        public CookingTask task;
        public Ingredient[] ingredients;
    }
    [SerializeField]
    private Task[] tasks;
}
