using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int moneyValue;
    private GameManager gameController;

    // Start is called before the first frame update
    void Start()
    {
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
            Instantiate(playerExplosion, other.GetComponent<Transform>().position, other.GetComponent<Transform>().rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.GetComponent<GameManager>().AddMoney(moneyValue);
    }
}
