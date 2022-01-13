using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubleGun : Weapon
{
    [SerializeField] private BubbleProjectile projectilePrefab;
    [SerializeField] private byte clipCapicity = 6;
    [SerializeField] private float projectileVelocity = 10f;

    private BubbleProjectile lastPrjct;
    private Vector3 lastPrjctScale;

    private byte projectilesInClip;
    private List<BubbleProjectile> shootedPrjct;

    private void Awake()
    {
        SetWeaponName();
        projectilesInClip = clipCapicity;
        shootedPrjct = new List<BubbleProjectile>();
    }

    private void Update()
    {
        if (isEquiped)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                MainShot();
            }
            if (Input.GetButtonDown("Reload"))
            {
                Reload();
            }
            if (Input.GetButton("Fire2"))
            {
                AlternativeShot();
            }
        }
    }

    public override void AlternativeShot()
    {
        if (lastPrjct == null)
        {
            return;
        }
        lastPrjct.IncreaseScale();
    }

    public override void MainShot()
    {
        if (projectilesInClip == 0)
        {
            return;
        }

        BubbleProjectile projectile = Instantiate<BubbleProjectile>(projectilePrefab);
        projectile.transform.position = projectileAnchor.position;
        Vector3 fwd = projectileAnchor.localToWorldMatrix.MultiplyVector(Vector3.forward);
        projectile.rigidbody.velocity = fwd * projectileVelocity;

        lastPrjct = projectile;
        shootedPrjct.Add(projectile);

        projectilesInClip--;
    }

    public override void SetWeaponName()
    {
        weaponName = WeaponName.BubleGun;
    }

    public override void Reload()
    {
        projectilesInClip = clipCapicity;
        for (int i = 0; i < shootedPrjct.Count; i++)
        {
            Destroy(shootedPrjct[i].gameObject);
        }
        shootedPrjct.Clear();
    }
}
