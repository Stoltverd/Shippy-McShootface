using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //UI
    [SerializeField]
    private GameObject gameOverUI;

    //Variables
    public float health;
    float previousHealth;

    //Components
    [SerializeField]
    public Animator animator;


    private void Start()
    {
        previousHealth = health;
        animator = this.GetComponent<Animator>();
    }
    void Update()
    {
        previousHealth = health;
    }

    public void Damaged()
    {
         print("Damaged");
        animator.SetTrigger("isHit");
    }
}
