using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int CustomerQueueSize = 10;
    public double CustomerQueueOffset = 0;

    public int CustomerAnimateDuration = 80;

    public List<GameObject> customerQueue = new List<GameObject>();

    // internal instance reference
    private static GameManager _instance;
    // public instance getter
    public static GameManager Instance { get { return _instance; } }

    private int _ticks;
    private int _animstart;
    private Vector3 _startpos;

    public Recipe GetRandomRecipe(int currentStage)
    {
        int count = 0;
        Recipe[] stageRecipes = new Recipe[recipes.Count];
        foreach (Recipe recipe in recipes)
        {
            //check stage v.s. currentStage and filter
            stageRecipes[count++] = recipe;
        }
        return stageRecipes[(int)System.Math.Ceiling((double)UnityEngine.Random.Range(0, count))];
    }

    public Sprite[] faces;
    public Sprite[] eyes;
    public Sprite[] hairs;
    public Sprite[] mouths;
    public Sprite[] accessories;
    public Sprite[] noses;
    public GameObject customerprefab;

    GameObject CreateCharacter()
    {
        GameObject newCharacter = GameObject.Instantiate(customerprefab);
        Transform newCharacterTransform = newCharacter.GetComponent<Transform>();
        newCharacter.transform.Find("Head").GetComponent<SpriteRenderer>().sprite = faces[Random.Range(0, faces.Length - 1)];
        newCharacter.transform.Find("Eyes").GetComponent<SpriteRenderer>().sprite = eyes[Random.Range(0, eyes.Length - 1)];
        newCharacter.transform.Find("Hair").GetComponent<SpriteRenderer>().sprite = hairs[Random.Range(0, hairs.Length - 1)];
        newCharacter.transform.Find("Mouth").GetComponent<SpriteRenderer>().sprite = mouths[Random.Range(0, mouths.Length - 1)];
        if (Random.Range(0, 1) <= 0.5)
            newCharacter.transform.Find("Accessories").GetComponent<SpriteRenderer>().sprite = accessories[Random.Range(0, accessories.Length - 1)];
        newCharacter.transform.Find("Nose").GetComponent<SpriteRenderer>().sprite = noses[Random.Range(0, noses.Length - 1)];

        return newCharacter;
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

        GameObject lineStart = GameObject.FindGameObjectWithTag("CustomerLine");
        for (int i = 0; i < CustomerQueueSize; i++)
        {
            GameObject obj = CreateCharacter();
            Vector3 pos = lineStart.transform.position + new Vector3((float)(CustomerQueueOffset * i), 0, 0);
            Debug.Log(pos);
            obj.SetActive(true);
            obj.transform.position = pos;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (_animstart == -1)
                AnimateQueue();
        }
    }

    public void AnimateQueue()
    {
        _animstart = _ticks;
        _startpos = customerQueue[0].transform.position;
        Debug.Log("animate");
    }

    private void Update()
    {
        _ticks++;
        if (_animstart != -1)
        {
            int elapsed = _ticks - _animstart;
            double progress = elapsed / CustomerAnimateDuration;
            if (progress >= 1.0)
            {
                _animstart = -1;
                return;
            }
            Vector3 frontPos = _startpos + new Vector3((float) (-progress * CustomerQueueOffset), 0, 0);
            for (int i = 0; i < customerQueue.Count; i++)
            {
                customerQueue[i].transform.position = frontPos - new Vector3((float) (i * CustomerQueueOffset), 0, 0);
            }
        }
    }

    private void LoadAssets()
    {
        Debug.Log("here");
        foreach(var assetGUID in AssetDatabase.FindAssets("t:Recipe"))
            recipes.Add(AssetDatabase.LoadAssetAtPath<Recipe>(AssetDatabase.GUIDToAssetPath(assetGUID)));
    }

    public int stage = 0;
    public Recipe currentRecipe;
    public int currentRecipeTask;

    public List<float> scores;
    // public List<Item> items;
    public List<Recipe> recipes;
}
