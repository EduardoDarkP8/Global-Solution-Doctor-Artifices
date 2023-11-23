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
    public void BodyMove(bool walking, bool front) 
    {
        animatorSprite.SetBool("Front", front);
        animatorSprite.SetBool("Walking", walking);
        StartCoroutine(Entering(walking));
    }
    IEnumerator Entering(bool walking) 
    {
        yield return new WaitForSeconds(animTime);
        walking = !walking;
        animatorBody.SetBool("Walking",walking);
    }
}
