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

    public void AddPin(PinModel pinData)
    {
        PinViewModel newPin = pinFactory.CreatePin(pinData);
        Pins.Add(newPin);
    }

    public void RemovePin(PinViewModel pin)
    {
        Pins.Remove(pin);
    }
}