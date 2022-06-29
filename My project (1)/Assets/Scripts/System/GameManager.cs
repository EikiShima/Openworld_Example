using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveSceneManager))]
[RequireComponent(typeof(SaveManager))]
[RequireComponent(typeof(SoundManager))]
[DefaultExecutionOrder(-5)]
public class GameManager : SingletonMonoBehaviour<GameManager>
{

	[Header("シーンロード時に自動生成するプレハブを登録")]
	[SerializeField]
	GameObject[] prefabs = null;
	[Header("BGM設定")]
	[SerializeField]
	AudioClip bgm = null;

	MoveSceneManager moveSceneManager;
	SaveManager saveManager;
	SoundManager soundManager;

	protected override void Awake()
	{
		base.Awake();

		if (Debug.isDebugBuild)
		{
			
		}

		moveSceneManager = GetComponent<MoveSceneManager>();
		saveManager = GetComponent<SaveManager>();
		soundManager = GetComponent<SoundManager>();
	}

	void Start()
	{
		if (Debug.isDebugBuild)
		{
			InstantiateWhenLoadScene();
		}

		if (bgm != null)
        {
			soundManager.PlayBgmByName(bgm.name);
        }
	}

	void Update()
	{
        if (Input.GetButtonDown("Cancel"))
        {
			Application.Quit();
        }
	}

	public void InstantiateWhenLoadScene()
	{
		if(moveSceneManager.SceneName == "Title")
		{
			return;
		}

		foreach (GameObject prefab in prefabs)
		{
			Instantiate(prefab, transform.position, Quaternion.identity);
		}
	}

}


