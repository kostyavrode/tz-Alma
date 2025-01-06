using UnityEngine;

public class PinFactory
{
    private GameObject pinPrefab;
    private Transform pinContainer;

    public PinFactory(GameObject prefab, Transform container)
    {
        pinPrefab = prefab;
        pinContainer = container;
    }

    public PinViewModel CreatePin(Vector2 position)
    {
        GameObject pinObject = Object.Instantiate(pinPrefab, pinContainer);
        pinObject.GetComponent<RectTransform>().anchoredPosition = position;

        PinView pinView = pinObject.GetComponent<PinView>();
        PinViewModel pinViewModel = new PinViewModel
        {
            Title = "Новый пин",
            Description = "Описание пина",
            Position = position
        };
        pinView.SetViewModel(pinViewModel);

        return pinViewModel;
    }
}