using Player;
using UnityEngine;

namespace Interactive
{
	[RequireComponent(typeof(Outline))]
	public class ObjectInteractive : MonoBehaviour
	{
		[SerializeField] private HandTutorial _hand;
		private float _distanceInteractive = 3f;
		private Outline _outline;
		private IThings _thing;

		private void Start()
		{
			_outline = GetComponent<Outline>();
			_outline.enabled = false;
			_thing = GetComponent<IThings>();
		}

		public void OnMouseEnter()
		{
			_outline.enabled = true;
			PlayerController.Instance.IsHitMove = false;
		}

		public void OnMouseExit()
		{
			_outline.enabled = false;
			PlayerController.Instance.IsHitMove = true;
		}

		public void OnMouseDown()
		{
			float distance = Vector3.Distance(transform.position, PlayerController.Instance.transform.position);
			if (distance < _distanceInteractive)
			{
				if(_hand != null) _hand.Complet();
				
				Debug.Log("Вы нажали на объект: " + gameObject.name);
				PlayerController.Instance.IsHitMove = true;
				_thing.Execute();
			}
			else
			{
				Debug.Log("Вы находитесь слишком далеко от объекта!");
			}

		}
	}
}
