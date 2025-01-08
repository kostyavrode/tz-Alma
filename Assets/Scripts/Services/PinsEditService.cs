using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinsEditService : MonoBehaviour
{
    private bool isDragModeActive = true;
    
    private bool isDeletingModeActive=true;
    private void Awake()
    {
        ServiceLocator.RegisterService(this);
    }

    public void ToggleDragMode()
    {
        isDragModeActive = !isDragModeActive;
        Debug.Log("Drag mode: " + (isDragModeActive ? "Active" : "Inactive"));
    }

    public bool IsDragModeActive()
    {
        return isDragModeActive;
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
