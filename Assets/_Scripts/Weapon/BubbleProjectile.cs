using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleProjectile : MonoBehaviour
{
    [SerializeField] private float maxProjectileScale = 5f;
    public Rigidbody rigidbody;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        rigidbody.velocity = Vector3.zero;
        
    }

    public void IncreaseScale()
    {
        if (transform.localScale.x <= maxProjectileScale)
        {
            Vector3 deltaScale = Time.deltaTime * Vector3.one;
            transform.localScale += deltaScale;
        }
    }
}
