using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField] private GameObject spawnObjectPrefab;
    [SerializeField] private float levitationHeight = 1f;
    [SerializeField] private float rotationSpeed = 30f;

    private Transform spawnedObjectT;
    private GameObject spawnedObject;

    private void Start()
    {
        SpawnAndSetPosition();
    }

    private void Update()
    {
        if (spawnedObject.transform.IsChildOf(transform))
        {
            LevitateAnObject();
        }
    }

    private void LevitateAnObject()
    {
        Vector3 deltaRot = Time.deltaTime * Vector3.up * rotationSpeed;
        Vector3 newRot = spawnedObjectT.rotation.eulerAngles + deltaRot;
        spawnedObjectT.eulerAngles = newRot;
    }

    private void SpawnAndSetPosition()
    {
        spawnedObject = Instantiate<GameObject>(spawnObjectPrefab);

        Vector3 newPosition = transform.position;
        newPosition.y += levitationHeight;

        spawnedObjectT = spawnedObject.transform;
        spawnedObjectT.position = newPosition;
        spawnedObjectT.SetParent(this.transform);
    }
}
