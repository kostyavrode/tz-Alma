using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PinViewModel : INotifyPropertyChanged
{
    private string title;
    private string description;
    private string imagePath;
    private Vector2 position;
    private Sprite pinSprite;

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

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}