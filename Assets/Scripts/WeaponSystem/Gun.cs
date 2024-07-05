using Assets.Scripts.Entities;
using MyTimer;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum Side
    {
        Friendly,
        Enemy
    }

    [SerializeField] Bullet _bullet;
    [SerializeField] Side _target;

    [SerializeField] float _force;
    [SerializeField] float _rateFire;
    [SerializeField] int _maxAmmo;
    [SerializeField] int _amountAmmo;
    [SerializeField] float _reloadTime;

    [SerializeField] float _distanceInstanceBulletAtCentre;

    private Dictionary<Side, Type> _sidesMap = new()
    {
        [Side.Friendly] = typeof(Player),
        [Side.Enemy] = typeof(Enemy)
    };

    private Timer _cooldownTimer;
    private float _cooldown => _rateFire / 60;

    private void Awake()
    {
        _cooldownTimer = new();
        _amountAmmo = _maxAmmo;
    }

    public void Fire(Vector3 position)
    {
        if (!_cooldownTimer.isStarted)
        {
            Bullet bulletClon = Instantiate(_bullet);
            bulletClon.transform.position = transform.position;
            Vector3 direction = (position - bulletClon.transform.position).normalized;
            bulletClon.transform.position = transform.position + direction * _distanceInstanceBulletAtCentre;

            bulletClon.Fire(_sidesMap[_target], direction * _force);

            if (--_amountAmmo > 0)
            {
                _cooldownTimer.Start(_cooldown);
            }
            else
            {
                Reload();
            }
        }
    }

    public void Reload()
    {
        _cooldownTimer.OnStoped += ReloadDone;
        _cooldownTimer.Start(_reloadTime);
    }
    private void ReloadDone()
    {
        _cooldownTimer.OnStoped -= ReloadDone;
        _amountAmmo = _maxAmmo;
    }
}
