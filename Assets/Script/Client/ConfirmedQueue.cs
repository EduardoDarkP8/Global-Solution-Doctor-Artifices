using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmedQueue : MonoBehaviour
{
    public static ConfirmedQueue instance;
    public List<Client> confirmdClients;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
