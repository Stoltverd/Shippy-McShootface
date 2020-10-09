using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject TiendaUI;

 
    public void comprarVida()
    {
        PlayerManager.health++;   
    }
    
}
