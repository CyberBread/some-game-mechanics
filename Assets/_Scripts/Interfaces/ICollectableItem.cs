using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectableItem
{
    void Collect();
    string GetName();
    GameObject GetGameObject();

}
