using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Controllers.EntityControllers
{
    [RequireComponent(typeof(NavMeshAgent), typeof(SphereCollider))]
    public class EnemyController : EntityController
    {
        private NavMeshAgent agent;

        public override Vector2 CameraControlInput => throw new NotImplementedException();

        public override Vector2 moveInput => GetDirection();

        private bool _isWalk;
        public override bool isWalk => _isWalk;

        public override event Action OnCameraInput;


        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent<Player>(out _))
            {
                _isWalk = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out _))
            {
                _isWalk = false;
            }
        }

        private Vector2 GetDirection()
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();

            return Vector2.zero;
        }
    }
}
