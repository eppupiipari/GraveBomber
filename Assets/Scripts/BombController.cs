using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float fuzeTimer;
    public float areaOfEffect;

    private SphereCollider collider;
    private Animator bombAnimator;

    // Start is called before the first frame update
    void Start()
    {
        bombAnimator = GetComponent<Animator>();
        collider = GetComponent<SphereCollider>();
        Invoke("Detonate", fuzeTimer);
    }

    void Detonate()
    {
        collider.enabled = true;
        bombAnimator.SetTrigger("Detonate");
        gameObject.transform.localScale = new Vector3(areaOfEffect, areaOfEffect, 0);
        Invoke("Die", 0.4f);
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
