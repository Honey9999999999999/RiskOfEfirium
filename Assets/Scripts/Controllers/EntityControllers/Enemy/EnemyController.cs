using Assets.Scripts.Controllers.EntityControllers.Enemy;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Controllers.EntityControllers
{
    [RequireComponent(typeof(NavMeshAgent), typeof(SphereCollider))]
    public class EnemyController : EntityController
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private EnemyFSMInstance fSMInstance;

        private Vector2 _moveInput;
        private bool _isWalk;

        public override Vector3 ViewDirection => fSMInstance.GetDirectionToTarget();
        public override Vector2 moveInput => _moveInput;
        public override bool isWalk => _isWalk;


        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (fSMInstance.isTarget)
            {
                _moveInput = new Vector2(0, 1);
                _isWalk = true;
            }
            else
            {
                _moveInput = Vector2.zero;
                _isWalk = false;
            }
        }
    }
}
