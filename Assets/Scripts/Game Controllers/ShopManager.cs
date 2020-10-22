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

    [SerializeField]
    GameObject priceHealthTxt;
    [SerializeField]
    GameObject priceSpeedTxt;
    [SerializeField]
    GameObject priceMisilTxt;
    [SerializeField]
    GameObject priceFuelTxt;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        priceHealthTxt.GetComponent<Text>().text = priceHealth.ToString();
        priceSpeedTxt.GetComponent<Text>().text = priceSpeed.ToString();
        priceMisilTxt.GetComponent<Text>().text = priceMisil.ToString();
        priceFuelTxt.GetComponent<Text>().text = priceFuel.ToString();
    }
    public void comprar(int id)
    {
        switch (id) // ID=1 vida, ID=2 Speed, ID=3 Misil, ID=4 Fuel 
        {
            case 1:
                if(GameManager.Instance.money >= priceHealth) //validación de cada costo
                {
                    PlayerManager.Instance.addHealth(30);
                    GameManager.Instance.money -= priceHealth;
                    GameManager.Instance.UpdateMoney();
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
                    GameManager.Instance.UpdateMoney();
                    Debug.Log("Speed + 0.5");
                }
                else
                {
                    nofio.SetActive(true);
                }
                break;
            case 3:
                if (GameManager.Instance.money >= priceMisil && GameManager.Instance.misiles < GameManager.Instance.maxMisiles)
                {
                    PlayerManager.Instance.addMisil(1);
                    GameManager.Instance.money -= priceMisil;
                    GameManager.Instance.UpdateMoney();
                    GameManager.Instance.UpdateMissiles();
                    Debug.Log("Misil Extra");
                }
                else if (GameManager.Instance.misiles > GameManager.Instance.maxMisiles)
                    Debug.Log("Máximo de misiles alcanzado");
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
                    GameManager.Instance.UpdateMoney();
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
        Debug.Log("Tienda abirrta");
        TiendaUI.SetActive(true);
    }
    public void closeShop()
    {
        TiendaUI.SetActive(false);
        GameManager.Instance.pauseWave = false;
    }

  
}
