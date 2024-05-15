using Assets.Scripts.Controllers.EntityControllers;
using System;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    [Serializable]
    public abstract class LivingEntity : MonoBehaviour
    {
        [SerializeField] private EntityController _entityController;

        public EntityController GetEntityController()
        {
            return _entityController;
        }
    }
}
