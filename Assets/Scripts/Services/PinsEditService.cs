using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinsEditService : MonoBehaviour
{
    
    private bool isDeletingModeActive=true;
    private void Awake()
    {
        ServiceLocator.RegisterService(this);
    }

    public void ToggleDeleteMode()
    {
        isDeletingModeActive = !isDeletingModeActive;
    }

    public bool IsDeletingModeActive()
    {
        return isDeletingModeActive;
    }
}
