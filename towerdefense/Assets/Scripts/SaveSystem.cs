using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SavePlayer(GameEngine gameEngine)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.SaveData";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(gameEngine);

        formatter.Serialize(stream, data);
        stream.Close();
        
    }

    public static SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/player.SaveData";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }

    }
}
