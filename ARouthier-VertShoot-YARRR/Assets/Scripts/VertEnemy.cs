using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertEnemy : MonoBehaviour
{

    private Rigidbody2D _rb;

    void Awake(){
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb.velocity = transform.up * -1 * varSpeed(); //sets speed when the enemy spawns
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        
    }

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Despawn")){ //if collides with despawner, destroy
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Player")){ //if collides with the player, KILL
            Destroy(gameObject);
            PlayerHealth.SetHealth(PlayerHealth.GetHealth()-1);
        }
    }

    private float varSpeed(){ //as the game progresses, the speed of any enemies with this script increases
        float timer = GameManager.instance.timer;
        if(timer > 180){ //3 minutes
            return 3;
        }
        else if(timer > 120){ //2 minutes
            return 4.5f;
        }
        else{
            return 6;
        }
    }
}
