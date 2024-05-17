using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Image _overlay;
    [SerializeField] Image _itemImage;
    [SerializeField] Image _itemLock;

    private ItemBase _thisItem;
    private ShopItem _itemShop;
    public void ShowInfo(ItemBase newItem, ShopItem newShop)
    {
        _thisItem = newItem;
        _itemShop = newShop;
        if (_thisItem )
        {
            _itemImage.sprite = _thisItem._itemIcon;
        }
    }
    // TO DO: display tung item len tren nhan vat
    public void ClickOn()
    {
        _overlay.enabled = false;
        if (_thisItem)
        {
            //_overlay.enabled = true;
            _itemShop.SetPriceAndModal(_thisItem._cost, _thisItem._material, _thisItem._modal);
        }
       
    }
}
