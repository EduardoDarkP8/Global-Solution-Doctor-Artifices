using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int corfims;
    public int wrongs;
	public event Action<int> OnConfirm;
	public event Action<int> OnWrong;

	public void UpdateConfirms(int i)
	{
		corfims += i;
		OnConfirm.Invoke(corfims);
	}
	public void UpdateWrongs(int i)
	{
		wrongs += i;
		OnWrong.Invoke(wrongs);
	}
}
