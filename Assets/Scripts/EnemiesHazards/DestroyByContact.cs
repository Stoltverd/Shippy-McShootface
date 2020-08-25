using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public int moneyValue;
    private GameManager gameController;

    [SerializeField]
    float damage = default;

    bool isPlayer;

    // Start is called before the first frame update
    void Start()
    {
        isPlayer = false;

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameManager>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'Game Controller' script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosion, GetComponent<Transform>().position, GetComponent<Transform>().rotation);          
        }
        
        if (other.tag == "Player")
        {
            if (other.GetComponent<PlayerManager>().animator.GetCurrentAnimatorStateInfo(0).IsName("Damaged"))
            {
                print("is invulnerable");
            }
            else
            {
                other.GetComponent<PlayerManager>().health -= damage;
                other.GetComponent<PlayerManager>().Damaged();
            }
           
            isPlayer = true;
        }

        if (!isPlayer) other.gameObject.SetActive(false);

        gameObject.SetActive(false);
        gameController.GetComponent<GameManager>().AddMoney(moneyValue);
    }
}
