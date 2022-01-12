using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : Weapon
{

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
        throw new System.NotImplementedException();
    }

    public override void SetWeaponName()
    {
        weaponName = WeaponName.PortalGun;
    }

    public override void Reload()
    {
        throw new System.NotImplementedException();
    }
}