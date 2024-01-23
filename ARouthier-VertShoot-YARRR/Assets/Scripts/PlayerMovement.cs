using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    ///////////////////////////////////////////
    private Rigidbody2D _rb;

    Vector2 mousePos;

    Vector2 movement;

    public Camera cam;

    private float speed = 5f;
    ///////////////////////////////////////////


    // Start is called before the first frame update
    void Start()
    {
        // get the rigid body of the player
        _rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        // every frame check for player input 
        CheckInput();

        // get the position of the mouse for player rotation
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Called 50 times a second independent of fps
    void FixedUpdate(){

        //moves the player
        _rb.MovePosition(_rb.position + movement * speed * Time.fixedDeltaTime);

        //causes the player to rotate in the direction of the mouse
        Vector2 lookDir = mousePos - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        _rb.rotation = angle;

    }

    void CheckInput(){

        movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

    }
}
