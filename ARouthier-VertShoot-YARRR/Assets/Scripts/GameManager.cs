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

    [SerializeField] private TextMeshProUGUI timerText;

    public float timer = 240.0f;

    private bool timeRunning = false;

    private void OnEnable(){
        PlayerHealth.healthChanged += HealthChange;
    }

    private void OnDisable(){
        PlayerHealth.healthChanged -= HealthChange;
    }

    private void Awake(){
        instance = this;
    }

    void Start(){
        timeRunning = true;
    }

    void Update(){
        if(canSpawn){
            StartCoroutine(CoVertEnemy());
        }
        scoreText.text = score.ToString();
        timerText.text = TimerFormat(timer);
        if(timeRunning){
            if(timer > 0){
                timer -= Time.deltaTime;
            }
            else{
                SceneManager.LoadScene(2);
            }
        }
    }

    private IEnumerator CoVertEnemy(){
        canSpawn = false;
        for(int i = 0; i < 1; i++){
            script.SpawnEnemy();
            yield return new WaitForSeconds(1.5f);
        }
        canSpawn = true;
    }

    public void addPoint(){
        score++;
    }

    private string TimerFormat(float timer){
        float minutes = Mathf.FloorToInt(timer/60);
        float seconds = Mathf.FloorToInt(timer%60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void HealthChange(int obj){
        SceneManager.LoadScene(3);
    }


    /*
    //UI Button Functions
    public void GameStartUI(){
   SceneManager.LoadScene(0);
    }
    public void GameEndUI(){

    }
    */



}
