using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void HitItem(ItemType type)
    {
        switch (type)
        {
            case ItemType.BlockIce:
                break;
            case ItemType.IceCream:
                break;
        }
    }
}

/// <summary>Itemの種類</summary>
public enum ItemType
{
    IceCream,
    BlockIce
}
