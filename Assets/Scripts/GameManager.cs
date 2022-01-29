using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // internal instance reference
    private static GameManager _instance;
    // public instance getter
    public static GameManager Instance { get { return _instance; } }

    // check if there are other GameManagers, if not nominate self as GameManager
    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    public int stage;
    public int level;
    public Recipe currentRecipe;
    public int currentRecipeTask;

    public float score;
    public List<Item> items;
}
