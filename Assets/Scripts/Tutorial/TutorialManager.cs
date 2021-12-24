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
		handCategoryEat.gameObject.SetActive(true);

		var handProductBurger = _hands[TypeHandTutorial.ProductBurger];
		handProductBurger.gameObject.SetActive(true);

		var handShopButton = _hands[TypeHandTutorial.ButtonShop];
		handShopButton.gameObject.SetActive(true);

		while (handTable.IsDone == false)
		{
			yield return null;
		}
		while (handShopButton.IsDone == false)
		{
			yield return null;
		}
		while(handCategoryEat.IsDone == false)
		{
			yield return null;
		}
		while(handProductBurger.IsDone == false)
		{
			yield return null;
		}

		IsTutorialRun = false;
	}
}
