using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Lesson1_execrcise : MonoBehaviour
{
    //序列化对象
    public void SaveData<T>(T data, string fileName)
    {
        string jsonStr = JsonUtility.ToJson(data);
        print(Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + "/" + fileName + ".json", jsonStr);
    }

    public T LoadData<T>(T type, string fileName)
    {
        string jsonStr = File.ReadAllText(Application.persistentDataPath + "/" + fileName + ".json");
        return JsonUtility.FromJson<T>(jsonStr);
    }

}
