using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject canvasAnalise;
	public GameObject menu;
	public GameObject gameOverMenu;
	bool pause;
	public int corfims;
    public int wrongs;
	public int artifices;
	int streak;
	public int maxStreak;
	public int maxError;
	public float timer;
	public event Action<int> OnConfirm;
	public event Action<int> OnWrong;
	public event Action<int> OnArtifice;
	
	private void Update()
	{
		if (!pause) 
		{ 
			timer += Time.deltaTime;
		}
	}
	public void UpdateArtifices(int i)
	{
		artifices += i;
		OnArtifice.Invoke(artifices);
	}
	public void UpdateConfirms(int i,int streakAdd)
	{
		corfims += i;
		streak += streakAdd;
		if (streak >= maxStreak) 
		{
			streak = 0;
			UpdateArtifices(1);
		}
		if (corfims%5 == 0) 
		{
			UpdateWrongs(-1,false);
		}
		OnConfirm.Invoke(corfims);
	}
	public void UpdateWrongs(int i,bool finishStreak)
	{
		wrongs += i;
		if (finishStreak) 
		{ 
			streak = 0;
		}
		OnWrong.Invoke(wrongs);
	}
	public void GameOver() 
	{
		pause = true;
		canvasAnalise.SetActive(false);
		gameOverMenu.SetActive(true);
	}
	public void Pause() 
	{
		pause = true;
		canvasAnalise.SetActive(false);
		menu.SetActive(true);
	}
	public void UnPause() 
	{
		pause = false;
		canvasAnalise.SetActive(true);
		menu.SetActive(false);
	}
}
