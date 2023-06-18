using System.IO;
using UnityEngine;
using UnityEngine.Events;

public static class SaveLoad
{
    public static UnityAction OnSaveGame;
    public static UnityAction<SaveData> OnLoadGame;

    private static string directory = "/SaveData/";
    private static string fileName = "SaveGame.sav";

    public static bool Save(SaveData data)
    {
        OnSaveGame?.Invoke();

        string dir = Application.persistentDataPath + directory;

        GUIUtility.systemCopyBuffer = dir;

        if(!Directory.Exists(dir)) 
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(data, prettyPrint: true);
        File.WriteAllText(path: dir + fileName, contents: json);

        Debug.Log(message: "Saving game");

        return true;
    }

    public static SaveData Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveData data = new SaveData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            data = JsonUtility.FromJson<SaveData>(json);
            
            OnLoadGame?.Invoke(data);
        }
        else
        {
            Debug.Log(message: "Save file does not exist!");
        }
        return data;
    }

    public static void DeleteSaveData()
    {
        string fullPath = Application.persistentDataPath + directory + fileName; ;

        if (File.Exists(fullPath)) File.Delete(fullPath);
    }
}
