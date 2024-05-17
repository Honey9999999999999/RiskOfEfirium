using Assets.Scripts.Controllers.EntityControllers;
using Assets.Scripts.Movement;
using System;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    [Serializable]
    public abstract class LivingEntity: MonoBehaviour
    {
        [SerializeField] protected EntityController _entityController;
        [SerializeField] protected MoveFSMInstance _mover;        

        public EntityController GetEntityController()
        {
            return _entityController;
        }
        public MoveFSMInstance GetMover()
        {
            return _mover;
        }
    }
}
