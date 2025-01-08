using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private Transform uiParent;
    [SerializeField] private MapHelperService mapInitializeService;
    [SerializeField] private MapView mapView;

    private void Start()
    {
        InitMapInitialService();
    }
    private void InitMapInitialService()
    {
        mapInitializeService.SetPinContainer(mapView.transform);
        mapInitializeService.SetMapView(mapView);
        mapInitializeService.StartService();
    }
}
