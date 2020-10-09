using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject TiendaUI;

 
    static public void comprarVida()
    {
        //pongan static o accedan, para  que modifiquen aqui el dinero 
        PlayerManager.health++; //aqui que le recupere la cantidad que le tenga que recuperar, hay que balancerar eso  
        Debug.Log("vida");
    }
    static public void comprarMisiles()
    {
        //pongan static o accedan, para  que modifiquen aqui el dinero 
        PlayerManager.misiles++;
        Debug.Log("misiles");
    }

    static public void comprarFel()
    {
        //pongan static o accedan, para  que modifiquen aqui el dinero 
        PlayerManager.fuel++;
        //pené en el combustible como cargar de velocidad y no como un int que se va
        //acabando
        Debug.Log("combustible");
    }
    static public void comprarSpeed()
    {
        //pongan static o accedan, para  que modifiquen aqui el dinero 
        int x = 999; // x, es un límite para que no sea damasiado rápido
        if (PlayerManager.speed < x)
        {
            PlayerManager.speed++;
        }
        Debug.Log("speed");
        //la velocidad debe de tern un
    }

}
