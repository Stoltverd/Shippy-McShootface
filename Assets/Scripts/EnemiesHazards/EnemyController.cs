using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour, IHittable
{
    AudioSource audioSource;

    [SerializeField]
    private float health;
    [SerializeField]
    private float damage;
    [SerializeField]
    private int value;
    Color ogColor;
    [SerializeField]
    Color hitColor;

    [SerializeField]
    GameObject enemyExplosion;
    [SerializeField]
    AudioClip damaged;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ogColor = GetComponentInChildren<Renderer>().material.color;
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
        audioSource.PlayOneShot(damaged, 0.3f);
        StartCoroutine(Hitcolor());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerManager>().OnHit(damage);
            Die();
        }
    }

    void Die()
    {
        Instantiate(enemyExplosion, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
        gameObject.SetActive(false);
    }

    IEnumerator Hitcolor()
    {
        GetComponentInChildren<Renderer>().material.color = hitColor;
        yield return new WaitForSeconds(0.5f);
        GetComponentInChildren<Renderer>().material.color = ogColor;
    }
}
