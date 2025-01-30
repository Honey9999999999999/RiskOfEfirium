using System;
using Assets.Resources.ArmorSystem.Scripts;
using Assets.Scripts.Entities;
using MyTimer;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private TypeDamage _type;
    [SerializeField] private float _lifeTime = 2;
    private Timer _lifeTimer;

    private Type target;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (!other.isTrigger && other.TryGetComponent(out LivingEntity entity))
    //    {
    //        if (entity.GetType().Equals(target))
    //        {
    //            entity.TakenDamage(_type, _damage);
    //        }
    //        DestroyBullet();
    //    }
    //}

    public void Fire(Type type, Vector3 vectorForce)
    {
        target = type;
        GetRigidBody().AddForce(vectorForce, ForceMode.Impulse);
        StartDestroyTimer();
    }

    public void SetDamage(float damage) => _damage = damage;

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
