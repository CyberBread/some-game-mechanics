using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRaycaster : MonoBehaviour
{
    private readonly int raycastLayerMask = 1 << 8;
    private float rayDistance = 2f;

    public RaycastHit RaycastFromViewportCenter()
    {
        Vector3 origin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Physics.Raycast(origin, Camera.main.transform.forward, out RaycastHit hit, rayDistance, raycastLayerMask);
        return hit;
    }
}
