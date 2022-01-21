using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int capicity = 12;
    [SerializeField] private Transform itemAnchor;

    private ICollectableItem equipedItem;
    private Dictionary<string, ICollectableItem> items = new Dictionary<string, ICollectableItem>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipItem(WeaponName.BubleGun.ToString());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipItem(WeaponName.Colt1911.ToString());
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipItem(WeaponName.HidingGun.ToString());
        }
    }

    public bool AddItem(ICollectableItem item)
    {
        if(items.Count <= capicity)
        {
            items.Add(item.GetName(), item);
            item.Collect();
            return true;
        }
        return false;
    }

    private void EquipItem(string itemName)
    {
        if (!items.ContainsKey(itemName))
        {
            return;
        }
        if(equipedItem != null)
        {
            UneqipItem(equipedItem);
        }

        items.TryGetValue(itemName, out ICollectableItem item);
        GameObject itemGO = item.GetGameObject();

        Transform itemTransform = itemGO.transform;
        itemTransform.SetParent(itemAnchor);
        itemTransform.position = itemAnchor.position;
        itemTransform.rotation = itemAnchor.rotation;

        itemGO.SetActive(true);

        item.isEquiped = true;
        equipedItem = item;
    }

    private void UneqipItem(ICollectableItem equipedItem)
    {
        equipedItem.isEquiped = false;
        equipedItem.GetGameObject().SetActive(false);
    }
}
