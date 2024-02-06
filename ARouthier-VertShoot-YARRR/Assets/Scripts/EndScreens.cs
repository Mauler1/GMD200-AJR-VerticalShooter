using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreens : MonoBehaviour
{
    //button function for changing scene to title screen
    public void ChangeScene(){
        SceneManager.LoadScene(0);
    }
}
