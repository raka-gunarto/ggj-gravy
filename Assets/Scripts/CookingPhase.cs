using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookingPhase : GamePhase
{
    public override void Start()
    {
        //switch to kitchen scene
        Scene cookingScene = SceneManager.GetSceneByName("Kitchen");
        SceneManager.SetActiveScene(cookingScene);
        //generate new customer
        //pick new recipe
        
        //enable menus
    }

    public override void Stop()
    {
        //hide kitchen,player,recipe gui
    }
}
