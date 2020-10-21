using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBolt : MonoBehaviour
{
    [SerializeField]
    private float damage;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
          //  other.GetComponent<PlayerManager>().OnHit(damage);
            gameObject.SetActive(false);
        }
    }
}
