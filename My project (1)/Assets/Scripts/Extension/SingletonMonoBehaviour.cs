﻿using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;

	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = (T)FindObjectOfType(typeof(T));

				if (instance == null)
				{
					Debug.LogError(typeof(T) + "is nothing");
				}
			}

			return instance;
		}
	}

	protected virtual void Awake()
	{
		if (this != Instance)
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);
	}

}