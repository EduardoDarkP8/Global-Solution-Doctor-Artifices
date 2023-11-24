using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIButtonScript : MonoBehaviour
{

	[SerializeField] DiseaseDropdownScript diseaseDropdownScript;
	public GameManager gameManager;
	public Button btnAI;

	private void Start()
	{
		if (gameManager.artifices > 0)
		{
			btnAI.interactable = true;
		}
		else
		{
			btnAI.interactable = false;
		}
	}
	public void ChangeColor() 
	{
		diseaseDropdownScript.checkCoicidents = true;
		diseaseDropdownScript.onChange();
		gameManager.UpdateArtifices(-2);	
	}

}
