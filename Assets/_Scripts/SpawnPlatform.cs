using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField] private GameObject spawnObjectPrefab;
    [SerializeField] private float levitationHeight = 1f;
    [SerializeField] private float rotationSpeed = 30f;

    private Transform spawnedObjectTranform;
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

    public void Levitate()
    {
        Vector3 deltaRot = Time.deltaTime * Vector3.up * rotationSpeed;
        Vector3 newRot = spawnedObjectTranform.rotation.eulerAngles + deltaRot;
        spawnedObjectTranform.eulerAngles = newRot;
    }

    public void Spawn()
    {
        spawnedObject = Instantiate<GameObject>(spawnObjectPrefab); 
        Vector3 spawnPosition = transform.position;
        spawnPosition.y += levitationHeight;
        spawnedObject.transform.position = spawnPosition;
        spawnedObject.transform.SetParent(this.transform);

        spawnedObjectTranform = spawnedObject.transform;
    }
}
