using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scriptable
{
    public enum WeaponType
    {
        Arrow = 0,
        Axe = 1,
        Axe_1 = 2,
        Boomerang = 3,
        Candy_0 = 4,
        Candy_1 = 5,
        Candy_2 = 6,
        Candy_4 = 7,
        Hammer = 8,
        Knife = 9,
        Uzi = 10,
        Z = 11
    }
    [CreateAssetMenu(fileName = "UIWeaponData", menuName = "ScriptableObjects/UIWeaponData")]
    public class UIWeaponData : ScriptableObject
    {
        public List<GameObject> _weaponUIPrefab = new List<GameObject>();
        public GameObject GetWeapon(WeaponType weaponType)
        {
            return _weaponUIPrefab[(int)weaponType];
        }
    }
}
