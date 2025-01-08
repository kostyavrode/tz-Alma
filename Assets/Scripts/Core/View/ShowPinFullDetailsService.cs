using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Profiling.HierarchyFrameDataView;

public class ShowPinFullDetailsService : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_InputField titleInputField;
    [SerializeField] private TMP_InputField descriptionInputField;
    [SerializeField] private Image pinImage;
    [SerializeField] private Button closeButton;

    private PinViewModel pinViewModel;
    private PinService pinService;

    private void Awake()
    {
        ServiceLocator.RegisterService(this);
        closeButton.onClick.AddListener(CloseDetails);
        panel.SetActive(false);
    }

    public void ShowDetails(PinViewModel viewModel)
    {
        pinViewModel = viewModel;
        titleInputField.text = viewModel.Title;
        descriptionInputField.text = viewModel.Description;
        pinImage.sprite = viewModel.PinSprite;
        panel.SetActive(true);
    }

    public void CloseDetails()
    {

        pinViewModel.Title = titleInputField.text;
        pinViewModel.Description = descriptionInputField.text;

        ServiceLocator.GetService<PinService>().SavePin(pinViewModel.PinModel);
        panel.SetActive(false);

    }

    public void SetPinService(PinService pinService)
    {
        Debug.Log(pinService);
        this.pinService = pinService;
    }

}
