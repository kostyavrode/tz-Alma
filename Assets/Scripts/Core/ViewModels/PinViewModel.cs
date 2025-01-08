using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PinViewModel : INotifyPropertyChanged
{

    private PinModel _pinModel;

    public PinViewModel(PinModel pinModel)
    {
        _pinModel = pinModel;
    }

    public PinModel PinModel
    {
        get { return _pinModel; }
    }

    public string Title
    {
        get => _pinModel.Title;
        set
        {
            if (_pinModel.Title != value)
            {
                _pinModel.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }

    public string Description
    {
        get => _pinModel.Description;
        set
        {
            if (_pinModel.Description != value)
            {
                _pinModel.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }

    public string ImagePath
    {
        get => _pinModel.ImagePath;
        set
        {
            if (_pinModel.ImagePath != value)
            {
                _pinModel.ImagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
    }

    public Vector2 Position
    {
        get => _pinModel.Position;
        set
        {
            if (_pinModel.Position != value)
            {
                _pinModel.Position = value;
                OnPropertyChanged(nameof(Position));
            }
        }
    }

    public Sprite PinSprite => LoadSprite(_pinModel.ImagePath);

    private Sprite LoadSprite(string path)
    {
        if (string.IsNullOrEmpty(path) || !File.Exists(path)) return null;
        byte[] fileData = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData);
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }

    public void UpdatePosition()
    {
        Debug.Log(_pinModel.Position);
        ServiceLocator.GetService<PinService>().SavePin(this.PinModel);
    }

    public void ShowFullDetails()
    {
        ServiceLocator.GetService<ShowPinFullDetailsService>().ShowDetails(this);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}