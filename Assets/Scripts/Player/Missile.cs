using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    int damage;
    [SerializeField]
    float radius;
    [SerializeField]
    GameObject explosion;

    void OnEnable()
    {
        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        IHittable hittable = other.GetComponent<IHittable>();
        if (hittable != null)
        {
            ExplosionDamage(transform.GetChild(0).transform.position, radius);
            Instantiate(explosion, transform.GetChild(0).transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        for (int i=0; i < hitColliders.Length; i++)
        {
            hitColliders[i].SendMessage("OnHit", damage);
        }
    }
}
