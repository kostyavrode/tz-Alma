using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PinViewModel : INotifyPropertyChanged
{
    private string title;
    private string description;
    private string imagePath;
    private Vector2 position;
    private Sprite pinSprite;

    public PinDetailsView PinDetailsView 
    { 
        get;
        set;
    }
    public string Title
    {
        get => title;
        set
        {
            title = value;
            OnPropertyChanged(nameof(Title));
        }
    }

    public string Description
    {
        get => description;
        set
        {
            description = value;
            OnPropertyChanged(nameof(Description));
        }
    }

    public string ImagePath
    {
        get => imagePath;
        set
        {
            imagePath = value;
            OnPropertyChanged(nameof(ImagePath));
        }
    }

    public Vector2 Position
    {
        get => position;
        set
        {
            position = value;
            OnPropertyChanged(nameof(Position));
        }
    }

    public Sprite PinSprite
    {
        get => pinSprite;
        set
        {
            pinSprite = value;
            OnPropertyChanged(nameof(PinSprite));
        }
    }

    public PinDataModel ToDataModel()
    {
        return new PinDataModel
        {
            Title = title,
            Description = description,
            ImagePath = imagePath,
            Position = position
        };
    }

    private void LoadPinSprite()
    {
        if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
        {
            byte[] fileData = File.ReadAllBytes(imagePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);
            PinSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
    }
    public void ShowFullDetails()
    {
        PinDetailsView.ShowDetails(this);
        
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}