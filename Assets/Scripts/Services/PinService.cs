using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class PinService
{
    private const string FileName = "pins";

    private string savePath;

    public void SavePin(PinDataModel pinData)
    {
        // Загружаем текущий список пинов
        var pinList = LoadPins();

        // Находим и обновляем соответствующий пин
        var existingPin = pinList.pins.Find(p => p.Position == pinData.Position);
        if (existingPin != null)
        {
            existingPin.Title = pinData.Title;
            existingPin.Description = pinData.Description;
            existingPin.ImagePath = pinData.ImagePath;
        }
        else
        {
            pinList.pins.Add(pinData);
        }

        // Сохраняем обновленный список
        SavePinsToFile(pinList);
    }

    public PinListModel LoadPins()
    {

        savePath = Application.persistentDataPath + "/pins.json";

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
    private void SavePinsToFile(PinListModel pinList)
    {
        string jsonPath = Path.Combine(Application.dataPath, "Resources", $"{FileName}.json");
        string json = JsonConvert.SerializeObject(pinList, Formatting.Indented);
        File.WriteAllText(jsonPath, json);
        Debug.Log("Pins saved to: " + jsonPath);
    }
}
