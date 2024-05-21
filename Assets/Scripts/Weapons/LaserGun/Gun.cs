using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Bullet _bullet;
    [SerializeField] float _force;

    public void Fire(Vector3 position)
    {
        Bullet bulletClon = Instantiate(_bullet);
        bulletClon.transform.position = transform.position + transform.forward * 0.5f;
        bulletClon.Fire((position - bulletClon.transform.position) * _force);
    }
}
