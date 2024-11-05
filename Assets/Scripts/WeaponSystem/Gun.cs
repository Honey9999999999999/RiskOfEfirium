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

    [SerializeField, Min(0)] private float _force;
    [SerializeField, Min(0)] private float _rateFire;
    [SerializeField, Min(0)] private int _maxAmmo;
    [SerializeField, Min(0)] private int _amountAmmo;
    [SerializeField, Min(0)] private float _reloadTime;
    [SerializeField] float _distanceInstanceBulletAtCentre;

    private Dictionary<Side, Type> _sidesMap = new()
    {
        [Side.Friendly] = typeof(Player),
        [Side.Enemy] = typeof(Enemy)
    };

    private Timer _cooldownTimer;
    private float _cooldown => _rateFire / 60;

    public int MaxAmmo => _maxAmmo;

    public float StockRateFire { get; private set; }
    public int StockMaxAmmo { get; private set; }
    public float StockReloadTime { get; private set; }

    private void Awake()
    {
        _cooldownTimer = new();
        _amountAmmo = _maxAmmo;
    }

    public void OnEnable()
    {
        StockRateFire = _rateFire;
        StockMaxAmmo = _maxAmmo;
        StockReloadTime = _reloadTime;
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

    public void SetAmmoCount(int value)
    {
        if(value > 0)
        {
            _maxAmmo = value;
        }
    }
    public void SetRateFire(float value)
    {
        if (value > 0)
        {
            _rateFire = value;
        }
    }
}
