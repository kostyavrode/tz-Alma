using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCreationViewModel
{
    public void CreatePin(string title, string description)
    {
        Debug.Log("Craete pin");
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        PinModel newPin = new PinModel
        {
            Title = title,
            Description = description,
            Position = worldPosition,
            ImagePath = ""
        };

        ServiceLocator.GetService<PinFactory>().CreateNewPin(newPin);

        Debug.Log("Craete pin");
    }
}
