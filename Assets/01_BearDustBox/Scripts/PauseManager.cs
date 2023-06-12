using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
	//[SerializeField]
	////　ポーズした時に表示するUIのプレハブ
	//private GameObject pauseUIPrefab;
	//　ポーズUIのインスタンス
	[SerializeField]
	private GameObject pauseUIInstance;

	private bool activeFlag = false;

	public void pause()
    {
		if (!activeFlag)
		{
			//pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
			pauseUIInstance.SetActive(true);
			activeFlag = true;
			Time.timeScale = 0f;
		}
		else
		{
			//Destroy(pauseUIInstance);
			pauseUIInstance.SetActive(false);
			activeFlag = false;
			Time.timeScale = 1f;
		}
    }
}
