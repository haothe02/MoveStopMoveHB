using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    Dictionary<System.Type, UICanvas> _canvasActives = new Dictionary<System.Type, UICanvas>();
    Dictionary<System.Type, UICanvas> _canvasPrefabs = new Dictionary<System.Type, UICanvas>();
    [SerializeField] Transform _parent;

    private void Awake()
    {
        // load ui prefab from resources
        UICanvas[] prefabs = Resources.LoadAll<UICanvas>("UI/");
        for (int i = 0; i < prefabs.Length; i++)
        {
            _canvasPrefabs.Add(prefabs[i].GetType(), prefabs[i]);
        }
    }
    // open cavas
    public T OpenUI<T>() where T : UICanvas
    {
        T canvas = GetUI<T>();

        canvas.SetUp();
        canvas.Open();

        return canvas;
    }
    //close canvas after seconds
    public void CloseUI<T>(float time) where T : UICanvas
    {
        if (IsOpened<T>())
        {
            _canvasActives[typeof(T)].Close(time);
        }
    }
    //close canvas directly
    public void CloseUIDirectly<T>() where T : UICanvas
    {
        if (IsOpened<T>())
        {
            _canvasActives[typeof(T)].CloseDirectly();
        }
    }
    //check loaded canvas
    public bool IsLoaded<T>() where T : UICanvas
    {
        return _canvasActives.ContainsKey(typeof(T)) && _canvasActives[typeof(T)] != null;
    }   
    //check opened canvas
    public bool IsOpened<T>() where T : UICanvas
    {
        return IsLoaded<T>() && _canvasActives[typeof(T)].gameObject.activeSelf;
    }
    // get active canvas
    public T GetUI<T>() where T : UICanvas
    {
        if (!IsLoaded<T>())
        {
            T prefab = GetUIPrefab<T>();
            T canvas = Instantiate(prefab, _parent);
            _canvasActives[typeof(T)] = canvas;
        }
        return _canvasActives[typeof(T)] as T;
    }
    // get prefabs canvas
    private T GetUIPrefab<T>() where T : UICanvas
    {
        return _canvasPrefabs[typeof(T)] as T;
    }
    // close all canvas
    public void CloseAllUI()
    {
        foreach (var canvas in _canvasActives)
        {
            if(canvas.Value != null && canvas.Value.gameObject.activeSelf)
            {
                canvas.Value.Close(0);
            }
        }
    }
}
