using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButton : MonoBehaviour
{
    [SerializeField] DiseaseDropdownScript diseaseDropdownScript;
    public Client client;
    public void Confirm() 
    {
        if (diseaseDropdownScript.GetItemText() == client.stats.diseaseName) 
        {
            Debug.Log("Certo");
        }
    }
}
