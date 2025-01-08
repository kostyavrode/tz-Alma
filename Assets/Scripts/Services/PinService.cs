using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class PinService
{
    private const string FileName = "pins";

    private PinListModel pinList;

    public void Init()
    {
        ServiceLocator.RegisterService(this);
    }
    public void SavePin(PinModel pinData)
    { 
        var existingPin = pinList.pins.Find(p => p.Position == pinData.Position);
        if (existingPin != null)
        {
            existingPin.Title = pinData.Title;
            existingPin.Description = pinData.Description;
            existingPin.ImagePath = pinData.ImagePath;
            existingPin.Position = pinData.Position;
            Debug.Log(existingPin.Position);
        }
        else
        {
            pinList.pins.Add(pinData);
        }

        SavePinsToFile(pinList);
    }

    public void SavePins()
    {
        string jsonPath = Path.Combine(Application.persistentDataPath, "pins.json");
        string json = JsonConvert.SerializeObject(pinList, Formatting.Indented);
        File.WriteAllText(jsonPath, json);
        Debug.Log("Pins saved to: " + jsonPath);
    }

    public void DeletePin(PinViewModel pinToDelete)
    {
        PinModel pin = pinList.pins.Find(p => p.Title == pinToDelete.Title && p.Position == pinToDelete.Position);

        if (pin != null)
        {
            pinList.pins.Remove(pin);
            pinToDelete.DeletePin();
            SavePins();
            Debug.Log($"Pin '{pin.Title}' deleted and saved.");
        }
        else
        {
            Debug.LogWarning("Pin not found for deletion.");
        }
    }

    public PinListModel LoadPins()
    {
        string jsonPath = Path.Combine(Application.persistentDataPath, $"{FileName}.json");

        if (File.Exists(jsonPath))
        {
            string json = File.ReadAllText(jsonPath);
            Debug.Log("Loaded pins from: " + jsonPath);
            pinList = JsonConvert.DeserializeObject<PinListModel>(json);
            return pinList;
        }
        else
        {
            // Загружаем из Resources при первом запуске
            TextAsset jsonFile = Resources.Load<TextAsset>(FileName);
            if (jsonFile != null)
            {
                Debug.Log("Loaded pins from Resources.");
                var pinList = JsonConvert.DeserializeObject<PinListModel>(jsonFile.text);

                // Сохраняем копию в persistentDataPath
                SavePinsToFile(pinList);
                this.pinList = pinList;
                return pinList;
            }
            else
            {
                Debug.LogWarning("Pin data not found in Resources or persistentDataPath.");
                return new PinListModel(); // Пустая модель, если данных нет
            }
        }
    }
    private void SavePinsToFile(PinListModel pinList)
    {
        string jsonPath = Path.Combine(Application.persistentDataPath, $"{FileName}.json");
        string json = JsonConvert.SerializeObject(pinList, Formatting.Indented);
        File.WriteAllText(jsonPath, json);
        Debug.Log("Pins saved to: " + jsonPath);
    }
}
