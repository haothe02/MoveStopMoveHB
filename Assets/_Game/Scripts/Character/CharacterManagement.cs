using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Lean.Pool;

public class CharacterManagement : MonoBehaviour
{
    public TextMeshProUGUI _levelText;
    public Transform _currentSkin;
    public ListWeaponData _weaponData;
    public Transform _attackRange;
    public SphereCollider _charRange;
    public Animator _animator;
    public Transform _weaponSpawnPos;
    public List<CharacterManagement> _listTarget = new List<CharacterManagement>();

    protected CharacterManagement _char;
    private Vector3 _direction;
    private Vector3 _levelScale = new Vector3(0.1f, 0.1f, 0.1f);
    
    private int _charLevel;
    private string _animName;

    public bool _enemyInRange = false;
    public bool _levelUp;
    public bool _isDead = false;
    #region StateMachine Variables
    public CharacterStateMachine StateMachine { get; set; }
    public IdleState IdleState { get; set; }
    public RunState RunState { get; set; }
    public AttackState AttackState { get; set; }
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        _charLevel = 1;
        _levelText.text = _charLevel.ToString();

        StateMachine = new CharacterStateMachine();

        IdleState = new IdleState(this, StateMachine);
        RunState = new RunState(this, StateMachine);
        AttackState = new AttackState(this, StateMachine);
    }
    void Start()
    {
        LeanPool.Spawn(_weaponData._weaponPrefab, _weaponSpawnPos);
        //StateMachine.Initialize(IdleState);
    }
    void Update()
    {
        GetAttackRange();
    }
    public void ChangeAnim(string _animName)
    {
        if (this._animName != _animName)
        {
            if (string.IsNullOrEmpty(_animName))
            {
                _animator.ResetTrigger(this._animName);
            }
            this._animName = _animName;
            _animator.SetTrigger(this._animName);
        }
    }
    public void GetAttackRange()
    {
        if (_attackRange != null && _charRange != null)
        {
            float radius = _charRange.radius;
            _attackRange.localScale = new Vector3(radius + 2.8f, radius +2.8f, 0.01f);
        }
    }

    // Logic when bullet hit victim
    protected virtual void OnHitVictim(CharacterManagement attacker, CharacterManagement victim)
    {
        if(victim != this)
        {
            attacker.LevelUp();
            attacker._charLevel += victim._charLevel;
            _levelText.text = attacker._charLevel.ToString();   
            victim.StartCoroutine(Dead(1f, victim));
            _listTarget.Remove(victim);
        }
    }
    public Vector3 GetEnemyDirec()
    {
        for (int i = 0; i < _listTarget.Count; i++)
        {
            _direction = _listTarget[i].transform.position - transform.position;
            if(_direction.magnitude > (_listTarget[i].transform.position - transform.position).magnitude) 
            {
                _direction = _listTarget[i].transform.position - transform.position;
            }
        }
        return _direction;
    }
    private void Throw(CharacterManagement character, Action<CharacterManagement, CharacterManagement> onHit, Transform parent)
    {
        BulletBase _bullet = SimplePool.Spawn<BulletBase>(BulletType.Z, parent.position, Quaternion.identity);
        _bullet.SetUp(GetEnemyDirec());
        _bullet.transform.parent = null;
        _bullet.OnInit(character, onHit);
    }
    public void Shoot()
    {
        ChangeAnim(Constant.Anim.ANIM_ATTACK);
        transform.rotation = Quaternion.LookRotation(GetEnemyDirec());
        Throw(this, OnHitVictim, _weaponSpawnPos);
    }
    private void LevelUp()
    {
        _levelUp = true;
        if (_charLevel > 0)
        {
            _currentSkin.localScale += _levelScale;
        }
    }
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag(Constant.Tag.TAG_CHARACTER))
        {
            _enemyInRange = true;
            if (_char == null)
            {
                _char = Cache.GetCharacter(_other);
            }
            _listTarget.Add(Cache.GetCharacter(_other));
        }
    }
    private void OnTriggerExit(Collider _other)
    {
        if (_other.CompareTag(Constant.Tag.TAG_CHARACTER))
        {
            _enemyInRange = false;
            _char = Cache.GetCharacter(_other);
            _listTarget.Remove(_char);
        }
    }
    public IEnumerator Dead(float _delay, CharacterManagement deadTarget)
    {
        _isDead = true;
        _listTarget.Remove(deadTarget);
        deadTarget._animator.SetTrigger(Constant.Anim.ANIM_DEAD);
        yield return new WaitForSeconds(_delay);
        deadTarget.gameObject.SetActive(false);
    }
}
