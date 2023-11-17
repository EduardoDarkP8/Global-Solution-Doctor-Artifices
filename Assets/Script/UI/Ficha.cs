using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ficha : MonoBehaviour
{
    [SerializeField] Text[] camp = new Text[11];
    
    public void Show(ClientStats client, bool[] actives) 
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

        camp[3].enabled = actives[0];
        camp[4].enabled = actives[1];
        camp[5].enabled = actives[2];
        camp[6].enabled = actives[3];
        camp[7].enabled = actives[4];
        camp[8].enabled = actives[5];
        camp[9].enabled = actives[6];

        string sintomasText = "";
		foreach (string sintoma in client.symptoms) 
        {
            sintomasText += sintoma + ", ";
        }
        camp[10].text = sintomasText;

    }
}
