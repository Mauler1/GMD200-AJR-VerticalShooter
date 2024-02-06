using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    //Button function for changing scene to game scene
    public void ChangeScene(){
        SceneManager.LoadScene(1);
    }

    //can actually escape the game :O
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
