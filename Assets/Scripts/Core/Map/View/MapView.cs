using UnityEngine;
using UnityEngine.EventSystems;

public class MapView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private RectTransform mapRectTransform;
    [SerializeField] private MapViewModel viewModel;

    public void OnPointerClick(PointerEventData eventData)
    {
        viewModel.OnMapClicked(eventData.position);
    }

    public void SetViewModel(MapViewModel vm)
    {
        viewModel = vm;
    }
}
