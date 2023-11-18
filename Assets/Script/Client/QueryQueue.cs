using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueryQueue : MonoBehaviour
{
    public static QueryQueue instance;
    public List<Client> waitingClients;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
