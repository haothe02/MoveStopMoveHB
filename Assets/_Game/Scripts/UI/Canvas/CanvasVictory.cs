using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasVictory : UICanvas
{
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] Canvas _vicCan;
    public void SetBestScore(int score)
    {
        _scoreText.text = score.ToString();
    }
    public void MainMenuButton()
    {
        this.Close(0);
        _vicCan.enabled = true;
        SceneManager.LoadScene("MenuScene");
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }
}
