using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.GetComponent<Transform>().position, other.GetComponent<Transform>().rotation);
        }
        other.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
