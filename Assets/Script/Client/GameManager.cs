using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	public GameObject canvasAnalise;
	public GameObject menu;
	public GameObject gameOverMenu;
	bool pause;
	bool gameOver;
	public int confirms;
    public int wrongs;
	public int artifices;
	int streak;
	public int maxStreak;
	public int maxError;
	public float timer;
	public event Action<int> OnConfirm;
	public event Action<int> OnWrong;
	public event Action<int> OnArtifice;
	public Text points;

	private void Start()
	{
		pause = false;
		canvasAnalise.SetActive(true);
		menu.SetActive(false);
		gameOver = false;
		gameOverMenu.SetActive(false);
		Time.timeScale = 1;
	}
	private void Update()
	{
		if (!pause && !gameOver) 
		{ 
			timer += Time.deltaTime;
		}
		if (Input.GetButtonDown("Cancel") || Input.GetButtonDown("Pause")) 
		{ 
			Pause();
		}
		
	}
	public void UpdateArtifices(int i)
	{
		artifices += i;
		OnArtifice.Invoke(artifices);
	}
	public void UpdateConfirms(int i,int streakAdd)
	{
		confirms += i;
		streak += streakAdd;
		if (streak >= maxStreak) 
		{
			streak = 0;
			UpdateArtifices(1);
		}
		if (confirms%5 == 0) 
		{
			UpdateWrongs(-1,false);
		}
		OnConfirm.Invoke(confirms);
	}
	public void UpdateWrongs(int i,bool finishStreak)
	{
		wrongs += i;
		if (finishStreak) 
		{ 
			streak = 0;
		}
		if (wrongs >= maxError) 
		{
			GameOver();
		}
		OnWrong.Invoke(wrongs);
	}
	public void GameOver() 
	{
		Time.timeScale = 0f;
		gameOver = true;
		canvasAnalise.SetActive(false);
		gameOverMenu.SetActive(true);
		points.text = "Pontos: " + ((int)((confirms * 100) / timer)).ToString();
	}
	public void Pause() 
	{
		if (!pause && !gameOver) 
		{
				pause = true;
				canvasAnalise.SetActive(false);
				menu.SetActive(true);
				Time.timeScale = 0f;
		}
		else if (pause && !gameOver)
		{
			pause = false;
			canvasAnalise.SetActive(true);
			menu.SetActive(false);
			Time.timeScale = 1;
		}

	}



}
