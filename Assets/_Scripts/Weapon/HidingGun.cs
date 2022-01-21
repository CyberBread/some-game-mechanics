using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingGun : Weapon
{
    [SerializeField] private float shotDistance = 50f;
    [SerializeField] private float fadeDuration = 0.2f;

    private void Awake()
    {
        SetWeaponName();
    }

    private void Update()
    {
        if (isEquiped)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                MainShot();
            }
        }
    }

    private IEnumerator Fade(Renderer renderer)
    {
        Color color = renderer.material.color;
        for(float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            color.a = alpha;
            renderer.material.color = color;
            yield return null;
        }
    }

    public override void AlternativeShot()
    {
        throw new System.NotImplementedException();
    }

    public override void MainShot()
   {
        //RaycastHit hit = RaycastExtensions.RaycastFromViewportCenter(shotDistance, 1 << LayerMask.NameToLayer("Default"));
        //StartCoroutine(Fade(hit.transform.GetComponent<Renderer>()));
    }

    public override void Reload()
    {
        throw new System.NotImplementedException();
    }

    public override void SetWeaponName()
    {
        weaponName = WeaponName.HidingGun;
    }
}
