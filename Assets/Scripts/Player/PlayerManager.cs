using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IHittable
{
    //UI
    [SerializeField]
    private GameObject gameOverUI;

    //Variables
    private float speed, maxSpeed;
    public float maxHealth;
    public float health;
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
        speed = PlayerMovement.Instance.speed;
        maxSpeed = PlayerMovement.Instance.maxSpeed;
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
    
    public void addFuel(int i)
    {
        if (GameManager.Instance.maxBoost < 20)              // estructura para Fuel por cargas
        {
            GameManager.Instance.maxBoost += i;
            if (GameManager.Instance.maxBoost > 20)
                GameManager.Instance.maxBoost = 20;
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
