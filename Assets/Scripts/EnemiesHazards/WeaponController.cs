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
    [SerializeField]
    AudioClip shoot;
    private Pooler pooler;

    // Start is called before the first frame update
    void Start()
    {
        delay = 0;
        audioSource = GetComponent<AudioSource>();
        pooler = Pooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        delay += Time.deltaTime;
        if (delay >= fireRate)
        {
            Fire();
            delay = 0;
        }
    }

    void Fire()
    {
        
        pooler.SpawnFromPool("Enemy Bolt", shotSpawn.position, shotSpawn.rotation); //as GameObject;
        audioSource.PlayOneShot(shoot, 1.0f);
    }
}
