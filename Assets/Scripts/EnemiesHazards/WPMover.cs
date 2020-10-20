using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPMover : MonoBehaviour
{
    [SerializeField]
    List<Transform> wp;
    byte wpCounter = 0;
    [SerializeField]
    float speed;
    [SerializeField]
    byte Type;

    bool moving = false;

    //Colores provicionales
    [SerializeField]
    Color color1;
    [SerializeField]
    Color color2;
    [SerializeField]
    Color color3;
    [SerializeField]
    Color color4;


    void Start()
    {
        switch(Type)
        {
            case 1:
                GetComponentInChildren<Renderer>().material.color = color1;
                wp = Waypoints.Instance.wp1;
                break;
            case 2:
                GetComponentInChildren<Renderer>().material.color = color2;
                wp = Waypoints.Instance.wp2;
                break;
            case 3:
                GetComponentInChildren<Renderer>().material.color = color3;
                wp = Waypoints.Instance.wp3;
                break;
            case 4:
                GetComponentInChildren<Renderer>().material.color = color4;
                wp = Waypoints.Instance.wp4;
                break;
        }
    }

    private void OnEnable()
    {
        wpCounter = 0;
        moving = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (moving)
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
                    wpCounter = 0;
                    Destroy(gameObject);
                }
            }
        }
    }
}
