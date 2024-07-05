using Assets.Scripts.Entities;
using MyTimer;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _lifeTime = 2;
    private Timer _lifeTimer;

    private Type target; 

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && other.TryGetComponent(out LivingEntity entity))
        {
            if (entity.GetType().Equals(target))
            {
                entity.TakenDamage(_damage);
            }            
            DestroyBullet();
        }
    }

    public void Fire(Type type, Vector3 vectorForce)
    {
        target = type;
        GetRigidBody().AddForce(vectorForce, ForceMode.Impulse);
        StartDestroyTimer();
    }

    public Rigidbody GetRigidBody() => GetComponent<Rigidbody>();

    private void StartDestroyTimer()
    {
        _lifeTimer = new();
        _lifeTimer.OnStoped += DestroyBullet;
        _lifeTimer.Start(_lifeTime);
    }

    private void DestroyBullet()
    {
        _lifeTimer.OnStoped -= DestroyBullet;
        Destroy(gameObject);
    }
}
