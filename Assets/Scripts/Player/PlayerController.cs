using AI;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Player
{
	public class PlayerController : SingletonMono<PlayerController>
	{
		private NavMeshAgent _agent;
		private Animator _animator;
		private Camera _camera;

		public bool IsHitMove = true;
		public GameObject WaterBox;

		private WorkmanProperties _properties;

		public override void Awake()
		{
			base.Awake();
			_properties = new WorkmanProperties(100, 100, 100);
			_camera = Camera.main;
			_animator = GetComponent<Animator>();
			_agent = GetComponent<NavMeshAgent>();
		}

		private IEnumerator PropertiesHolder()
		{
			while (true)
			{
				_properties.ThirstValue = -1;
				_properties.HungryValue = -1;
				_properties.DreamValue = -1;
				yield return null;
			}
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

