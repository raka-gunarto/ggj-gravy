using System;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    [SerializeField]
    public static CookingTask TASK;

    public Recipe.Task task;

    public Minigame()
	{
	}

    public abstract void Begin();

    public abstract void Cleanup();

    protected void CompleteTask()
    {
        Cleanup();

        int numTasks = GameManager.Instance.currentRecipe.Tasks.Length;
        if (GameManager.Instance.currentRecipeTask++ >= numTasks)
        {
            
        }
    }
}
