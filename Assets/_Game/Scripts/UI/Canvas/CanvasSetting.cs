using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSetting : UICanvas
{
    [SerializeField] GameObject[] _buttons;
    [SerializeField] GameObject[] _sound;
    public void SetState(UICanvas canvas)
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            if(canvas is CanvasMainMenu)
            {
                _buttons[2].gameObject.SetActive(true);
            }
            else 
            {
                _buttons[0].gameObject.SetActive(true);
                _buttons[1].gameObject.SetActive(true);
            }
        }
    }
    public void MainMenuSetting()
    {
        UIManager.Instance.CloseAllUI();
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }
    
}
