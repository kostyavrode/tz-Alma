using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInitializeService : MonoBehaviour
{
    [SerializeField] private GameObject pinPrefab;
    private Transform pinContainer;
    private MapView mapView;
    private PinDetailsView pinDetailsView;

    public void StartService()
    {
        var pinService = new PinService();
        var pinFactory = new PinFactory(pinPrefab, pinContainer);
        pinFactory.SetPinDetailsView(pinDetailsView);
        var mapViewModel = new MapViewModel(pinFactory);

        PinListModel savedPins = pinService.LoadPins();

        foreach (var pinData in savedPins.pins)
        {
            mapViewModel.AddPin(pinData);
        }

        mapView.SetViewModel(mapViewModel);
        
    }
    public void SetPinContainer(Transform container)
    {
        pinContainer=container;
    }
    public void SetMapView(MapView mapView)
    {
        this.mapView = mapView;
    }
    public void SetPinDetailsView(PinDetailsView pinDetailsView)
    {
        this.pinDetailsView=pinDetailsView;
    }
}
