using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasFail : UICanvas
{
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] Canvas _canFail;
    public void SetBestScore(int score)
    {
        _scoreText.text = score.ToString();
    }
    public void MainMenuButton()
    {
        this.Close(0);
        _canFail.enabled = false;
        SceneManager.LoadScene("MenuScene");
        UIManager.Instance.OpenUI<CanvasMainMenu>();

    }
    public void PlayAgainButton()
    {
        UIManager.Instance.OpenUI<CanvasLevelMenu>();
    }
}
