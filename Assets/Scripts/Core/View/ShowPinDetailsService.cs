using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowPinDetailsService : MonoBehaviour
{
    [SerializeField] private GameObject showFullDetailsPanel;
    [SerializeField] private GameObject showDetailsPanel;

    [SerializeField] private TMP_InputField titleInputField;
    [SerializeField] private TMP_InputField descriptionInputField;

    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;

    [SerializeField] private Image pinImage;
    [SerializeField] private Button closeButton;

    [SerializeField] private Button openFullDetailsButton;

    private PinViewModel pinViewModel;

    private void Awake()
    {
        ServiceLocator.RegisterService(this);
        closeButton.onClick.AddListener(CloseFullDetails);
        openFullDetailsButton.onClick.AddListener(CloseDetails);
        showFullDetailsPanel.SetActive(false);
    }

    public void ShowFullDetails()
    {
        titleInputField.text = pinViewModel.Title;
        descriptionInputField.text = pinViewModel.Description;
        pinImage.sprite = pinViewModel.PinSprite;
        showFullDetailsPanel.SetActive(true);
    }

    public void ShowDetails(PinViewModel viewModel)
    {
        pinViewModel = viewModel;
        title.text = viewModel.Title;
        description.text = viewModel.Description;
        showDetailsPanel.transform.localPosition = viewModel.Position;
        showDetailsPanel.SetActive(true);
    }

    public void CloseFullDetails()
    {

        pinViewModel.Title = titleInputField.text;
        pinViewModel.Description = descriptionInputField.text;

        ServiceLocator.GetService<PinService>().SavePin(pinViewModel.PinModel);
        showFullDetailsPanel.SetActive(false);

    }

    public void CloseDetails()
    {
        showDetailsPanel.SetActive(false);
        ShowFullDetails();
    }

}
