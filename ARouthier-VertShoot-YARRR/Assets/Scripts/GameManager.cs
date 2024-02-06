using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public BoxCollider2D topSpawner;

    public BoxCollider2D sideSpawner;

    public SpawnVertEnemy vertEnemyScript;

    public SpawnVertEnemy rockScript;

    private int score = 0;

    private bool canSpawnShip = true;

    private bool canSpawnRock = true;

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI timerText;

    public float timer = 240.0f;

    private bool timeRunning = false;

    //event listener subscription & unsubscription
    private void OnEnable(){
        PlayerHealth.healthChanged += HealthChange;
    }

    private void OnDisable(){
        PlayerHealth.healthChanged -= HealthChange;
    }
    //////////////
    private void Awake(){
        instance = this;
    }

    void Start(){
        timeRunning = true;
    }

    void Update(){
        if(canSpawnShip){
            StartCoroutine(CoVertEnemy(vertEnemyScript));
        }
        if(canSpawnRock && timer<180){ //timer less than 3 minutes. start spawning rocks
            StartCoroutine(CoRock(rockScript));
        }
        scoreText.text = score.ToString(); //score changing UI
        timerText.text = TimerFormat(timer); //timer changing UI
        if(timeRunning){
            if(timer > 0){
                timer -= Time.deltaTime;
            }
            else{
                //load win scene
                SceneManager.LoadScene(2);
            }
        }
    }

    //vertical ship spawning coroutine
    private IEnumerator CoVertEnemy(SpawnVertEnemy script){
        canSpawnShip = false;
        for(int i = 0; i < 1; i++){
            script.SpawnEnemy();
            yield return new WaitForSeconds(1.5f);
        }
        canSpawnShip = true;
    }

    //Rock spawning coroutine
    private IEnumerator CoRock(SpawnVertEnemy script){
        canSpawnRock = false;
        for(int i = 0; i < 1; i++){
            script.SpawnEnemy();
            yield return new WaitForSeconds(1.75f);
        }
        canSpawnRock = true;
    }

    //adds a point to score
    public void addPoint(){
        score++;
    }

    //formats the timer for a smooth countdown
    private string TimerFormat(float timer){
        float minutes = Mathf.FloorToInt(timer/60);
        float seconds = Mathf.FloorToInt(timer%60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //on hit - will chnge the scene to lose screen
    private void HealthChange(int obj){
        SceneManager.LoadScene(3);
    }


}
