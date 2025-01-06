using UnityEngine;
using UnityEngine.EventSystems;

public class MapView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private RectTransform mapRectTransform;
    [SerializeField] private MapViewModel mapViewModel;

    public void OnPointerClick(PointerEventData eventData)
    {
        //if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
        //        mapRectTransform,
        //        eventData.position,
        //        eventData.pressEventCamera,
        //        out Vector2 localPoint))
        //{
        //    mapViewModel.AddPin(localPoint);
        //}
    }

    public void SetViewModel(MapViewModel vm)
    {
        mapViewModel = vm;
    }
}
