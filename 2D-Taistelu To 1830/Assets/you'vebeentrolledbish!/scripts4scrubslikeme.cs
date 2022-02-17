using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scripts4scrubslikeme : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;
    public Rigidbody2D myRigidbody2D;

    public CircleCollider2D feet;
    private float horizontalMovement = 0f;
    public int facing = 1;
    
    public LayerMask PoopLMAO;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && feet.IsTouchingLayers(PoopLMAO))
        {

            myRigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        myRigidbody2D.velocity = new Vector2(horizontalMovement * speed, myRigidbody2D.velocity.y);
    }

}