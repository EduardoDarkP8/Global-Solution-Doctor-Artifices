using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMenu : MonoBehaviour
{
    [SerializeField] GameObject Menu1;
    [SerializeField] GameObject Menu2;
    public void SwitchMenuClick() 
    {
        Menu1.SetActive(false);
        Menu2.SetActive(true);
    }
}
