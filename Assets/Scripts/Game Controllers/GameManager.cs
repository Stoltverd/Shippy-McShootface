using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Make this a singleton
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    //Variables
    [SerializeField]
    Vector3 spawnValues = new Vector3();
    [SerializeField]
    int hazardCount = default;
    [SerializeField]
    float spawnWait = default;
    [SerializeField]
    float startWait = default;
    [SerializeField]
    float waveWait = default;
    bool gameOver;
    Scene currentScene;

    Pooler pooler;

    //UI
    [SerializeField]
    private GameObject gameOverUI = default;
    [SerializeField]
    private GameObject inGameUI = default;

    //Components
    [SerializeField]
    int hazardNumber = default;
    [SerializeField]
    GameObject player = default;
    [SerializeField]
    GameObject playerExplosion = default;
    [SerializeField]
    Slider playerHealth = default;

    //MergeChanges
    public GameObject moneyText;
    private int money;

    void Start()
    {

       gameOver = false;
        currentScene = SceneManager.GetActiveScene();

        pooler = Pooler.Instance;

        StartCoroutine (SpawnWaves());


        money = 0;
        UpdateMoney();
    }

    void Update()
    {
        PlayerHealthUpdate();
        RestartUpdate();
    }

    private void PlayerHealthUpdate()
    {
        if (player.GetComponent<PlayerManager>().health <= 0)
        {
            if (gameOver == false)
            {
                Instantiate(playerExplosion, player.transform.position, player.transform.rotation);
                player.SetActive(false);
                gameOverUI.SetActive(true);
                inGameUI.SetActive(false);
            }
            gameOver = true;         
        }
        player.GetComponent<PlayerManager>().health = Mathf.Clamp(player.GetComponent<PlayerManager>().health, 0, 100);
        playerHealth.value = player.GetComponent<PlayerManager>().health;
    }
    private void RestartUpdate()
    {
        if (gameOver && Input.GetButton("Restart"))
        {
            SceneManager.LoadScene(currentScene.name);
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

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait); //Esperamos antes de tirarle cosas al principio
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                //Spawn from pool
                int r = Random.Range(0, hazardNumber);

                switch (r)
                {
                    case 0:
                        pooler.SpawnFromPool("Asteroid", spawnPosition, spawnRotation);
                        break;
                    case 1:
                        pooler.SpawnFromPool("Asteroid2", spawnPosition, spawnRotation);
                        break;
                    case 2:
                        pooler.SpawnFromPool("Asteroid3", spawnPosition, spawnRotation);
                        break;
                    case 3:
                        pooler.SpawnFromPool("Enemy", spawnPosition, spawnRotation);
                        break;

                }              

                yield return new WaitForSeconds(spawnWait);//esperamos antes de hacer otro ciclo
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
