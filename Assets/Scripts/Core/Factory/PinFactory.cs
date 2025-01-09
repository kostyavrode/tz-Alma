using UnityEngine;

public class PinFactory
{
    private GameObject pinPrefab;
    private Transform pinContainer;
    private ShowPinDetailsService pinDetailsView;

    public PinFactory(GameObject prefab, Transform container)
    {
        pinPrefab = prefab;
        pinContainer = container;

        ServiceLocator.RegisterService(this);
    }

    public PinViewModel CreatePin(PinModel pinModel)
    {
        GameObject pinObject = Object.Instantiate(pinPrefab, pinContainer);
        pinObject.GetComponent<RectTransform>().anchoredPosition = pinModel.Position;

        PinViewModel pinViewModel = new PinViewModel(pinModel);
        
        PinView pinView = pinObject.GetComponent<PinView>();
        pinView.SetViewModel(pinViewModel);

        return pinViewModel;
    }

    public void CreateNewPin(PinModel pinModel)
    {
        ServiceLocator.GetService<PinService>().AddPin(pinModel);
        CreatePin(pinModel);
    }
}