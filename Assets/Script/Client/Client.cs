using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public ClientStats stats;
    public ClientListner listner;
    public GameObject fichaTempalte;
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
        GameObject gm = Instantiate(fichaTempalte, obj);
        Analyse analyse = gm.GetComponent<Analyse>();
        analyse.confirmButton.client = this;
        analyse.ficha.Show(stats,activeCamps);

    }

    void Update()
    {
        
    }
}
