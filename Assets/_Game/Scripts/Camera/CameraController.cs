using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;

    private Vector3 _offset;

    void Awake()
    {
        _player = FindObjectOfType<PlayerManagement>().transform;
        _offset = transform.position - _player.position;
    }
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _player.position + _offset, Time.deltaTime * _speed);
    }
    public void CameraScaleUp(Vector3 camScale)
    {
        _offset += camScale;
    }
}
