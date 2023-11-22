using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueryQueue : MonoBehaviour
{
    public static QueryQueue instance;
    public List<Client> waitingClients;
    [SerializeField] ClientListner listener;
    public GameObject client;
    [SerializeField] GameManager gameManager;
    public int queueMax;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        ListUpdate();
    }
    public void ListUpdate() 
    {
		while (waitingClients.Count < queueMax) 
        { 
		    if (ExamQueue.instance.LastWaintingClients() == null)
            {
                Client atualInstance = Instantiate(client).GetComponent<Client>();
                atualInstance.AddStats();
                atualInstance.listner = listener;
                atualInstance.gameManager = gameManager;
                waitingClients.Add(atualInstance);
            }
			else 
            {
                Client selectedClient = ExamQueue.instance.LastWaintingClients();
                waitingClients.Add(selectedClient);
                selectedClient.isWainting = false;
                ExamQueue.instance.waitingClients.Remove(selectedClient);
            }
        }
		if (listener != null) 
        {
            waitingClients.ToArray()[0].Listner_onClientEnter(listener.gameObject.transform);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
