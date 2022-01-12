using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractiveItem
{
    [SerializeField] bool isClosed = false;
    [SerializeField] Transform turningPoint;

    public void Action()
    {
        Open();
    }
    private void Open()
    {
        
    }
}
