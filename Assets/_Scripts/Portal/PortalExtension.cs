using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PortalExtension
{
    private static readonly Quaternion halfTurn = Quaternion.Euler(0, 180, 0);

    public static void MirrorPosition(this Transform target, Transform firstPortal, Transform secondPortal)
    {
        Vector3 turnedPosition = firstPortal.InverseTransformPoint(firstPortal.position);
        turnedPosition = halfTurn * turnedPosition;
        target.position = turnedPosition;
    }

    public static void MirrorRotation(this Transform target, Transform firstPortal, Transform secondPortal)
    {
        Quaternion turnedRotation = Quaternion.Inverse(firstPortal.rotation) * target.rotation;
        turnedRotation = turnedRotation * halfTurn;
        target.rotation = turnedRotation;
    }
}
