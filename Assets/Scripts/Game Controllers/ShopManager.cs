using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;
    public GameObject TiendaUI;

    [SerializeField]
    private GameObject nofio;
    [SerializeField]
    int priceHealth; 
    [SerializeField]
    int priceFuel;
    [SerializeField]
    int priceSpeed;
    [SerializeField]
    int priceMisil; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void comprar(int id)
    {
        switch (id) // ID=1 vida, ID=2 Speed, ID=3 Misil, ID=4 Misil 
        {
            case 1:
                if(GameManager.Instance.money >= priceHealth) //validación de cada costo
                {
                    PlayerManager.Instance.addHealth(30);
                    GameManager.Instance.money -= priceHealth;
                    Debug.Log("vida");
                }
                else
                {
                    nofio.SetActive(true);
                }
                break;
            case 2:
                if (GameManager.Instance.money >= priceSpeed)
                {
                    PlayerMovement.Instance.addSpeed(0.5f);
                    GameManager.Instance.money -= priceSpeed;
                }
                else
                {
                    nofio.SetActive(true);
                }
                break;
            case 3:
                if (GameManager.Instance.money >= priceMisil)
                {
                    PlayerManager.Instance.addMisil(1);
                    GameManager.Instance.money -= priceMisil;
                }
                else
                {
                    nofio.SetActive(true);
                }
                break;
            case 4:
                if (GameManager.Instance.money >= priceFuel)
                {
                    PlayerManager.Instance.addFuel(1);
                    GameManager.Instance.money -= priceFuel;
                }
                else
                {
                    nofio.SetActive(true);
                }
                break;



        }   
    }
    public void showShop()
    {     
        TiendaUI.SetActive(true);
    }
    public void closeShop()
    {
        TiendaUI.SetActive(false);
    }

  
}
