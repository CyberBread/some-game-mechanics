using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private Portal firstPortal;
    private Portal secondPortal;
    private Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    public void EnterPortal(Portal enterPortal, Portal exitPortal, Collider[] wallColliders)
    {
        firstPortal = enterPortal;
        secondPortal = exitPortal;
        for (int i = 0; i < wallColliders.Length; i++)
        {
            Physics.IgnoreCollision(collider, wallColliders[i]);
        }
    }

    public void ExitPortal(Collider[] wallColliders)
    {
        for (int i = 0; i < wallColliders.Length; i++)
        {
            Physics.IgnoreCollision(collider, wallColliders[i], false);
        }
    }

    public void Teleport()
    {
        var p1 = firstPortal.transform;
        var p2 = secondPortal.transform;

        transform.MirrorPosition(p1, p2);
        transform.MirrorRotation(p1, p2);
    }
}
