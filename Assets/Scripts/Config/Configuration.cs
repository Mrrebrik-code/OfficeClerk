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

	[Header("Настройки камеры:"), Space]
	[Tooltip("Скорость перемещение камеры")]
	public float SpeedMoveCamera;
	[Tooltip("Скорость камеры, когда мы скроллом мышки подымаем или опускаем")]
	public float SpeedScrollCamera;
	[Tooltip("На какой высоте будет камера при старте игры")]
	public float StartPositionYCamera;
	[Tooltip("Максимальная высота на которую можно поднять камеру")]
	public float MaxPositionCamera;
	[Tooltip("Минимальная высота на которую можно опустить камеру")]
	public float MinPositionCamera;


}
