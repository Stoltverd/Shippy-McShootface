using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    public GameObject moneyText;
    public int money;
    // Start is called before the first frame update
    void Start()
    {
        money = 0;
        UpdateMoney();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateMoney()
    {
        GetComponent<Text>().text = "Money: " + money;
    }
}
