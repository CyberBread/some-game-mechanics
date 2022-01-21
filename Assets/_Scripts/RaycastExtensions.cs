using UnityEngine;

public static class RaycastExtensions 
{
    public static RaycastHit RaycastFromViewportCenter(float rayDistance, int layerMask)
    {
        Vector3 origin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Physics.Raycast(origin, Camera.main.transform.forward, out RaycastHit hit, rayDistance, layerMask);
        return hit;
    }
}
