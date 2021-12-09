using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Player
{
	public class PlayerController : SingletonMono<PlayerController>
	{
		private NavMeshAgent _agent;
		private Animator _animator;
		private Rigidbody _regedbody;
		private Camera _camera;

		public bool IsHitMove = true;

		public GameObject WaterBox;

		public override void Awake()
		{
			base.Awake();
			_camera = Camera.main;
			_animator = GetComponent<Animator>();
			_agent = GetComponent<NavMeshAgent>();
			_regedbody = GetComponent<Rigidbody>();
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(1) && IsHitMove)
			{
				RaycastHit hit;
				if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit))
				{
					Move(hit.point);
				}
			}

			_animator.SetBool("Move", transform.position != _agent.destination);

		}

		public void Move(Vector3 targetPosition)
		{
			_agent.SetDestination(targetPosition);
		}
	}
}

