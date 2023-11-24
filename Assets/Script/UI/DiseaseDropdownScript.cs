using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class DiseaseDropdownScript : MonoBehaviour
{

    
    [SerializeField] Color concidente;
    [SerializeField] Color normal;
    public bool checkCoicidents;
    [SerializeField] Dropdown dpd;
    [SerializeField] Text[] text;
    public Text[] ficha;
    void Start()
    {
        dpd.AddOptions(ClientStatsConst.DISEASENAMES.ToList<string>());
        onChange();
    }
    public string GetItemText() 
    {
        return dpd.captionText.text;
    }
    public void onChange() 
    {
        SetValues();
		if (checkCoicidents) 
        {
            CompareCoicidents();
        }
    }
    void SetValues() 
    {
        int i = dpd.value;
        text[0].text = ClientStatsConst.DISEASENAMES[i];
        text[1].text = MinMaxStat(ClientStatsConst.XHORMONIO[i].min.ToString(),
                                  ClientStatsConst.XHORMONIO[i].max.ToString());
        text[2].text = MinMaxStat(ClientStatsConst.YLIPIDIO[i].min.ToString(),
                                  ClientStatsConst.YLIPIDIO[i].max.ToString());
        text[3].text = MinMaxStat(ClientStatsConst.ZMOLEC[i].min.ToString(),
                                  ClientStatsConst.ZMOLEC[i].max.ToString());
        text[4].text = MinMaxStat(ClientStatsConst.CARDIACFRENQUENCY[i].min.ToString(),
                                  ClientStatsConst.CARDIACFRENQUENCY[i].max.ToString());
        text[5].text = MinMaxStat(ClientStatsConst.GASES[i].min.ToString(),
                                  ClientStatsConst.GASES[i].max.ToString());
        text[6].text = MinMaxStat(ClientStatsConst.PRESS[i].min.ToString(),
                                  ClientStatsConst.PRESS[i].max.ToString());
        text[7].text = MinMaxStat(ClientStatsConst.GLICOSE[i].min.ToString(),
                                  ClientStatsConst.GLICOSE[i].max.ToString());
        text[8].text = ClientStatsConst.DISEASESSYMPTOMS[i].sin1 + " " + ClientStatsConst.DISEASESSYMPTOMS[i].sin2 + " " + ClientStatsConst.DISEASESSYMPTOMS[i].sin3 + " ";
    }
    void CompareCoicidents() 
    {
        int i = dpd.value;
        if (MinMaxConvert(ficha[3],ClientStatsConst.XHORMONIO[i].min,ClientStatsConst.XHORMONIO[i].max))
		{
            ficha[3].color = concidente;
            text[1].color = concidente;
		}
		else 
        {
           ficha[3].color = normal;
           text[1].color = normal;
        }
        if (MinMaxConvert(ficha[4], ClientStatsConst.YLIPIDIO[i].min, ClientStatsConst.YLIPIDIO[i].max))
        {
            ficha[4].color = concidente;
            text[2].color = concidente;
        }
        else
        {
            ficha[4].color = normal;
            text[2].color = normal;
        }
        if (MinMaxConvert(ficha[5], ClientStatsConst.ZMOLEC[i].min, ClientStatsConst.ZMOLEC[i].max))
        {
            ficha[5].color = concidente;
            text[3].color = concidente;
        }
        else
        {
            ficha[5].color = normal;
            text[3].color = normal;
        }
        if (MinMaxConvert(ficha[6], ClientStatsConst.CARDIACFRENQUENCY[i].min, ClientStatsConst.CARDIACFRENQUENCY[i].max))
        {
            ficha[6].color = concidente;
            text[4].color = concidente;
        }
        else
        {
            ficha[6].color = normal;
            text[4].color = normal;
        }
        if (MinMaxConvert(ficha[7], ClientStatsConst.GASES[i].min, ClientStatsConst.GASES[i].max))
        {
            ficha[7].color = concidente;
            text[5].color = concidente;
        }
        else
        {
            ficha[7].color = normal;
            text[5].color = normal;
        }
        if (MinMaxConvert(ficha[8], ClientStatsConst.PRESS[i].min, ClientStatsConst.PRESS[i].max))
        {
            ficha[8].color = concidente;
            text[6].color = concidente;
        }
        else
        {
            ficha[8].color = normal;
            text[6].color = normal;
        }
        if (MinMaxConvert(ficha[9], ClientStatsConst.GLICOSE[i].min, ClientStatsConst.GLICOSE[i].max))
        {
            ficha[9].color = concidente;
            text[7].color = concidente;
        }
        else
        {
            ficha[9].color = normal;
            text[7].color = normal;
        }
		if (ficha[10].text == text[8].text) 
        {
            ficha[10].color = concidente;
            text[8].color = concidente;
        }
        else
        {
            ficha[10].color = normal;
            text[8].color = normal;
        }
    }
    string MinMaxStat(string min,string max) 
    {
        return "Entre " + min + " e " + max;
    }

    bool MinMaxConvert(Text value,float min, float max) 
    {
		if (float.TryParse(value.text, out float result) && value.enabled == true) 
        { 
            return (result >= min && result <= max);
        }
		else 
        {
            return false;
        }
    }
}
