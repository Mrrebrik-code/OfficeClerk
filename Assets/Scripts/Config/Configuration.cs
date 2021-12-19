using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "SO/Config")]
public class Configuration : ScriptableObject
{
	[Header("Игровая валюта:")]
	public int CountCookiesStart;
	public int CountDiamondStart;

	[Header("Баланс игры:"), Space]
	[Tooltip("[ЖАЖДА] Значение, которое отнимается у рабочих, когда они работают")]
	public int ThirstValue;
	[Tooltip("[ГОЛОД] Значение, которое отнимается у рабочих, когда они работают")]
	public int HungryValue;
	[Tooltip("[УСТАЛОСТЬ] Значение, которое отнимается у рабочих, когда они работают")]
	public int DreamValue;

}
