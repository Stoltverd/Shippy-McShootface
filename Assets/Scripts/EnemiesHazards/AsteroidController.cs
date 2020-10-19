using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour, IHittable
{
    public float tumble;
    [SerializeField]
    private float maxHealth;
    private float health;
    [SerializeField]
    private int value;
    [SerializeField]
    private float damage;

    [SerializeField]
    private GameObject explosion;


    void Start()
    {
        health = maxHealth;
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

    void Update()
    {
        if (health <= 0)
        {
            GameManager.Instance.AddMoney(value);
            Die();
        }
    }

    public void OnHit(float damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
           other.GetComponent<PlayerManager>().OnHit(damage);
            Die();
        }
    }

    void Die()
    {       
        Instantiate(explosion, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
        health = maxHealth;
        gameObject.SetActive(false);
    }


}
