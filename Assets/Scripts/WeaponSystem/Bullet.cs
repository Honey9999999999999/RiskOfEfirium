using Assets.Scripts.Entities;
using MyTimer;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    private Timer _lifeTimer;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out LivingEntity entity))
        {
            entity.TakenDamage(damage);
            DestroyBullet();
        }
    }

    public void Fire(Vector3 vectorForce)
    {
        GetRigidBody().AddForce(vectorForce, ForceMode.Impulse);
        StartDestroyTimer();
    }

    public Rigidbody GetRigidBody() => GetComponent<Rigidbody>();

    private void StartDestroyTimer()
    {
        _lifeTimer = new();
        _lifeTimer.OnStoped += DestroyBullet;
        _lifeTimer.Start(2);
    }

    private void DestroyBullet()
    {
        _lifeTimer.OnStoped -= DestroyBullet;
        Destroy(gameObject);
    }
}
