using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WeaponName
{
    None,
    PortalGun,
    BubleGun,
    Colt1911
}


public abstract class Weapon : MonoBehaviour, ICollectableItem
{
    [SerializeField] private protected WeaponName weaponName = WeaponName.None;
    [SerializeField] private protected Transform projectileAnchor;
    [SerializeField] private protected float delayBetweenShots = 0.5f;

    abstract public void SetWeaponName();
    abstract public void MainShot();
    abstract public void AlternativeShot();
    abstract public void Reload();

    public void Collect()
    {
        gameObject.SetActive(false);
        gameObject.GetComponentInChildren<SphereCollider>().enabled = false;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public string GetName()
    {
        return weaponName.ToString();
    }


}
