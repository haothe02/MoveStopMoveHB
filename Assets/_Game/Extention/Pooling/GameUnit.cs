using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour
{
    public BulletType _PoolType;
    private Transform _tf;
    public Transform _TF
    {
        get
        {
            if (_tf == null)
            {
                _tf = transform;
            }
            return _tf;
        }
    }
}
