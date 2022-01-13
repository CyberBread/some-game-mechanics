using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colt1911 : Weapon
{
    private readonly int shotItemLayerMask = 1 << 0;
    private float shotDistance = 50f;
    private SimpleRaycaster raycaster;

    private void Start()
    {
        raycaster = GetComponent<SimpleRaycaster>();
    }
    public override void AlternativeShot()
    {
        throw new System.NotImplementedException();
    }

    public override void MainShot()
    {
        raycaster.RaycastFromViewportCenter(10, shotItemLayerMask);
    }

    public override void Reload()
    {
        throw new System.NotImplementedException();
    }

    public override void SetWeaponName()
    {
        weaponName = WeaponName.Colt1911;
    }

}
