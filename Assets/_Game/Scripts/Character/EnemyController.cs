using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : CharacterManagement
{
    public enum State
    {
        _Move,
        _Attack,
    }
    //keo navmesh agent vao
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] protected Transform _tf;

    private State _enemyState;
    private float _nextShootTime;
    //luu diem muc tieu se di den
    private Vector3 _destination;
    private Vector3 _randomPoint;
    //property tra ve ket qua xem la da toi diem muc tieu hay chua
    public bool _IsDestination => Vector3.Distance(_tf.position, _destination + (_tf.position.y - _destination.y) * Vector3.up) < 0.1f;
    public float _range = 5f;
    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
    private void Start()
    {
        GetRandomPoint();
    }
    private void Update()
    {
        Check();
    }
    private void EnemyMove()
    {
        if (!_IsDestination)
        {
            _enemyState = State._Move;
            ChangeState();
        }
    }
    //set diem den
    private void SetDestination(Vector3 destination)
    {
        this._destination = destination;
        _agent.SetDestination(destination);
    }
    public void ChangeState()
    {
        switch (_enemyState)
        {
            default:
            case State._Move:
                break;
            case State._Attack:
                if (_enemyInRange)
                {
                    if(Time.time > _nextShootTime)
                    {
                        Shoot();
                        float fireRate = 2f;
                        _nextShootTime = Time.time + fireRate;
                    }
                }
                break;
        }
    }
    private void GetRandomPoint()
    {
        Vector3 point;
        if (RandomPoint(transform.position, _range, out point))
        {
            _randomPoint = point;
            SetDestination(_randomPoint);
            ChangeAnim(Constant.Anim.ANIM_RUN);
        }
    }
    private void Check()
    {
        if (_enemyInRange && _listTarget.Count > 0)
        {
            ChangeAnim(Constant.Anim.ANIM_IDLE);
            _enemyState = State._Attack;
            ChangeState();
        } else if (_IsDestination)
        { 
            GetRandomPoint();
            EnemyMove();
        }
    }
}
