using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text confirmsText;
    [SerializeField] Text wrongsText;
	[SerializeField] GameManager gameManager;
    void Start()
    {
		gameManager.OnConfirm += Instance_OnConfirm;
		gameManager.OnWrong += Instance_OnWrong;
    }

	private void Instance_OnWrong(int i)
	{
		wrongsText.text = "Erros: " + i.ToString();
	}

	private void Instance_OnConfirm(int i)
	{
		confirmsText.text = "Acertos: " + i.ToString();
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
