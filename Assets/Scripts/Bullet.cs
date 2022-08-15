using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IPoolable
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _destroyTime;

    private void Update()
    {
        //_rigidBody.AddForce(raycastShooting._rayHit * _speed * Time.fixedDeltaTime, ForceMode.Impulse);
        BulletDestroy();

    }
    private void BulletDestroy()
    {
        LeanPool.Despawn(this, _destroyTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            LeanPool.Despawn(this);
        }
        else
        {
            LeanPool.Despawn(this);
        }
    }

    public void OnSpawn()
    {
        
    }

    public void OnDespawn()
    {
        
    }
}
