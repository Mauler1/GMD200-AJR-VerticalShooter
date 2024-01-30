using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public BoxCollider2D topSpawner;

    public BoxCollider2D sideSpawner;

    public SpawnVertEnemy script;

    private bool canSpawn = true;

    private void Awake(){
        instance = this;
    }

    void Update(){
        if(canSpawn){
            StartCoroutine(CoVertEnemy());
        }
    }

    private IEnumerator CoVertEnemy(){
        canSpawn = false;
        for(int i = 0; i < 1; i++){
            script.SpawnEnemy();
            yield return new WaitForSeconds(2f);
        }
        canSpawn = true;
    }
}
