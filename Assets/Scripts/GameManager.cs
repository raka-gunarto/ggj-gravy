using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // internal instance reference
    private static GameManager _instance;
    // public instance getter
    public static GameManager Instance { get { return _instance; } }

    public Recipe GetRandomRecipe(int currentStage)
    {
        int count = 0;
        Recipe[] stageRecipes = new Recipe[recipes.Count];
        foreach (Recipe recipe in recipes)
        {
            //check stage v.s. currentStage and filter
            stageRecipes[count++] = recipe;
        }
        return stageRecipes[(int)Math.Ceiling((double)UnityEngine.Random.Range(0, count))];
    }

    // check if there are other GameManagers, if not nominate self as GameManager
    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
            LoadAssets();
        }
    }

    private void LoadAssets()
    {
        foreach (UnityEngine.Object recipeAsset in AssetDatabase.LoadAllAssetsAtPath("Recipes"))
            recipes.Add((Recipe)recipeAsset);
    }

    public int stage = 0;
    public Recipe currentRecipe;
    public int currentRecipeTask;

    public List<float> scores;
    // public List<Item> items;
    public List<Recipe> recipes;
}
