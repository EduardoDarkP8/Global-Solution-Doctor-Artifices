using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientListner : MonoBehaviour
{
    public event Action<Transform> onClientEnter;
    void Start()
    {

    }

    void Update()
    {
        
    }
    public void ClientEnter() 
    {
        onClientEnter.Invoke(transform);
    }
}
