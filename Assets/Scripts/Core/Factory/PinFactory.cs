using UnityEngine;

public class PinFactory
{
    private GameObject pinPrefab;
    private Transform pinContainer;
    private PinDetailsView pinDetailsView;

    public PinFactory(GameObject prefab, Transform container)
    {
        pinPrefab = prefab;
        pinContainer = container;
    }

    public PinViewModel CreatePin(PinDataModel pinData)
    {
        GameObject pinObject = Object.Instantiate(pinPrefab, pinContainer);
        pinObject.GetComponent<RectTransform>().anchoredPosition = pinData.Position;

        PinViewModel pinViewModel = new PinViewModel
        {
            Title = pinData.Title,
            Description = pinData.Description,
            Position = pinData.Position,
            PinDetailsView = pinDetailsView
        };

        
        PinView pinView = pinObject.GetComponent<PinView>();
        pinView.SetViewModel(pinViewModel);

        return pinViewModel;
    }
    public void SetPinDetailsView(PinDetailsView pinDetailsView)
    {
        this.pinDetailsView=pinDetailsView;
    }
}