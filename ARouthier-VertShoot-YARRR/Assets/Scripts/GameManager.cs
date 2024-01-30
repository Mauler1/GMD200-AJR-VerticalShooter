using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public BoxCollider2D topSpawner;

    public BoxCollider2D sideSpawner;

    private void Awake(){
        instance = this;
    }

    private IEnumerator CoVertEnemy(){
        yield return new WaitForSeconds(2f);
        //spawn vert enemy
    }
}
