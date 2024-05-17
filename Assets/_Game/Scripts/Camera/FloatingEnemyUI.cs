using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemyUI : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private Transform _target;
    void Update()
    {
        transform.LookAt(_cam.transform);
        transform.rotation = _cam.transform.rotation;

    }
}
