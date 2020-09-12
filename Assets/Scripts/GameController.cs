using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues = new Vector3();
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GameObject moneyText;
    private int money;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine (SpawnWaves());
       money = 0;
       UpdateMoney();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait); //Esperamos antes de tirarle cosas al principio
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);//esperamos antes de hacer otro ciclo
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    void UpdateMoney()
    {
        moneyText.GetComponent<Text>().text = "Money: " + money;
    }
    public void AddMoney(int newMoneyValue)
    {
        money += newMoneyValue;
        UpdateMoney();
    }

}
