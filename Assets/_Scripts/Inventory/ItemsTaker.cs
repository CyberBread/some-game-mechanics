using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsTaker : MonoBehaviour
{
    private readonly int collectableItemLayerMask = 1 << 8;
    private float takeDistance = 2f;

    private Inventory inventory;
    private ICollectableItem item;
    private SimpleRaycaster simpleRaycaster;
    
    private void Start()
    {
        inventory = GetComponent<Inventory>();
        simpleRaycaster = GetComponent<SimpleRaycaster>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hittedItem = simpleRaycaster.RaycastFromViewportCenter(takeDistance, collectableItemLayerMask);
            if(hittedItem.transform == null)
            {
                return;
            }

            item = hittedItem.transform.GetComponent<ICollectableItem>();
            if(item != null)
            {
                inventory.AddItem(item);
            }
        }
    }
}
