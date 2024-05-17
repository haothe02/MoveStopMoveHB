using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    [SerializeField] bool _isDestroyOnClose = false;

    private void Awake()
    {
        // manage rabbit ears mobile
        RectTransform rect = GetComponent<RectTransform>();
        float ratio = (float)Screen.width / (float)Screen.height;
        if(ratio > 2.1f)
        {
            Vector2 leftBottom = rect.offsetMin;
            Vector2 rightTop = rect.offsetMax;

            leftBottom.y = 0f;
            rightTop.y = 100f;
            
            rect.offsetMin = leftBottom;
            rect.offsetMax = rightTop;
        }
    }
    // call canvas before active
    public virtual void SetUp()
    {

    }
    //call cavas after active 
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }
    //close canvas after time
    public virtual void Close(float time) 
    {
        Invoke(nameof(CloseDirectly), time);
    }
    //close canvas directly
    public virtual void CloseDirectly()
    {
        if (_isDestroyOnClose)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
