using Lean.Pool;
using Scriptable;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] PantColorData _pantData;
    [SerializeField] SkinColorData _skinData;
    [SerializeField] HatColorData _hatData;
    [SerializeField] TextMeshProUGUI _moneyCost;
    [SerializeField] Image _itemContainer;
    [SerializeField] SkinnedMeshRenderer _skinModal;
    [SerializeField] SkinnedMeshRenderer _pantModal;
    [SerializeField] Transform _hatPos;

    private ItemManager _item;
    private ItemType _type;
    private void Start()
    {
        SpawnHat();
    }
    public void HatDisable(GameObject itemHat)
    {
        LeanPool.Despawn(itemHat);
    }
    public void SetPriceAndModal(int itemCost, Material itemMat, GameObject itemModal)
    {
        _moneyCost.text = itemCost.ToString();
        switch (_type)
        {
            default:
            case ItemType.Hat:
                GameObject temp = LeanPool.Spawn(itemModal, _hatPos, false);
                temp.transform.SetParent(_hatPos);
                break;
            case ItemType.Skin:
                _skinModal.material = itemMat;
                break;
            case ItemType.Pant:
                _pantModal.material = itemMat;
                break;
        }
    }
    public void SpawnPant()
    {
        LeanPool.DespawnAll();
        for (int i = 0; i < _pantData._pant.Count; i++)
        {
            _item = LeanPool.Spawn(_itemContainer, transform.position, Quaternion.identity).GetComponent<ItemManager>();
            _item.transform.SetParent(transform);
            _item.transform.localScale = Vector3.one;
            _item.ShowInfo(_pantData._pant[i], this);
        }
        _type = ItemType.Pant;
    }
    public void SpawnSkin()
    {
        LeanPool.DespawnAll();
        for (int i = 0; i < _skinData._skin.Count; i++)
        {
            _item = LeanPool.Spawn(_itemContainer, transform.position, Quaternion.identity).GetComponent<ItemManager>();
            _item.transform.SetParent(transform);
            _item.transform.localScale = Vector3.one;
            _item.ShowInfo(_skinData._skin[i], this);
        }
        _type = ItemType.Skin;

    }
    public void SpawnHat()
    {
        LeanPool.DespawnAll();
        for (int i = 0; i < _hatData._hat.Count; i++)
        {
            _item = LeanPool.Spawn(_itemContainer, transform.position, Quaternion.identity).GetComponent<ItemManager>();
            _item.transform.SetParent(transform);
            _item.transform.localScale = Vector3.one;
            _item.ShowInfo(_hatData._hat[i], this);
        }
        _type = ItemType.Hat;
    }
}
public enum ItemType
{
    Hat,
    Pant,
    Skin
}
