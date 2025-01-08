using UnityEngine;

public class UIFactory : MonoBehaviour
{
    [SerializeField] private MapView mapPrefab;
    [SerializeField] private PinDetailsView pinDetailsPanelPrefab;
    private PinDetailsView pinDetailsView;
    private MapView mapView;
    private PinService pinService;

    public MapView CreateMap(Transform parent)
    {
        MapView mapInstance = Instantiate(mapPrefab, parent);
        return mapInstance;
    }

    public PinDetailsView CreatePinDetailsPanel(Transform parent)
    {
        if (pinDetailsView == null) // Создаем только один экземпляр панели
        {
            GameObject panelInstance = Instantiate(pinDetailsPanelPrefab.gameObject, parent);
            pinDetailsView = panelInstance.GetComponent<PinDetailsView>();
            pinDetailsView.SetPinService(pinService);
            //pinDetailsView.gameObject.SetActive(false); // Отключаем по умолчанию
        }
        return pinDetailsView;
    }

    public void SetPinService(PinService pinService)
    {
        this.pinService = pinService;
    }
}
