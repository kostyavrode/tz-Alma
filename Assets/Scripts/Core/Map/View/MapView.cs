using UnityEngine;
using UnityEngine.EventSystems;

public class MapView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private RectTransform mapRectTransform;
    [SerializeField] private MapViewModel mapViewModel;

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void SetViewModel(MapViewModel vm)
    {
        mapViewModel = vm;
    }
}
