using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colt1911 : Weapon
{
    private readonly int hitLayerMask = 1 << 0;
    private float shotDistance = 50f;

    private void Awake()
    {
        SetWeaponName();
    }

    public override void AlternativeShot()
    {
        throw new System.NotImplementedException();
    }

    public override void MainShot()
    {
        //RaycastExtensions.RaycastFromViewportCenter(10, hitLayerMask);
        throw new System.NotImplementedException();
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
