using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//Make it serializable, so we can save it
public class PlayerData
{

    public int money;
    public float health;
    public float[] position; //Can't use Vector3. Can't be serialized.


    //Constructor
    public PlayerData(GameManager gameManager,PlayerManager playerManager, PlayerMovement playerMovement)
    {
        money = gameManager.Money;
        health = playerManager.health;

        position = new float[3];
        position[0] = playerMovement.transform.position.x;
        position[1] = playerMovement.transform.position.y;
        position[2] = playerMovement.transform.position.z;

    }


}

