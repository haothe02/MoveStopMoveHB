using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SimplePool 
{
    private static Dictionary<BulletType, Pool> _poolInstance = new Dictionary<BulletType, Pool>();
    
    //khoi tao pool moi
    public static void Preload(GameUnit prefab, int amount, Transform parent)
    {
        if (prefab == null)
        {
            Debug.LogError("PREFAB IS EMPTY !!!");
            return;
        }
        if (!_poolInstance.ContainsKey(prefab._PoolType) || _poolInstance[prefab._PoolType] == null)
        {
            Pool p = new Pool();
            p.PreLoad(prefab, amount, parent);
            _poolInstance[prefab._PoolType] = p;
        }
    }

    //lay phan tu ra
    public static T Spawn<T>(BulletType poolType, Vector3 pos, Quaternion rot) where T : GameUnit
    {
        if (!_poolInstance.ContainsKey(poolType))
        {
            Debug.LogError(poolType + "IS NOT PRELOAD !!!");
            return null;
        }
        return _poolInstance[poolType].Spawn(pos, rot) as T;
    }

    //tra phan tu vao
    public static void DeSpawn(GameUnit unit)
    {
        if (!_poolInstance.ContainsKey(unit._PoolType))
        {
            Debug.LogError(unit._PoolType + "IS NOT PRELOAD !!!");
        }
        _poolInstance[unit._PoolType].DeSpawn(unit);
    }

    //thu thap phan tu
    public static void Collect(BulletType poolType)
    {

        if (!_poolInstance.ContainsKey(poolType))
        {
            Debug.LogError(poolType + "IS NOT RELOAD !!!");
        }
        _poolInstance[poolType].Collect();
    }

    //thu thap tat ca phan tu
    public static void CollectAll()
    {
        foreach (var item in _poolInstance.Values)
        {
            item.Collect();
        }
    }

    //destroy 1 pool
    public static void Release(BulletType poolType)
    {
        if (!_poolInstance.ContainsKey(poolType))
        {
            Debug.LogError(poolType + "IS NOT RELOAD !!!");
        }
        _poolInstance[poolType].Release();
    }

    //destroy tat ca cac pool
    public static void ReleaseAll()
    {
        foreach (var item in _poolInstance.Values)
        {
            item.Release();
        }
    }

}
public class Pool
{
    Transform _parent;
    GameUnit _prefab;
    //List cac unit dang o trong pool
    Queue<GameUnit> _inactives = new Queue<GameUnit>();
    //List cac unit dang duoc su dung
    List<GameUnit> _actives = new List<GameUnit>();
    
    //khoi tao pool
    public void PreLoad(GameUnit prefab, int amount, Transform parent)
    {
        this._parent = parent;
        this._prefab = prefab;

        for (int i = 0; i < amount; i++)
        {
            DeSpawn(GameObject.Instantiate(prefab, parent));
        }
    }

    //Lay phan tu ra tu pool
    public GameUnit Spawn(Vector3 pos, Quaternion rot)
    {
        GameUnit unit;
        if(_inactives.Count <= 0)
        {
            unit = GameObject.Instantiate(_prefab, _parent);
        }
        else
        {
            unit = _inactives.Dequeue();
        }

        unit._TF.SetPositionAndRotation(pos, rot);
        _actives.Add(unit);
        unit.gameObject.SetActive(true);

        return unit;
    }

    //tra phan tu vao trong pool
    public void DeSpawn(GameUnit unit)
    {
        if (unit != null && unit.gameObject.activeSelf) 
        {
            _actives.Remove(unit);
            _inactives.Enqueue(unit);
            unit.gameObject.SetActive(false);
        }
    }

    //thu thap tat ca phan tu dang dung vao pool
    public void Collect()
    {
        while (_inactives.Count > 0)
        {
            DeSpawn(_actives[0]);
        }
    }

    //Destroy tat ca phan tu
    public void Release()
    {
        Collect();
        while (_inactives.Count > 0)
        {
            GameObject.Destroy(_inactives.Dequeue().gameObject);
        }
        _inactives.Clear();
    }
}
