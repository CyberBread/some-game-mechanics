using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectableItem
{
    bool isEquiped { get; set; }
    void Collect();
    string GetName();
    GameObject GetGameObject();
}
