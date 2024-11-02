using Assets.Scripts.Entities;
using UnityEngine;

public class EntityEffector : MonoBehaviour
{
    [SerializeField] private LivingEntity _entity;
    [SerializeField] private ParticleSystem _takenDamageEffect;

    private void Start()
    {
        _entity.OnTakenDamage += _takenDamageEffect.Play;
    }
}
