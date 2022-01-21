using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectableItem
{
    public bool isEquiped { get; set; }
    public void Collect();
    public string GetName();
    public GameObject GetGameObject();
}
