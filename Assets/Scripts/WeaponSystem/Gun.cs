using MyTimer;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Bullet _bullet;

    [SerializeField] float _force;
    [SerializeField] float _rateFire;
    [SerializeField] int _maxAmmo;
    [SerializeField] int _amountAmmo;
    [SerializeField] float _reloadTime;

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
            bulletClon.transform.position = transform.position + transform.forward * 0.5f;
            bulletClon.Fire((position - bulletClon.transform.position) * _force);

            if(--_amountAmmo > 0)
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
