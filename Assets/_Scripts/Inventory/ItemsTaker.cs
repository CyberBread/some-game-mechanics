using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsTaker : MonoBehaviour
{
    private readonly int collectableItemLayerMask = 1 << 8;
    private float takeDistance = 2f;

    private Inventory inventory;
    private ICollectableItem item;
    
    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            TakeItem();
        }
    }

    private void TakeItem()
    {
        RaycastHit hittedItem = RaycastExtensions.RaycastFromViewportCenter(takeDistance, collectableItemLayerMask);
        Transform hittedItemTransform = hittedItem.transform;
        if (hittedItemTransform == null)
        {
            return;
        }

        if (!hittedItemTransform.TryGetComponent<ICollectableItem>(out ICollectableItem item))
        {
            return;
        }
        inventory.AddItem(item);
    }
}
