using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasShopWeapon : UICanvas
{
    public void Exit()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasPlayMenu>();
    }
}
