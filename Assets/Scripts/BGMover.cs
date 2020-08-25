using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BGMover : MonoBehaviour
{
    Vector3 direction;
    [SerializeField]
    GameObject returnPoint = default;
    [SerializeField]
    float speed = default;
    float distance;

    void Start()
    {
        direction = new Vector3(0, -speed, 0);
    }


    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
        distance = Vector3.Distance(transform.position, returnPoint.transform.position);
        if (distance > 59.8f)
        {
            transform.position = returnPoint.transform.position;
        }
    }
}
