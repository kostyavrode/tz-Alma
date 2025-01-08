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
        // ��������� ������� ������ �����
        var pinList = LoadPins();

        // ������� � ��������� ��������������� ���
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

        // ��������� ����������� ������
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
                // �������������� JSON � ������� Newtonsoft.Json
                return JsonConvert.DeserializeObject<PinListModel>(jsonFile.text);
            }
            catch (JsonException e)
            {
                Debug.LogError($"������ ��� �������������� ����� pins.json: {e.Message}");
                return new PinListModel();
            }
        }

        else
        {
            Debug.LogWarning("���� pins.json �� ������ � ����� Resources!");
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
