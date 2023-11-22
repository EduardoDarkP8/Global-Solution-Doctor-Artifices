using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class DiseaseDropdownScript : MonoBehaviour
{
    [SerializeField] Dropdown dpd;
    [SerializeField] Text[] text;
    void Start()
    {
        dpd.AddOptions(ClientStatsConst.DISEASENAMES.ToList<string>());
        
    }
    public string GetItemText() 
    {
        return dpd.captionText.text;
    }
    public void onChange() 
    {
        int i = dpd.value;
        text[0].text = ClientStatsConst.DISEASENAMES[i];
        text[1].text = MinMaxStat(ClientStatsConst.ZMOLEC[i].min.ToString(), 
                                  ClientStatsConst.ZMOLEC[i].max.ToString());
        text[2].text = MinMaxStat(ClientStatsConst.XHORMONIO[i].min.ToString(),
                                  ClientStatsConst.XHORMONIO[i].max.ToString());
        text[3].text = MinMaxStat(ClientStatsConst.YLIPIDIO[i].min.ToString(),
                                  ClientStatsConst.YLIPIDIO[i].max.ToString());
        text[4].text = MinMaxStat(ClientStatsConst.CARDIACFRENQUENCY[i].min.ToString(),
                                  ClientStatsConst.CARDIACFRENQUENCY[i].max.ToString());
        text[5].text = MinMaxStat(ClientStatsConst.GASES[i].min.ToString(),
                                  ClientStatsConst.GASES[i].max.ToString());
        text[6].text = MinMaxStat(ClientStatsConst.PRESS[i].min.ToString(),
                                  ClientStatsConst.PRESS[i].max.ToString());
        text[7].text = MinMaxStat(ClientStatsConst.GLICOSE[i].min.ToString(),
                                  ClientStatsConst.GLICOSE[i].max.ToString());
       
        text[8].text = ClientStatsConst.DISEASESSYMPTOMS[i].sin1 + " " + ClientStatsConst.DISEASESSYMPTOMS[i].sin2 + " " + ClientStatsConst.DISEASESSYMPTOMS[i].sin3;
    }
    string MinMaxStat(string min,string max) 
    {
        return "Entre " + min + " e " + max;
    }
}
