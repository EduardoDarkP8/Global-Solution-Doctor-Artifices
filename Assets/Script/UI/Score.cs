using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	[SerializeField] AudioSource audioSource;
	[SerializeField] AudioClip[] audios;
	[SerializeField] Text timer;
    [SerializeField] Text confirmsText;
    [SerializeField] Text wrongsText;
	[SerializeField] Text artificiosText;
	[SerializeField] GameManager gameManager;
	
    void Start()
    {
		gameManager.OnConfirm += Instance_OnConfirm;
		gameManager.OnWrong += Instance_OnWrong;
		gameManager.OnArtifice += GameManager_OnArtifice;
    }

	private void GameManager_OnArtifice(int i)
	{
		artificiosText.text = "Artificios: " + i.ToString();
		audioSource.clip = audios[0];
		audioSource.Play();
	}

	private void Instance_OnWrong(int i)
	{
		wrongsText.text = "Erros: " + i.ToString();
		audioSource.clip = audios[1];
		audioSource.Play();
	}

	private void Instance_OnConfirm(int i)
	{
		confirmsText.text = "Acertos: " + i.ToString();
		audioSource.clip = audios[2];
		audioSource.Play();
	}

	// Update is called once per frame
	void Update()
    {
		int seconds = (int)gameManager.timer%60;
		int min = (int)gameManager.timer/60;
		timer.text = string.Format("{0:00}:{1:00}",min, seconds);
			  
    }
}
