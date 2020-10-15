using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum EnemyType
{
    Asteroid1,
    Asteroid2,
    Asteroid3,
    Enemy1,
    None,
}

[System.Serializable]
public class Wave
{
    public EnemyType[] enemies;
}

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
    [SerializeField]
    GameObject healthText;

    //MergeChanges
    public GameObject moneyText;
    public int money;

    void Start()
    {

       gameOver = false;
        currentScene = SceneManager.GetActiveScene();

        pooler = Pooler.Instance;

        StartCoroutine (WaveSpawn());


        money = 0;
        UpdateMoney();
    }

    void Update()
    {
        PlayerHealthUpdate();
        RestartUpdate();
        #region TEST SAVE SYSTEM
        if (Input.GetKeyDown("s"))
        {
            SavePlayer();
        }
        if (Input.GetKeyDown("l"))
        {
            LoadPlayer();
        }
        #endregion
    }

    private void PlayerHealthUpdate()
    { // if(player.GetComponent<PlayerManager>().health <= 0)
        if (PlayerManager.health <= 0)
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
        PlayerManager.health = Mathf.Clamp(PlayerManager.health, 0, 100);
        playerHealth.value = PlayerManager.health;
        /*player.GetComponent<PlayerManager>().health = Mathf.Clamp(player.GetComponent<PlayerManager>().health, 0, 100);
        playerHealth.value = player.GetComponent<PlayerManager>().health;*/
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
        moneyText.GetComponent<Text>().text = ": " + money;
    }
    public void AddMoney(int newMoneyValue)
    {
        money += newMoneyValue;
        UpdateMoney();
    }

    [SerializeField]
    Wave[] waves;

    IEnumerator WaveSpawn()
    {
        yield return new WaitForSeconds(startWait); //Esperamos antes de tirarle cosas al principio
        foreach(Wave wave in waves)
        {
            for (int i = 0; i < wave.enemies.Length; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                //Spawn from pool
                EnemyType et = wave.enemies[i];

                switch (et)
                {
                    case EnemyType.None:
                        break;
                    case EnemyType.Asteroid1:
                        pooler.SpawnFromPool("Asteroid", spawnPosition, spawnRotation);
                        break;
                    case EnemyType.Asteroid2:
                        pooler.SpawnFromPool("Asteroid2", spawnPosition, spawnRotation);
                        break;
                    case EnemyType.Asteroid3:
                        pooler.SpawnFromPool("Asteroid3", spawnPosition, spawnRotation);
                        break;
                    case EnemyType.Enemy1:
                        pooler.SpawnFromPool("Enemy", spawnPosition, spawnRotation);
                        break;

                }

                yield return new WaitForSeconds(spawnWait);//esperamos antes de hacer otro ciclo
            }
            yield return new WaitForSeconds(waveWait);
        }
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
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this, player.GetComponent<PlayerManager>(), player.GetComponent<PlayerMovement>());
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        this.money = data.money;
        player.GetComponent<PlayerManager>().health = data.health;
        //Load position
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;
    }
}
