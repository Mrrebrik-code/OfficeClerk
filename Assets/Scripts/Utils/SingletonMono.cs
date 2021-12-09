using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance;
		public bool IsDontDestroyOnLoad { get; set; } = false;
		public bool IsInitialized { get { return _instance; } }
		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					MonoBehaviour[] instances = FindObjectsOfType<T>();

					if (instances.Length > 0)
					{
						return (T)instances[0];
					}

					if (instances.Length > 1)
					{
						Debug.LogError("[Singleton] Singleton classes count more one!");
						return _instance;
					}

					if (_instance == null)
					{
						Debug.LogError("[Singleton] Not found singleton class to object in Scene!");
						return default;
					}
				}
				return _instance;
			}
			set
			{
				if (_instance == null) _instance = value;
			}
		}

		public virtual void Awake()
		{
			if (_instance == null)
			{
				_instance = this as T;
				if (IsDontDestroyOnLoad) DontDestroyOnLoad(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}

