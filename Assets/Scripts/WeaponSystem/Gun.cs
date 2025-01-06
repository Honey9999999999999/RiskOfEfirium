using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Entities;
using MyTimer;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class Gun : MonoBehaviour
    {
        public enum Side
        {
            Friendly,
            Enemy
        }

        [SerializeField] private LivingEntity _entity;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Side _target;

        [SerializeField, Min(0)] private float _force;
        [SerializeField] float _offsetSpawnBulletAtCentre;

        public CharacterCharacteristicCard personalCCC;
        private int _amountAmmo;

        private Dictionary<Side, Type> _sidesMap = new()
        {
            [Side.Friendly] = typeof(Player),
            [Side.Enemy] = typeof(Enemy)
        };

        private Timer _cooldownTimer;
        private float _cooldown => 60 / personalCCC.GetValueOf(Characteristics.RateFirePerMin);

        private void Awake()
        {
            personalCCC = _entity.PersonalCCC;

            _cooldownTimer = new();
            _amountAmmo = (int)personalCCC.GetValueOf(Characteristics.MaxAmmo);
        }

        public void Fire(Vector3 position)
        {
            if (!_cooldownTimer.isStarted)
            {
                Bullet bulletClon = Instantiate(_bullet);
                bulletClon.transform.position = transform.position;
                Vector3 direction = (position - bulletClon.transform.position).normalized;
                bulletClon.transform.position = transform.position + direction * _offsetSpawnBulletAtCentre;
                bulletClon.SetDamage(personalCCC.Get(Characteristics.Damage).CurrentValue);

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
            _cooldownTimer.Start(personalCCC.GetValueOf(Characteristics.ReloadTime));
        }
        private void ReloadDone()
        {
            _cooldownTimer.OnStoped -= ReloadDone;
            _amountAmmo = (int)personalCCC.GetValueOf(Characteristics.MaxAmmo);
        }
    }
}
