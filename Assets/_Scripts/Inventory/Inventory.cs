﻿using System.Collections;
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
            EquipItem("BubleGun");
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

    public void EquipItem(string itemName)
    {
        if (!items.ContainsKey(itemName))
        {
            return;
        }

        items.TryGetValue(itemName, out ICollectableItem item);
        GameObject itemGO = item.GetGameObject();
        itemGO.transform.SetParent(itemAnchor);
        itemGO.SetActive(true);
        itemGO.transform.position = itemAnchor.position;
        itemGO.transform.rotation = itemAnchor.rotation;

        equipedItem = item;
    }
}