using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject Bomb;
    public GameObject Mine;
    private GameObject menu;
    private Animator playerAnimator;
    private Vector3 playerVector;
    private Vector3 lastVector;

    public float MovementSpeed = 1;

    void Start()
    {
        menu = GameObject.Find("Canvas");
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAnimator.speed = MovementSpeed / 5;
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(Bomb,new Vector3(transform.position.x, -1.94f, transform.position.z), transform.rotation);
        }

        if (playerVector != lastVector && playerVector != new Vector3(0,0,0))
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
        playerVector = new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical"));

        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        {
            rb.velocity = playerVector * MovementSpeed / 1.5f;
        }
        else
        {
            rb.velocity = playerVector * MovementSpeed;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            menu.SendMessage("StopGame");
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Explosion")
        {
            menu.SendMessage("StopGame");
        }
    }
}
