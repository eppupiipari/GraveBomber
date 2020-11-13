using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float fuzeTimer;
    public float areaOfEffect;

    private CircleCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        collider.radius = areaOfEffect;
        Invoke("Detonate", fuzeTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Detonate()
    {
        collider.enabled = true;
    }
}
