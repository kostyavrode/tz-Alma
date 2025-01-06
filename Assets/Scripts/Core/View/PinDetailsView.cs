using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PinDetailsView : MonoBehaviour
{

    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Image pinImage;
    [SerializeField] private Button closeButton;

    private void Start()
    {
        closeButton.onClick.AddListener(CloseDetails);
    }

    public void ShowDetails(PinViewModel viewModel)
    {
        titleText.text = viewModel.Title;
        descriptionText.text = viewModel.Description;
        pinImage.sprite = viewModel.PinSprite;
        gameObject.SetActive(true);
    }

    public void CloseDetails()
    {
        gameObject.SetActive(false);
    }

}
