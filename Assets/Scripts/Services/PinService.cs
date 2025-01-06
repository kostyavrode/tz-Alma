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
        // ��������� ���� �� Resources
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
}
