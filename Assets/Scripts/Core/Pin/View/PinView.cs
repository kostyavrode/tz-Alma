using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PinView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Image pinImage;

    private Button pinButton;
    private PinViewModel viewModel;

    private Vector2 offset;
    private bool isDragging = false;
    private bool isHoldActive = false;
    private float holdTimer = 0f;
    private float holdTime = 0.5f;

    private bool wasDragged = false;

    private PinsEditService dragModeService;
    private RectTransform rect;

    private void Start()
    {
        viewModel.onPinDeleted += DeleteSelf;

        pinButton = GetComponent<Button>();
        pinButton.onClick.AddListener(OnPinClicked);
        dragModeService = ServiceLocator.GetService<PinsEditService>();
    }

    private void Update()
    {
        if (isHoldActive)
        {
            holdTimer += Time.deltaTime;
            if (holdTimer >= holdTime)
            {
                ActivateDragMode();
            }
        }
    }

    private void OnDisable()
    {
        viewModel.onPinDeleted -= DeleteSelf;
    }

    public void SetViewModel(PinViewModel vm)
    {
        viewModel = vm;
        BindViewModel();
    }

    private void BindViewModel()
    {
        viewModel.PropertyChanged += (sender, args) =>
        {
        };
    }

    private void DeleteSelf()
    {
        Destroy(gameObject);
    }

    public void OnPinClicked()
    {
        if (!isDragging && !wasDragged)
        {
            viewModel.PinClicked();
        }

        wasDragged = false;
    }

    private void UpdatePinPosition()
    {
        Vector2 newPinPosition = transform.localPosition;
        Debug.Log("Pin moved to: " + newPinPosition);

        viewModel.Position = newPinPosition;
        viewModel.UpdatePosition();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHoldActive = true;
        holdTimer = 0f;

        if (!rect)
        {
            rect = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        }

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rect,
            Input.mousePosition,
            eventData.pressEventCamera,
            out Vector2 localMousePosition
        );

        offset = (Vector2)transform.localPosition - localMousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHoldActive = false;
        holdTimer = 0f;

        if (isDragging)
        {
            isDragging = false;
            UpdatePinPosition();
            wasDragged = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rect,
            Input.mousePosition,
            eventData.pressEventCamera,
            out Vector2 localMousePosition
        );

        transform.localPosition = localMousePosition + offset;
    }

    private void ActivateDragMode()
    {
        isDragging = true;
        isHoldActive = false;
    }
}
