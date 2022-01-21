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
        Spawn();
    }

    private void Update()
    {
        if (spawnedObject.transform.IsChildOf(transform))
        {
            Levitate();
        }
    }

    private void Levitate()
    {
        Vector3 deltaRot = Time.deltaTime * Vector3.up * rotationSpeed;
        Vector3 newRot = spawnedObjectT.rotation.eulerAngles + deltaRot;
        spawnedObjectT.eulerAngles = newRot;
    }

    private void Spawn()
    {
        spawnedObject = Instantiate<GameObject>(spawnObjectPrefab);

        spawnedObjectT = spawnedObject.transform;
        Vector3 spawnPosition = spawnedObjectT.position;
        spawnPosition.y += levitationHeight;
        spawnedObjectT.position = spawnPosition;
        spawnedObjectT.SetParent(this.transform);


    }
}
