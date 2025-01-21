using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Entities;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class FlashLight : MonoBehaviour
{
    [SerializeField] private LivingEntity entity;
    private Light flashlight;

    void Start()
    {
        flashlight = GetComponent<Light>();

        entity.PersonalCCC.Get(Characteristics.AreaOfLight).OnCharacteristicChanged += SetAreaSize;

        SetAreaSize(entity.PersonalCCC.Get(Characteristics.AreaOfLight).CurrentValue);
    }

    private void SetAreaSize(float value)
    {
        float areaSize = value;
        flashlight.innerSpotAngle = areaSize / 2;
        flashlight.spotAngle = areaSize;
    }
}
