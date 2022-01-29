using System;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    [SerializeField]
    public static CookingTask TASK;

    public Minigame()
	{
	}

    protected void CompleteTask()
    {
        int numTasks = GameManager.Instance.currentRecipe.Tasks.Length;
        if (GameManager.Instance.currentRecipeTask++ >= numTasks)
        {
            GameManager.Instance.SetPhase(new ResultsPhase());
        }
    }
}
