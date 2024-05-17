using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : GameUnit
{
    public Rigidbody _bulletRig;
    public ListWeaponData _weaponData;
    protected CharacterManagement _attacker;
    protected Action<CharacterManagement, CharacterManagement> _onHit;

    // set bullet data for bullet
    public virtual void OnInit(CharacterManagement attacker, Action<CharacterManagement, CharacterManagement> onHit)
    {
        this._attacker = attacker;
        this._onHit = onHit;
    }
    public void SetUp(Vector3 direction)
    {
        transform.rotation = Quaternion.Euler(90, 0, -120);
        _bulletRig.velocity = direction.normalized * _weaponData._attackSpeed;
    }
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag(Constant.Tag.TAG_CHARACTER))
        {
            CharacterManagement victim = Cache.GetCharacter(_other);
            if (_attacker != victim)
            {
                _onHit?.Invoke(_attacker, victim);
                SimplePool.DeSpawn(this);
            }
        }
    }
}
