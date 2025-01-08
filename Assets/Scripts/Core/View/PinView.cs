using System.IO;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class PinView : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public Image pinImage;
    private PinViewModel viewModel;
    private Button pinButton;

    private void Start()
    {
        pinButton = GetComponent<Button>();
        pinButton.onClick.AddListener(OnPinClicked); // Привязываем метод к кнопке
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
}