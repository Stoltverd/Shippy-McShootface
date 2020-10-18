using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPMover : MonoBehaviour
{
    List<Transform> wp;
    byte wpCounter = 0;
    [SerializeField]
    float speed;
    [SerializeField]
    byte Type;


    void Start()
    {
        switch(Type)
        {
            case 1:
                wp = Waypoints.Instance.wp1;
                break;
            case 2:
                wp = Waypoints.Instance.wp2;
                break;
            case 3:
                wp = Waypoints.Instance.wp3;
                break;
            case 4:
                wp = Waypoints.Instance.wp4;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, wp[wpCounter].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, wp[wpCounter].position) == 0)
        {
            if (wpCounter < wp.Count - 1)
            {
                wpCounter++;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
