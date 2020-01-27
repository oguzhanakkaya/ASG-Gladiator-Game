using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;



public class walkForw : MonoBehaviour
{
	public GameObject bt;
	public Text a;
	
    private void Awake()
	{
        
    }
    public void ButtonClick()
    {
		a= GameObject.Find("walkForw").GetComponent<Text>();
		
		Debug.Log(a);
		
        
    }
	
	
	
}
