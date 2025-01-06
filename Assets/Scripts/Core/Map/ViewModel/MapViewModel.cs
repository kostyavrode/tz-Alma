using System.Collections.ObjectModel;
using UnityEngine;

public class MapViewModel
{
    public ObservableCollection<PinViewModel> Pins { get; private set; } = new ObservableCollection<PinViewModel>();
    private PinFactory pinFactory;

    public MapViewModel(PinFactory factory)
    {
        pinFactory = factory;
    }

    public void AddPin(Vector2 position)
    {
        PinViewModel newPin = pinFactory.CreatePin(position);
        Pins.Add(newPin);
    }

    public void RemovePin(PinViewModel pin)
    {
        Pins.Remove(pin);
    }
}