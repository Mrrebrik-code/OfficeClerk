using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class TutorialManager : SingletonMono<TutorialManager>
{
	public bool IsTutorialRun = false;
	public Tutorials CurrentTutorial;
	[SerializeField] private List<HandTutorial> _handsInit = new List<HandTutorial>();
	private Dictionary<TypeHandTutorial, HandTutorial> _hands = new Dictionary<TypeHandTutorial, HandTutorial>();

	public override void Awake()
	{
		base.Awake();
		_handsInit.ForEach(hand =>
		{
			_hands.Add(hand.Type, hand);
		});
		
	}

	public void Start()
	{
		StartCoroutine(TutorialBurgerBuy());
	}
	public void AddHand(HandTutorial hand)
	{
		_hands.Add(hand.Type, hand);
	}

	private IEnumerator TutorialBurgerBuy()
	{
		IsTutorialRun = true;

		var handTable = _hands[TypeHandTutorial.Table];
		handTable.gameObject.SetActive(true);

		var handCategoryEat = _hands[TypeHandTutorial.EatCategory];
		var handProductBurger = _hands[TypeHandTutorial.ProductBurger];
		var handShopButton = _hands[TypeHandTutorial.ButtonShop];
		var handButtonCloseTableMenu = _hands[TypeHandTutorial.ButtonCloseTableMenu];


		while (handTable.IsDone == false)
		{
			yield return null;
		}

		handShopButton.gameObject.SetActive(true);
		while (handShopButton.IsDone == false)
		{
			yield return null;
		}

		handCategoryEat.gameObject.SetActive(true);
		while (handCategoryEat.IsDone == false)
		{
			yield return null;
		}

		handProductBurger.gameObject.SetActive(true);
		while (handProductBurger.IsDone == false)
		{
			yield return null;
		}

		handButtonCloseTableMenu.gameObject.SetActive(true);
		while (handButtonCloseTableMenu.IsDone == false)
		{
			yield return null;
		}

		IsTutorialRun = false;
	}
}
