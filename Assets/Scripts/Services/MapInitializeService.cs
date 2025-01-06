using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInitializeService : MonoBehaviour
{
    [SerializeField] private GameObject pinPrefab;
    [SerializeField] private Transform pinContainer;
    [SerializeField] private MapView mapView;

    private void Start()
    {
        var pinServie = new PinService();
        var pinFactory = new PinFactory(pinPrefab, pinContainer);
        var mapViewModel = new MapViewModel(pinFactory);

        PinListModel savedPins = pinServie.LoadPins();
        Debug.Log("Saved Pins"+savedPins.pins.Count);
        foreach (var pinData in savedPins.pins)
        {
            PinViewModel pinViewModel = new PinViewModel
            {
                Title = pinData.Title,
                Description = pinData.Description,
                Position = pinData.Position,
            };
            mapViewModel.Pins.Add(pinViewModel);

            var pinObject = pinFactory.CreatePin(pinData.Position);
            Debug.Log("Create Pin in:" + pinData.Position);
            pinObject.Title = pinData.Title;
            pinObject.Description = pinData.Description;
        }

        mapView.SetViewModel(mapViewModel);
    }
}
