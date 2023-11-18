using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public bool isWainting;
    public ClientStats stats;
    public ClientListner listner;
    public GameObject fichaTempalte;
    GameObject fichaInstance;
    private bool[] activeCamps = new bool[7];
    void Start()
    {
        if (stats == null) 
        {
            stats = ClientStats.CreateRandomClientStats();
            int n = 0;
            foreach (bool b in activeCamps) 
            {
                int i = Random.Range(0, 3);
                if (i == 0) 
                {
                    activeCamps[n] = false;
                }
                else 
                {
                    activeCamps[n] = true;
                }
                n++;
            }
            
        }
        listner.onClientEnter += Listner_onClientEnter;
        
    }

    private void Listner_onClientEnter(Transform obj)
    {
        fichaInstance = Instantiate(fichaTempalte, obj);
        Analyse analyse = fichaInstance.GetComponent<Analyse>();
        analyse.confirmButton.client = this;
        analyse.ficha.Show(stats,activeCamps);
        analyse.exames.client = this;
    }
    public void GoToExames(bool[] newActives,float time) 
    {
        int i = 0;
		foreach (bool b in newActives) 
        {
			if (b) 
            {
                activeCamps[i] = b;
            }
            i++;
        }
		if (fichaInstance != null) 
        { 
            Destroy(fichaInstance);
        }
        StartCoroutine(Wait(time));
    }
    public void FinishAppointment() 
    {
        
    }
    IEnumerator Wait(float i) 
    {
        yield return new WaitForSeconds(i);
        listner.ClientEnter();
    }
}
