using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IHittable
{
    //UI
    [SerializeField]
    private GameObject gameOverUI;

    //Variables
    public float maxHealth;
    public float health;
    public float speed, maxSpeed;
    public int misil, maxMisil;
    
    [SerializeField]
    public float damage;

    //Components
    [SerializeField]
    public Animator animator;

    public static PlayerManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        health = maxHealth;
        animator = this.GetComponent<Animator>();
    }

    public void OnHit(float damage)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Damaged"))
        {
            print("is invulnerable");
        }
        else
        {
            health -= damage;
            animator.SetTrigger("isHit");
        }
    }

    public void addHealth(int i)
    {
        if(health < maxHealth)
        {
            health += i;
            if (health > maxHealth)
                health = maxHealth;
        }

       
    }
    public void addSpeed(float i)
    {
        if (speed < maxSpeed)
        {
            speed += i;
            if (speed > maxSpeed)
                speed = maxSpeed;
        }
    }
    public void addFuel(int i)
    {
        if (speed < maxSpeed)
        {
            speed += i;
            if (speed > maxSpeed)
                speed = maxSpeed;
        }
    }
    public void addMisil(int i)     //estructura alternativa de Misiles
    {
        if (misil<maxMisil)
        {
            misil+= i;
            if (misil > maxMisil)
                misil = maxMisil;
        }
    }
}
