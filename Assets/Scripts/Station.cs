using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Station : MonoBehaviour
{
    public CookingTask task;
    public void Interact() {
        if (task.Name == GameManager.Instance.currentRecipe.Tasks[GameManager.Instance.currentRecipeTask].task.Name)
            SceneManager.LoadScene(task.Scene, LoadSceneMode.Additive);
    }
}
