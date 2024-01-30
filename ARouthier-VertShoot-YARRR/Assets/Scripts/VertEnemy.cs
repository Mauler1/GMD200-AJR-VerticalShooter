using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertEnemy : MonoBehaviour
{

    private Rigidbody2D _rb;
    public float speed = 5f;

    void Awake(){
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb.velocity = transform.up * -1 * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        
    }

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Despawn")){
            Destroy(gameObject);
        }
    }
}
