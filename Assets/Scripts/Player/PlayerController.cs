using AI;
using System;
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

		public WorkmanProperties Properties;
		[SerializeField] private UIPropertiesInfo _infoPropertiesUI;
		public override void Awake()
		{
			base.Awake();
			Properties = new WorkmanProperties(100, 100, 100);
			Properties.OnChange += ChandePropertiesHandler;
			StartCoroutine(PropertiesHolder());
			_camera = Camera.main;
			_animator = GetComponent<Animator>();
			_agent = GetComponent<NavMeshAgent>();
		}

		private void ChandePropertiesHandler()
		{
			_infoPropertiesUI.SetProperties(Properties);
		}

		private IEnumerator PropertiesHolder()
		{
			while (true)
			{
				yield return new WaitForSeconds(8f);
				Properties.ThirstValue = -4;
				Properties.HungryValue = -5;
				Properties.DreamValue = -3;
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

