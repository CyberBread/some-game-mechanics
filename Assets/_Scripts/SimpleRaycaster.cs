using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRaycaster : MonoBehaviour
{
    public RaycastHit RaycastFromViewportCenter(float rayDistance, int layerMask)
    {
        Vector3 origin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Physics.Raycast(origin, Camera.main.transform.forward, out RaycastHit hit, rayDistance, layerMask);
        return hit;
    }
}
