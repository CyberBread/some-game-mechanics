using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    [SerializeField] private Transform mainCameraTransform;
    [SerializeField] private float minVerticalRotation = -70f;
    [SerializeField] private float maxVerticalRotation = 80f;
    [SerializeField] private float sensitivity = 4f;

    private float rotY = 0;
    private bool cursorIsLock = false;

    // Start is called before the first frame update
    void Start()
    {
        if (mainCameraTransform == null)
            mainCameraTransform = GetComponentInChildren<Camera>().transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);

        rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, minVerticalRotation, maxVerticalRotation);
        mainCameraTransform.localEulerAngles = new Vector3(rotY, transform.rotation.x, 0);
    }

    private void CursorHide()
    {

    }
}
