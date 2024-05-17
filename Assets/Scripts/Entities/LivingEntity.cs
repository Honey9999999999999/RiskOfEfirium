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
        [SerializeField] protected MovePlayerFSMInstance _mover;        

        public T GetEntityController<T>() where T : EntityController
        {
            return (T)_entityController;
        }
        public MovePlayerFSMInstance GetMover()
        {
            return _mover;
        }
    }
}
