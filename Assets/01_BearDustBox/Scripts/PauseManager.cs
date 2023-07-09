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
	[SerializeField]
	private GameObject pausepauseUIInstance;

	private bool activeFlag = false;

	private bool activePauseFlag = false;

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

	public void pausepause()
	{
		if (!activePauseFlag)
		{
			//pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
			pausepauseUIInstance.SetActive(true);
			activePauseFlag = true;
			Time.timeScale = 0f;
		}
		else
		{
			//Destroy(pauseUIInstance);
			pausepauseUIInstance.SetActive(false);
			activePauseFlag = false;
			Time.timeScale = 1f;
		}
	}

}
