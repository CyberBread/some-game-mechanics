using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRenderer : MonoBehaviour
{
    [SerializeField] private Color outlineColor;
//    [SerializeField] private Renderer outlineRendered;
    [SerializeField] private Camera portalCamera;
    [SerializeField] private int renderIteration = 3;

    private Material material;
    private Renderer renderer;
    private RenderTexture renderTexture;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        material = renderer.material;
        renderTexture = new RenderTexture(Screen.width, Screen.height, 0);
        material.mainTexture = renderTexture;
        portalCamera.targetTexture = renderTexture;
//        outlineRendered.material.color = outlineColor;
        material.SetInt("DrawingFlag", 1);
    }

    public void Renderer(Camera mainCamera, Transform otherPortal)
    {
        if (!renderer.isVisible)
            return;

        material.SetInt("DrawningFlag", 1);

        for(int i = renderIteration - 1; i>=0; i--)
        {
            RenderInternal(mainCamera, otherPortal, i);
        }
    }

    private void RenderInternal(Camera mainCamera, Transform otherPortal, int iteration)
    {
        Transform enterPoint = transform;
        Transform exitPoint = otherPortal;

        Transform portalCameraTransform = portalCamera.transform;
        portalCameraTransform.position = mainCamera.transform.position;
        portalCamera.transform.rotation = mainCamera.transform.rotation;

        for(int i = 0; i <= iteration; i++)
        {
            portalCameraTransform.MirrorPosition(enterPoint, exitPoint);
            portalCameraTransform.MirrorRotation(enterPoint, exitPoint);
        }

        SetupProjection(mainCamera, exitPoint);

        portalCamera.Render();
    }

    private void SetupProjection(Camera mainCamera, Transform exitPoint)
    {
        Plane plane = new Plane(-exitPoint.forward, exitPoint.position);
        Vector4 clipPlane = new Vector4(plane.normal.x, plane.normal.y, plane.normal.z, plane.distance);
        Vector4 clipPlaneCameraSpace = Matrix4x4.Transpose(Matrix4x4.Inverse(portalCamera.worldToCameraMatrix)) * clipPlane;
        var newMatrix = mainCamera.CalculateObliqueMatrix(clipPlaneCameraSpace);
        portalCamera.projectionMatrix = newMatrix;
    }
}
