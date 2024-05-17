using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using Scriptable;

public class SpawnWeaponItem : MonoBehaviour
{
    [SerializeField] GameObject[] _weaponData;

    private int _weaponSelected = 0;
    // show next weapon
    public void NextWeapon()
    {
        _weaponData[_weaponSelected].SetActive(false);
        _weaponSelected = (_weaponSelected + 1) % _weaponData.Length;
        _weaponData[_weaponSelected].SetActive(true);
    }
    // show previous weapon
    public void PreviousWeapon()
    {
        _weaponData[_weaponSelected].SetActive(false);
        _weaponSelected--;
        if(_weaponSelected < 0)
        {
            _weaponSelected += _weaponData.Length;
        }
        _weaponData[_weaponSelected].SetActive(true);
    }
}
