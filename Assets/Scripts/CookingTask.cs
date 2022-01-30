using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Task", menuName = "Cooking Task", order = 51)]
public class CookingTask : ScriptableObject
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int pointsBase;
    [SerializeField]
    private string scene;

    public string Name { get { return name; } }
    public string Scene { get { return scene; } }
}
