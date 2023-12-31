using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exames : MonoBehaviour
{
    public Client client;
    [SerializeField] Toggle[] checkBoxes = new Toggle[7];
    [SerializeField] AudioSource soundPlay;
    public void OnExameClick() 
    {
        soundPlay.Play();
        bool[] checks = new bool[7];
        int i = 0;
        float finalTime = 0;
		foreach (bool check in checks) 
        {
            checks[i] = checkBoxes[i].isOn;
            if (checks[i]) 
            {
                finalTime += 5.5f;
            }
            i++;
        }
        client.GoToExames(checks,finalTime);
    }
}
