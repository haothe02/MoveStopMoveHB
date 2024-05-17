using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasLevelMenu : UICanvas
{
    public void OpenAsset()
    {
        Close(0);
        SceneManager.LoadScene("SampleScene");
    }
}
