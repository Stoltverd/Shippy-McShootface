using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBolt : MonoBehaviour
{
    [SerializeField]
    private float damage;


    private void OnTriggerEnter(Collider other)
    {
        IHittable hittable = other.GetComponent<IHittable>();
        hittable.OnHit(damage);
        gameObject.SetActive(false);
    }
}
