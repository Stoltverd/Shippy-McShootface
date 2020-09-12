using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    private AudioSource audioSource;
    private Pooler pooler;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (gameObject.activeSelf)
        {
            InvokeRepeating("Fire", delay, fireRate);
        }

        pooler = Pooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
    {
        
        pooler.SpawnFromPool("Enemy Bolt", shotSpawn.position, shotSpawn.rotation); //as GameObject;
        audioSource.Play();
    }
}
