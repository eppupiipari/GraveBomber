using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject bomb;
    public GameObject mine;
    public float movementSpeed = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(bomb,transform.position, transform.rotation);
        }
    }
    void FixedUpdate()
    {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, Input.GetAxisRaw("Vertical") * movementSpeed);
            //sivuttain liikkuminen on nopeampaa. fix later!
    }
}
