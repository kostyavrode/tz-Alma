using System.IO;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PinView : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public TMP_Text titleText;
    public TMP_Text descriptionText;

    public Image pinImage;

    private Button pinButton;

    private PinViewModel viewModel;
    
    private Vector2 initialPosition;
    private bool isDragging = false;
    private DragModeService dragModeService;

    private void Start()
    {
        pinButton = GetComponent<Button>();
        pinButton.onClick.AddListener(OnPinClicked);
        dragModeService = ServiceLocator.GetService<DragModeService>();
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
            if (args.PropertyName == nameof(viewModel.Title))
                titleText.text = viewModel.Title;

            if (args.PropertyName == nameof(viewModel.Description))
                descriptionText.text = viewModel.Description;

            if (args.PropertyName == nameof(viewModel.ImagePath))
                pinImage.sprite = LoadSprite(viewModel.ImagePath);
        };
    }

    private Sprite LoadSprite(string path)
    {
        if (string.IsNullOrEmpty(path) || !File.Exists(path)) return null;
        byte[] fileData = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData);
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }

    public void OnPinClicked()
    {
        viewModel.ShowFullDetails();
    }

    private void UpdatePinPosition()
    {
        Vector2 newPinPosition = transform.localPosition;
        Debug.Log("Pin moved to: " + newPinPosition);

        viewModel.Position = newPinPosition;
        viewModel.UpdatePosition();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!dragModeService.IsDragModeActive()) return;

        isDragging = true;
        initialPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;

        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = newPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDragging) return;

        isDragging = false;
        UpdatePinPosition();
    }
}