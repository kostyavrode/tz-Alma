using UnityEngine;

public class UIFactory : MonoBehaviour
{
    [SerializeField] private MapView mapPrefab;
    private ShowPinFullDetailsService pinDetailsView;
    private MapView mapView;
    private PinService pinService;

    public MapView CreateMap(Transform parent)
    {
        MapView mapInstance = Instantiate(mapPrefab, parent);
        return mapInstance;
    }

    public void SetPinService(PinService pinService)
    {
        this.pinService = pinService;
    }
}
