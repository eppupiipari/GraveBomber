using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnController : MonoBehaviour
{
    public GameObject zombie;
    public float SpawnSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("spawnZombie", SpawnSpeed);
    }

    void spawnZombie()
    {
           Instantiate(zombie, transform.position, transform.rotation);
           Invoke("spawnZombie", SpawnSpeed);
    }
}
