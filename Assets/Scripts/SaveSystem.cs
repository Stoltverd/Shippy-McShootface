using System.IO;//Namespace to work with files
using System.Runtime.Serialization.Formatters.Binary;//Binary format so player can't edit so easily
using UnityEngine;

public static class SaveSystem 
{

    public static void SavePlayer (GameManager gameManager, PlayerManager playerManager, PlayerMovement playerMovement)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.shp"; //Path and name for save file
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(gameManager, playerManager, playerMovement);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.shp";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);//Opens the file

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("There is no save data in " + path);
            return null;
        }
    }

}
