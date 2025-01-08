using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHelperService : MonoBehaviour
{
    [SerializeField] private GameObject pinPrefab;
    [SerializeField] private PinCreationView pinCreationViewPrefab;
    private Transform pinContainer;
    private MapView mapView;
    private PinCreationView pinCreationView;

    private void Awake()
    {
        ServiceLocator.RegisterService(this);
    }

    public Vector2 PinSpawnPoint { get; set; }

    public void StartService()
    {
        var pinService = new PinService();
        pinService.Init();

        var pinFactory = new PinFactory(pinPrefab, pinContainer);


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

    public void InstantiateCreatePanel()
    {
        PinCreationViewModel pinCreationViewModel = new PinCreationViewModel();

        pinCreationView = Instantiate(pinCreationViewPrefab);
        pinCreationView.transform.parent = mapView.transform.parent;
        pinCreationView.transform.localScale = Vector3.one;
        pinCreationView.transform.localPosition=Vector3.zero;

        pinCreationView.SetViewModel(pinCreationViewModel);
    }
}
