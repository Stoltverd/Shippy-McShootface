using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    [SerializeField]
    float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerManager>().health -= damage;
        }
        else
        {
            other.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
