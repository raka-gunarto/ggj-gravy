using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Minigame : MonoBehaviour
{
    [SerializeField]
    public static CookingTask TASK;

    public Recipe.Task task;

    protected int _score;

    public Minigame()
    {
    }

    public abstract void Begin();

    public abstract void Cleanup();

    protected void CompleteTask()
    {
        Cleanup();
        GameManager.Instance.currentRecipeTask++;
        GameManager.Instance.scores.Add(_score);

        GameObject.FindGameObjectWithTag("Player").transform.Find("Station Camera").gameObject.SetActive(false);
        SceneManager.UnloadSceneAsync(this.gameObject.scene);
    }
}
