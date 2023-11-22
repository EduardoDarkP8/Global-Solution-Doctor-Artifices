using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public bool isWainting;
    public ClientStats stats;
    public ClientMovement move;
    public ClientListner listner;
    public GameObject fichaTempalte;
    GameObject fichaInstance;
    public GameManager gameManager;
    private bool[] activeCamps = new bool[7];
    void Start()
    {
        listner.onClientEnter += Listner_onClientEnter;

    }

    public void AddStats() 
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
    public void Listner_onClientEnter(Transform obj)
    {
        fichaInstance = Instantiate(fichaTempalte, obj);
        Analyse analyse = fichaInstance.GetComponent<Analyse>();
        analyse.gm = gameManager;
        analyse.confirmButton.client = this;
        analyse.confirmButton.gameManager = gameManager;
        analyse.ficha.Show(stats,activeCamps);
        analyse.exames.client = this;
        
    }
    public void GoToExames(bool[] newActives,float time) 
    {
        isWainting = true;
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
        ExamQueue.instance.waitingClients.Add(this);
        QueryQueue.instance.waitingClients.Remove(this);
        QueryQueue.instance.ListUpdate();
    }
    public void FinishAppointment() 
    {
        if (fichaInstance != null)
        {
            Destroy(fichaInstance);

        }
        ConfirmedQueue.instance.confirmdClients.Add(this);
        QueryQueue.instance.waitingClients.Remove(this);
        QueryQueue.instance.ListUpdate();
        ConfirmedQueue.instance.confirmdClients.Remove(this);
        Destroy(gameObject);
    }
    IEnumerator Wait(float i) 
    {
        yield return new WaitForSeconds(i);
        isWainting = false;
    }
	private void OnDestroy()
	{
        
    }
}
