using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasPlayMenu : UICanvas
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
    public void OpenShop()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasShop>();
    }
    public void OpenWeaponShop()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasShopWeapon>();
    }
    public void SettingButton()
    {
        UIManager.Instance.OpenUI<CanvasSetting>().SetState(this);

    }
    public void StartGame()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasLevelMenu>();
    }
}
