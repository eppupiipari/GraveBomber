using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject bomb;
    public GameObject mine;
    public Animator playerAnimator;

    public float movementSpeed = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(bomb,transform.position, transform.rotation);
        }
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            playerAnimator.SetTrigger("IsMoving");
        }

    }
    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed / 1.5f, Input.GetAxisRaw("Vertical") * movementSpeed / 1.5f);
        }
        else
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, Input.GetAxisRaw("Vertical") * movementSpeed);
        }
    }
}
