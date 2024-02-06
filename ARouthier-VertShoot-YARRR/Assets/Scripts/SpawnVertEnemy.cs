using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVertEnemy : MonoBehaviour
{

    private BoxCollider2D box;
    public GameObject enemy;

    void Awake(){
        box = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnEnemy(){
        //spawning within spawn box parameters
        float minX = box.size.x - box.size.x*6;
        float maxX = box.size.x + box.size.x*6;
        float y = box.transform.position.y;

        Vector2 randomPos = new Vector2(Random.Range(minX, maxX), y);

        Instantiate(enemy, randomPos, Quaternion.identity);

    }


}
