using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCreationViewModel
{
    public void CreatePin(string title, string description, Vector2 pos, string imgPath)
    {

        PinModel newPin = new PinModel
        {
            Title = title,
            Description = description,
            Position = pos,
            ImagePath = imgPath
        };

        ServiceLocator.GetService<PinFactory>().CreateNewPin(newPin);

        Debug.Log("Craete pin");
    }
}
