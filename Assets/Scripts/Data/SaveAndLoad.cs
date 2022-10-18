using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveAndLoad
{
    public static void Save(GameManager gM)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        FileStream stream = new FileStream(path + "/Data.bird", FileMode.Create);
        GameData data = new GameData(gM);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData Load()
    {
        string path = Application.persistentDataPath + "/data";
        if (File.Exists(path + "/Data.bird"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path + "/Data.bird", FileMode.Open);
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        } else
        {
            Debug.Log("Not Found Data File");
            return null;
        }
    }
}
