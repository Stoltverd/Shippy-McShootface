using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//Make it serializable, so we can save it
public sealed class PlayerData //sealed ensures thread safety
{
    //Instance to make singleton
    private readonly static PlayerData _instance = new PlayerData();
    public int money;
    public float health;

    public float[] position; //Can't use Vector3. Can't be serialized.

    //Method to instantiate
    public static PlayerData Instance()
    {
        return _instance;
    }
    //Constructors. MUST be private
    private PlayerData()
    {

    }
    private PlayerData(GameManager gameManager,PlayerManager playerManager, PlayerMovement playerMovement)
    {
        money = gameManager.money;
        //health = playerManager.health;

        position = new float[3];
        position[0] = playerMovement.transform.position.x;
        position[1] = playerMovement.transform.position.y;
        position[2] = playerMovement.transform.position.z;

    }


}

