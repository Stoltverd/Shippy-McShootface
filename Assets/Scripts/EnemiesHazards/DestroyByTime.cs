using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    IEnumerator DeactivateInTime(float time, GameObject obj)
    {
        yield return new WaitForSeconds(time); //Esperamos antes de tirarle cosas al principio
        obj.SetActive(false);
    }
}
