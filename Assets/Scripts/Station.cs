using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Station : MonoBehaviour
{
    public CookingTask task;
    public void Interact()
    {
        if (task.Name != GameManager.Instance.currentRecipe.Tasks[GameManager.Instance.currentRecipeTask].task.Name)
        {
            //wrong task, yell at them
            return;
        }

        // camera transition
        GameObject.FindGameObjectWithTag("Player").transform.Find("Station Camera").gameObject.SetActive(true);
        
        // load scene
        SceneManager.LoadScene(task.Scene, LoadSceneMode.Additive);
        Minigame minigame = GameObject.FindGameObjectWithTag("MinigameController").GetComponent<Minigame>();
        minigame.task =
            GameManager.Instance.currentRecipe.Tasks[GameManager.Instance.currentRecipeTask];
        minigame.Begin();
    }
}
