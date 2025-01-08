using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PinCreationView : MonoBehaviour
{
    [SerializeField] private TMP_InputField titleInput;
    [SerializeField] private TMP_InputField descriptionInput;
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button cancelButton;

    private PinCreationViewModel viewModel;

    public void SetViewModel(PinCreationViewModel vm)
    {
        viewModel = vm;
        BindViewModel();
    }

    private void BindViewModel()
    {
        confirmButton.onClick.AddListener(CreateButtonClicked);
        cancelButton.onClick.AddListener(() => gameObject.SetActive(false));
    }

    private void CreateButtonClicked()
    {
        Debug.Log("Pin created");
        viewModel.CreatePin(titleInput.text, descriptionInput.text);
    }
}