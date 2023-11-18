using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamQueue : MonoBehaviour
{
    public static ExamQueue instance;
    public List<Client> waitingClients;
    
    void Start()
    {
		if (instance == null) 
        {
            instance = this;
        }
    }

    public Client LastWaintingClients() 
    {
        Client exit = null;
        int i = 0;
		foreach (Client client in waitingClients) 
        {
			if (waitingClients.ToArray()[i].isWainting) 
            {
                exit = waitingClients.ToArray()[i];
                break;
            }
            i++;
        }
        return exit;
    }
    
    
    void Update()
    {
        
    }
}
