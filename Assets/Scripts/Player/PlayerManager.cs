using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //UI
    [SerializeField]
    private GameObject gameOverUI;

    //Variables
    static public float health, speed, fuel;
    public int misiles;

    private void Start()
    {
        speed = 11;
    }
    //Components


    // Update is called once per frame
    void Update()
    {
    }
}
