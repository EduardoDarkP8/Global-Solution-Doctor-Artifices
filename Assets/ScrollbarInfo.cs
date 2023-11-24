using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollbarInfo : MonoBehaviour
{
    [SerializeField] string preText;
    [SerializeField] float converter;
    [SerializeField] Text text;
    [SerializeField] Scrollbar scrl;
	private void Start()
	{
        Scroll();
	}
	public void Scroll() 
    {
        text.text = preText + ((int)(scrl.value * converter)).ToString();
    }

}
