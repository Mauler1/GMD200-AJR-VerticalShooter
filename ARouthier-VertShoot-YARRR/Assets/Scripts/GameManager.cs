using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public BoxCollider2D topSpawner;

    public BoxCollider2D sideSpawner;

    public SpawnVertEnemy script;


    private int score = 0;

    private bool canSpawn = true;

    [SerializeField] private TextMeshProUGUI scoreText;

//maxs parts



    private void Awake(){
        instance = this;

    }

    void Update(){
        if(canSpawn){
            StartCoroutine(CoVertEnemy());
        }
        scoreText.text = score.ToString();
    }

    private IEnumerator CoVertEnemy(){
        canSpawn = false;
        for(int i = 0; i < 1; i++){
            script.SpawnEnemy();
            yield return new WaitForSeconds(2f);
        }
        canSpawn = true;
    }

    public void addPoint(){
        score++;
    }



    //UI Button Functions
    public void GameStartUI(){
   SceneManager.LoadScene(0);
    }
    public void GameEndUI(){

    }




}
