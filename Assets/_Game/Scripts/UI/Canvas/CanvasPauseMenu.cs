using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasPauseMenu : UICanvas
{
    [SerializeField] TextMeshProUGUI _coinText;

    public void UpdateCoin(int coin)
    {
        _coinText.text = coin.ToString();
    }
    public void SettingButton()
    {
        UIManager.Instance.OpenUI<CanvasSetting>().SetState(this);

    }
}
