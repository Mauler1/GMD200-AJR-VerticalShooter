using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public Rigidbody2D bulletPrefab;
    public Transform shotLocation;
    public float bulletSpeed = 15.0f;
    public float bulletTime = 0.5f;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && canShoot){ //hold to shoot!!!
            StartCoroutine(shotTimer(bulletTime));
        }
    }

    //time between shots coroutine
    private IEnumerator shotTimer(float bulletDelay){
        canShoot = false;
        for(int i = 0; i < 1; i++){
            Rigidbody2D bulletRB = Instantiate(bulletPrefab, shotLocation.position, Quaternion.identity);
            bulletRB.velocity = transform.up * bulletSpeed;
            yield return new WaitForSeconds(bulletDelay);
        }
        canShoot = true;
    }
}
