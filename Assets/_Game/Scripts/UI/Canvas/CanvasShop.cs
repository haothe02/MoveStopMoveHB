using Scriptable;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasShop : UICanvas
{
    
    [SerializeField] TextMeshProUGUI _coinText;
    public override void SetUp()
    {
        base.SetUp();
        UpdateCoin(0);
    }
    public void UpdateCoin(int coin)
    {
        _coinText.text = coin.ToString();
    }
    public void Exit()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasPlayMenu>();
    }
    public void SettingButton()
    {
        UIManager.Instance.OpenUI<CanvasSetting>().SetState(this);
    }
  
}
