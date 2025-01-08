using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PinViewModel : INotifyPropertyChanged
{

    public Action onPinDeleted;

    private PinModel pinModel;

    private PinsEditService pinsEditService;

    public PinViewModel(PinModel pinModel)
    {
        this.pinModel = pinModel;
    }

    public PinModel PinModel
    {
        get { return pinModel; }
    }

    public string Title
    {
        get => pinModel.Title;
        set
        {
            if (pinModel.Title != value)
            {
                pinModel.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }

    public string Description
    {
        get => pinModel.Description;
        set
        {
            if (pinModel.Description != value)
            {
                pinModel.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }

    public string ImagePath
    {
        get => pinModel.ImagePath;
        set
        {
            if (pinModel.ImagePath != value)
            {
                pinModel.ImagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
    }

    public Vector2 Position
    {
        get => pinModel.Position;
        set
        {
            if (pinModel.Position != value)
            {
                pinModel.Position = value;
                OnPropertyChanged(nameof(Position));
            }
        }
    }

    public Sprite PinSprite => LoadSprite(pinModel.ImagePath);

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
        Debug.Log(pinModel.Position);
        ServiceLocator.GetService<PinService>().SavePin(this.PinModel);
    }

    public void PinClicked()
    {
        if (!pinsEditService)
        {
            pinsEditService = ServiceLocator.GetService<PinsEditService>();
        }
        if (pinsEditService.IsDeletingModeActive())
        {
            ServiceLocator.GetService<PinService>().DeletePin(this);
            DeletePin();
        }
        else
        {
            ShowFullDetails();
        }
    }

    public void ShowFullDetails()
    {
        ServiceLocator.GetService<ShowPinFullDetailsService>().ShowDetails(this);
    }

    public void DeletePin()
    {
        onPinDeleted?.Invoke();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}