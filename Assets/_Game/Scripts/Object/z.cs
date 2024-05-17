using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class z : BulletBase
{
    [SerializeField] private float _timeDelay;
    [SerializeField] private float rotationSpeed;

    void Update()
    {
        StartCoroutine(DeActiveBullet(_timeDelay));
        StartCoroutine(RotateBullet());
    }

    private IEnumerator RotateBullet()
    {
        while (true)
        {
            transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
    private IEnumerator DeActiveBullet(float _time)
    {
        yield return new WaitForSeconds(_time);
        SimplePool.DeSpawn(this);
    }
}
