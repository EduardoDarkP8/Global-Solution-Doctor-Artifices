using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMovement : MonoBehaviour
{
    [SerializeField]Animator animatorBody;
    [SerializeField]Animator animatorSprite;
    public float animTime;
    void Start()
    {
        
    }
    public void MoveRoom(bool enter) 
    {
        animatorBody.SetBool("Enter", enter);
    }
    
    
}
