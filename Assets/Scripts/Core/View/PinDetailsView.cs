using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Profiling.HierarchyFrameDataView;

public class PinDetailsView : MonoBehaviour
{

    [SerializeField] private TMP_InputField titleInputField;
    [SerializeField] private TMP_InputField descriptionInputField;
    [SerializeField] private Image pinImage;
    [SerializeField] private Button closeButton;

    private PinViewModel pinViewModel;
    private PinService pinService;

    private void Start()
    {
        closeButton.onClick.AddListener(CloseDetails);
        gameObject.SetActive(false);
    }

    public void ShowDetails(PinViewModel viewModel)
    {
        pinViewModel = viewModel;
        titleInputField.text = viewModel.Title;
        descriptionInputField.text = viewModel.Description;
        pinImage.sprite = viewModel.PinSprite;
        gameObject.SetActive(true);
    }

    public void CloseDetails()
    {

        pinViewModel.Title = titleInputField.text;
        pinViewModel.Description = descriptionInputField.text;
        Debug.Log(pinService);
        pinService.SavePin(pinViewModel.ToDataModel());
        gameObject.SetActive(false);

    }

    public void SetPinService(PinService pinService)
    {
        Debug.Log(pinService);
        this.pinService = pinService;
    }

}
