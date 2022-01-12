using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Portal otherPortal;
    [SerializeField] private Collider[] walls;
    [SerializeField] private PortalRenderer renderer;

    private Teleporter triggeredObject;

    private void Update()
    {
        if (triggeredObject != null)
        {
            Vector3 relativePosition = transform.InverseTransformPoint(triggeredObject.transform.position);
            if (relativePosition.z > 0.0f)
            {
                triggeredObject.Teleport();
            }
        }
    }

    public void Render(Camera mainCamera)
    {
        renderer.Renderer(mainCamera, otherPortal.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        Teleporter teleporter = GetComponent<Teleporter>();
        if(teleporter != null)
        {
            triggeredObject = teleporter;
            teleporter.EnterPortal(this, otherPortal, walls);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var teleporter = other.GetComponent<Teleporter>();
        teleporter?.ExitPortal(walls);
        triggeredObject = null;
    }

}
