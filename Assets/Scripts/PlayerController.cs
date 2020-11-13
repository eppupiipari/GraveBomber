using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject bomb;
    public GameObject mine;
    private Animator playerAnimator;
    private Vector2 playerVector;
    private Vector2 lastVector;

    public float movementSpeed = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerAnimator.speed = movementSpeed / 5;
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(bomb,transform.position, transform.rotation);
        }

        if (playerVector != lastVector && playerVector != new Vector2(0,0))
        {
            playerAnimator.SetTrigger("ChangeDirection");
            lastVector = playerVector;
        }

        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        {
            playerAnimator.SetFloat("Vertical", Input.GetAxisRaw("Vertical") / 2);
            playerAnimator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal") / 2);
        }
        else
        {
            playerAnimator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
            playerAnimator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        }
        

    }
    void FixedUpdate()
    {
        playerVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        {
            rb.velocity = playerVector * movementSpeed / 1.5f;
        }
        else
        {
            rb.velocity = playerVector * movementSpeed;
        }
    }
}
