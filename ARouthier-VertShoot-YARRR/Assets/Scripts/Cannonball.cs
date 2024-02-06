using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    [SerializeField] private AudioClip explosionSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Despawn"))
        {
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Enemy")){
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(explosionSFX, transform.position, 0.3f);
            GameManager.instance.addPoint();
        }
    }
}
