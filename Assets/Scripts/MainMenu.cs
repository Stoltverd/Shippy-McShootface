using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame ()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        GameManager.money = data.money;
        GameManager.player.GetComponent<PlayerManager>().health = data.health;
        //Load position
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        GameManager.player.transform.position = position;
    }
}
