using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WeaponDataSo", menuName = "ScriptableObjects/WeaponDataSO")]
public class ListWeaponData : ScriptableObject
{
    public GameObject _weaponPrefab;
    public GameObject _bulletPrefab;
    public Sprite _weaponIcon;

    public int _cost;
    public int _attackSpeed;
}
