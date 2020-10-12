using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IHittable
{
    //UI
    [SerializeField]
    private GameObject gameOverUI;

    //Variables
    public float health;
    [SerializeField]
    public float damage;

    //Components
    [SerializeField]
    public Animator animator;


    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    public void OnHit(float damage)
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Damaged"))
        {
            print("is invulnerable");
        }
        else
        {
            health -= damage;
            animator.SetTrigger("isHit");
        }
    }
}
