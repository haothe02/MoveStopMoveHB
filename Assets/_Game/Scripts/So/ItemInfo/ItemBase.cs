using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ShopItem")]
public class ItemBase : ScriptableObject
{
    public Material _material;
    public GameObject _modal;
    public Sprite _itemIcon;
    public int _cost;
}
