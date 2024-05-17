using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _char;
    [SerializeField] private GameObject _player;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _char.Count; i++)
        {
            if (!_char[i].activeSelf)
            {
                _char.RemoveAt(i);
            }
            else
            {
                break;
            }
        }

        if(_char.Count == 0)
        {
            UIManager.Instance.OpenUI<CanvasVictory>();
        } 
        else if (!_player.activeSelf)
        {
            UIManager.Instance.OpenUI<CanvasFail>();
        }
    }
}
