using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButton : MonoBehaviour
{
    [SerializeField] DiseaseDropdownScript diseaseDropdownScript;
    public Client client;
    public GameManager gameManager;
    public void Confirm() 
    {
        if (diseaseDropdownScript.GetItemText() == client.stats.diseaseName) 
        {
            gameManager.UpdateConfirms(1);
            client.FinishAppointment();
        }
		else 
        {
            gameManager.UpdateWrongs(1);
            client.FinishAppointment();
        }
    }
}
