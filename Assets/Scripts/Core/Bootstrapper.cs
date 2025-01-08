using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private UIFactory uiFactory;
    [SerializeField] private Transform uiParent;
    [SerializeField] private MapInitializeService mapInitializeService;

    private PinService pinService;
    private MapViewModel mapViewModel;
    private MapView mapView;
    private PinDetailsView pinDetailsView;

    private void Start()
    {
        InstantiateUI();
    }
    private void InitMapInitialService()
    {
        mapInitializeService.SetPinDetailsView(pinDetailsView);
        mapInitializeService.SetPinContainer(mapView.transform);
        mapInitializeService.SetMapView(mapView);
        mapInitializeService.StartService();
        
    }
    private void InstantiateUI()
    {
        // Создаем UI элементы
        uiFactory.SetPinService(pinService);
        mapView = uiFactory.CreateMap(uiParent);
        pinDetailsView = uiFactory.CreatePinDetailsPanel(uiParent);
        Debug.Log(pinDetailsView.gameObject.name);
        InitMapInitialService();
    }
}
