using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragModeService : MonoBehaviour
{
    private bool isDragModeActive = true;

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
}
