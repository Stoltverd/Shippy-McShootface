using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ObjectType
{
    Asteroid1,
    Asteroid2,
    Asteroid3,
    Enemy,
    Enemy1,
    Enemy2,
    Enemy3,
    Enemy4,
    None,
    Store,
}

[System.Serializable]
public class Wave
{
    public ObjectType[] enemies;
}

public class GameManager : MonoBehaviour
{
    //Make this a singleton
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
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
    public bool pauseWave;
    int countWave = 0;
    public int misiles;
    public int maxMisiles;
    public float maxBoost;

    Pooler pooler;

    //UI
    [SerializeField]
    private GameObject gameOverUI = default;
    [SerializeField]
    private GameObject inGameUI = default;

    //Components
    [SerializeField]
    GameObject player = default;
    [SerializeField]
    GameObject playerExplosion = default;
    [SerializeField]
    Slider playerHealth = default;
    [SerializeField]
    public Slider playerBoost = default;
    [SerializeField]
    GameObject healthText;

    //MergeChanges
    public GameObject moneyText;
    public GameObject missileText;
    public int money;

    void Start()
    {
        //player = PlayerManager.Instance;
        gameOver = false;
        currentScene = SceneManager.GetActiveScene();

        pooler = Pooler.Instance;

        StartCoroutine (WaveSpawn());


        money = 0;
        playerBoost.maxValue = maxBoost;
        UpdateMoney();
        UpdateMissiles();
        UpdateBoost(maxBoost);
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
                healthText.GetComponent<Text>().text = "" + player.GetComponent<PlayerManager>().health;
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

    public void UpdateMissiles()
    {
        missileText.GetComponent<Text>().text = "x " + misiles;
    }

   public void UpdateMoney()
    {
        moneyText.GetComponent<Text>().text = ": " + money;
    }
    public void AddMoney(int newMoneyValue)
    {
        money += newMoneyValue;
        UpdateMoney();
    }
    public void UpdateBoost(float boost)
    {
        playerBoost.value = boost;
    }

    [SerializeField]
    Wave[] waves;
    [SerializeField]
    GameObject enemy1;
    [SerializeField]
    GameObject enemy2;
    [SerializeField]
    GameObject enemy3;

 
    IEnumerator WaveSpawn()
    {
        yield return new WaitForSeconds(startWait); //Esperamos antes de tirarle cosas al principio
        //foreach(Wave wave in waves)
        for (int j = 0; j < waves.Length; j++)
        {
            while (pauseWave)
            {
                yield return null;
                if (!pauseWave)
                    break;
            }
            Debug.Log(j);
            for (int i = 0; i < waves[j].enemies.Length; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                //Spawn from pool
                ObjectType et = waves[j].enemies[i];

                switch (et)
                {
                    case ObjectType.None:
                        break;
                    case ObjectType.Asteroid1:
                        pooler.SpawnFromPool("Asteroid", spawnPosition, spawnRotation);
                        break;
                    case ObjectType.Asteroid2:
                        pooler.SpawnFromPool("Asteroid2", spawnPosition, spawnRotation);
                        break;
                    case ObjectType.Asteroid3:
                        pooler.SpawnFromPool("Asteroid3", spawnPosition, spawnRotation);
                        break;
                    case ObjectType.Enemy:
                        pooler.SpawnFromPool("Enemy", spawnPosition, spawnRotation);
                        break;
                    case ObjectType.Enemy1:
                        //pooler.SpawnFromPool("Enemy1", spawnPosition, spawnRotation);
                        Instantiate(enemy1, spawnPosition, spawnRotation);
                        break;
                    case ObjectType.Enemy2:
                        //pooler.SpawnFromPool("Enemy2", spawnPosition, spawnRotation);
                        Instantiate(enemy2, spawnPosition, spawnRotation);
                        break;
                    case ObjectType.Enemy3:
                        //pooler.SpawnFromPool("Enemy3", spawnPosition, spawnRotation);
                        Instantiate(enemy3, spawnPosition, spawnRotation);
                        break;
                    case ObjectType.Enemy4:
                        pooler.SpawnFromPool("Enemy4", spawnPosition, spawnRotation);
                        break;
                    case ObjectType.Store:
                        pauseWave = true;
                        countWave = 0;
                        Invoke("openShop", 2f);
                        break;
                }

                yield return new WaitForSeconds(spawnWait);//esperamos antes de hacer otro ciclo
            }
            countWave++;
            
            yield return new WaitForSeconds(waveWait);
        }
    }
    void openShop()
    {
        ShopManager.Instance.showShop();
    }
  
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this, player.GetComponent<PlayerManager>(), player.GetComponent<PlayerMovement>());
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        //Load money
        this.money = data.money;
        UpdateMoney();
        //Load health
        player.GetComponent<PlayerManager>().health = data.health;
        PlayerHealthUpdate();
        //Load speed
        player.GetComponent<PlayerMovement>().speed = data.speed;
        //Load misiles
        this.misiles = data.misiles;
        this.maxMisiles = data.maxMisiles;
        UpdateMissiles();
        //Load boost
        player.GetComponent<PlayerMovement>().currentBoost = data.boost;
        this.maxBoost = data.maxBoost;
        UpdateBoost(playerBoost.value);
        //Load position
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;
    }
}
