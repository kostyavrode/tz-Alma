using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class PinService : MonoBehaviour
{
    private const string FileName = "pins";

    private string savePath;
    private void Awake()
    {
        savePath = Application.persistentDataPath + "/pins.json";
    }

    public void SavePins(PinListModel pinList)
    {
        string json = JsonUtility.ToJson(pinList, true);
        File.WriteAllText(savePath, json);
    }

    public PinListModel LoadPins()
    {
        // Загружаем файл из Resources
        TextAsset jsonFile = Resources.Load<TextAsset>(FileName);
        if (jsonFile != null)
        {
            try
            {
                // Десериализация JSON с помощью Newtonsoft.Json
                return JsonConvert.DeserializeObject<PinListModel>(jsonFile.text);
            }
            catch (JsonException e)
            {
                Debug.LogError($"Ошибка при десериализации файла pins.json: {e.Message}");
                return new PinListModel();
            }
        }
        else
        {
            Debug.LogWarning("Файл pins.json не найден в папке Resources!");
            return new PinListModel();
        }
    }
}
