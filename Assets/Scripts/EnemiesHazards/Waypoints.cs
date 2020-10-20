using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Waypoints Instance;
    private void Awake()
    {
        Instance = this;
    }

    public List<Transform> wp1;
    public List<Transform> wp2;
    public List<Transform> wp3;
    public List<Transform> wp4;
}
