using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Store : MonoBehaviour
{
    public GameObject TiendaUI;
    private bool show = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (show)//de esta maneria sería con un botón
        {           //debo de buscar uno
            TiendaUI.SetActive(true);
        }
        else
        {
            TiendaUI.SetActive(false);
        }
        
    }

}
