using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolControl : MonoBehaviour
{
    [SerializeField] PoolAmount[] _poolAmounts;
    // Start is called before the first frame update
    void Awake()
    {
        GameUnit[] gameUnits = Resources.LoadAll<GameUnit>("Pool/");
        //load tu resources
        for (int i = 0; i < gameUnits.Length; i++)
        {
            SimplePool.Preload(gameUnits[i], 0, new GameObject(gameUnits[i].name).transform);
        }
        //load tu list keo tha
        for (int i = 0; i < _poolAmounts.Length; i++)
        {
            SimplePool.Preload(_poolAmounts[i]._prefab, _poolAmounts[i]._amount, _poolAmounts[i]._parent);
        }
    }
}

[System.Serializable]
public class PoolAmount
{
    public GameUnit _prefab;
    public Transform _parent;
    public int _amount;
}
public enum BulletType
{
    Arrow = 0,
    Axe_0 = 1,
    Axe_1 = 2,
    Bommerang = 3,
    Candy_0 = 4,
    Candy_1 = 5,
    Candy_2 = 6,
    Candy_4 = 7,
    Hammer = 8,
    Knife = 9,
    Uzi = 10,
    Z = 11
}
public enum WeaponType
{
    Arrow = 0,
    Axe_0 = 1,
    Axe_1 = 2,
    Bommerang = 3,
    Candy_0 = 4,
    Candy_1 = 5,
    Candy_2 = 6,
    Candy_4 = 7,
    Hammer = 8,
    Knife = 9,
    Uzi = 10,
    Z = 11
}

