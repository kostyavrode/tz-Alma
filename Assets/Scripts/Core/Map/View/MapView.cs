using UnityEngine;
using UnityEngine.EventSystems;

public class MapView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private RectTransform mapRectTransform;
    [SerializeField] private MapViewModel viewModel;

    [SerializeField] private Canvas canvas;

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 screenPoint = Input.mousePosition;

        RectTransform canvasRect = canvas.GetComponent<RectTransform>();

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
                   canvasRect,
                   screenPoint,
                   null,
                   out Vector2 localPoint
               );

        viewModel.OnMapClicked(localPoint);
    }

    public void SetViewModel(MapViewModel vm)
    {
        viewModel = vm;
    }
}
