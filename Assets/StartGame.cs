using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] Scrollbar errorsScroll;
    [SerializeField] Scrollbar artificesScroll;

	public void StartGameButtom() 
	{
		PlayerPrefs.SetInt("ErrorLimit", (int)(errorsScroll.value * 10));
		PlayerPrefs.SetInt("artificeStreak", (int)(artificesScroll.value * 10));
	}
}
