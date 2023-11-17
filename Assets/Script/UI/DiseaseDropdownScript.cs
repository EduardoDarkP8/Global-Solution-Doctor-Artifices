using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DiseaseDropdownScript : MonoBehaviour
{
    [SerializeField] Dropdown dpd;
    void Start()
    {
        dpd.AddOptions(ClientStatsConst.DISEASENAMES.ToList<string>());
        
    }
    public string GetItemText() 
    {
        return dpd.captionText.text;
    }
    

}
