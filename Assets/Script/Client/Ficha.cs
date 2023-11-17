using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ficha : MonoBehaviour
{
    public ClientStats client;
    [SerializeField] Text[] camp = new Text[11];

    void Start()
    {
        client = ClientStats.CreatClientStats(Random.Range(0,ClientStatsConst.DISEASENAMES.Length));
        Show();
    }
    public void Show() 
    {
        camp[0].text = client.name;
        camp[1].text = client.age.ToString();
        camp[2].text = client.gender;
        camp[3].text = client.xHormom.ToString("f2");
        camp[4].text = client.yLipidio.ToString("f2");
        camp[5].text = client.zMolecula.ToString("f2");
        camp[6].text = client.cardiacFrequency.ToString("f2");
        camp[7].text = client.corporalGases.ToString("f2");
        camp[8].text = client.press.ToString("f2");
        camp[9].text = client.glicose.ToString("f2");

        string sintomasText = "";
		foreach (string sintoma in client.symptoms) 
        {
            sintomasText += sintoma + ", ";
        }
        camp[10].text = sintomasText;

    }
}
