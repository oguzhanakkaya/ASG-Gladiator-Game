using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;
using System.IO;

public class multi_lobiye : MonoBehaviour
{

	public Text player1_text,player2_text;
	public int energy1,energy2,health1,health2;
    public Transform spawn1,spawn2;
	public GameObject karakter1,karakter2,clone1,clone2;
	public Button walkforw,walkBack,attack1,attack2,attack3,walkForw_2,walkBack_2,attack1_2,attack2_2,attack3_2,exit;
	public Animator anim,anim2;
	public float speed=1.0F;
	private float startTime;
	private int i=0;
	

    void Start()
    {
    PhotonNetwork.ConnectUsingSettings("1.0"); 
		
    }
	void OnGUI()
	{
		GUI.contentColor = Color.black; 
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}
    public void OnConnectedToMaster()
    {
        Debug.Log("Servere girildi");
        PhotonNetwork.JoinLobby();
    }
    public void OnJoinedLobby()
    {
        Debug.Log("Lobiye girildi");	
        PhotonNetwork.JoinOrCreateRoom(i.ToString(), new RoomOptions { MaxPlayers = 2, IsOpen = true, IsVisible = true }, TypedLobby.Default);
		
    }
    public void OnJoinedRoom()
    {
        Debug.Log("Odaya girildi");
		Debug.Log(PhotonNetwork.playerList.Length);
		
		health1=100;
		health2=100;
		energy1=100;
		energy2=100;
		
		player1_text = GameObject.Find("Player1_he").GetComponent<Text>();
		player1_text.text="Health:"+health1+"/100"+"\n\nEnergy:"+energy1+"/100";
		
		player2_text = GameObject.Find("Player2_he").GetComponent<Text>();
		player2_text.text="Health:"+health2+"/100"+"\n\nEnergy:"+energy2+"/100";
		
		Button btn = walkforw.GetComponent<Button>();
		Button btn1= walkBack.GetComponent<Button>();
		Button btn3 = attack1.GetComponent<Button>();
		Button btn4 = attack2.GetComponent<Button>();
		Button btn5 = attack3.GetComponent<Button>();
		
		Button btn_2  = walkForw_2.GetComponent<Button>();
		Button btn1_2 = walkBack_2.GetComponent<Button>();
		Button btn2_2 = attack1_2.GetComponent<Button>();
		Button btn3_2 = attack2_2.GetComponent<Button>();
		Button btn4_2 = attack3_2.GetComponent<Button>();
		
		btn.onClick.AddListener(walkForw_Click);
		btn1.onClick.AddListener(walkBack_Click);
		btn3.onClick.AddListener(attack1_Click);
		btn4.onClick.AddListener(attack2_Click);
		btn5.onClick.AddListener(attack3_Click);
		
		btn_2.onClick.AddListener(walkForw_Click2);
		btn1_2.onClick.AddListener(walkBack_Click2);
		btn2_2.onClick.AddListener(attack1_Click2);
		btn3_2.onClick.AddListener(attack2_Click2);
		btn4_2.onClick.AddListener(attack3_Click2);
		
		btn.gameObject.SetActive(false);
		btn1.gameObject.SetActive(false);
		btn3.gameObject.SetActive(false);
		btn4.gameObject.SetActive(false);
		btn5.gameObject.SetActive(false);	

		btn_2.gameObject.SetActive(false);
		btn1_2.gameObject.SetActive(false);
		btn2_2.gameObject.SetActive(false);
		btn3_2.gameObject.SetActive(false);
		btn4_2.gameObject.SetActive(false);	
		
		
		if(PhotonNetwork.playerList.Length==1)
		{
		Debug.Log(PhotonNetwork.player.ID);
		clone1 =PhotonNetwork.Instantiate(karakter1.name,spawn1.position,spawn1.rotation,0) ;
		//Instantiate(karakter1.name, new Vector3(0, 0, 0),spawn1.position,0);
		anim = clone1.GetComponent<Animator>();
		//GameObject karakter1 =Resources.Load<GameObject>("Resources/Knight1");
		//karakter1 =Resources.Load("Knight1.prefab", typeof(GameObject)) as GameObject;
		
         //backgroundSheet.transform.position = new Vector3(0,-3,0);  
		 // GameObject karakter1 = Instantiate(Resources.Load("Knight1", typeof(GameObject))) as GameObject;
		 
		  //karakter1.ToString();
		//  PhotonNetwork.Instantiate(karakter1.ToString(),spawn1.position,spawn1.rotation,0) ;
		//  karakter1.transform.position = spawn1.position ;
		}
		else if(PhotonNetwork.playerList.Length==2)
		{
		Debug.Log(PhotonNetwork.player.ID);
		clone2= PhotonNetwork.Instantiate(karakter2.name,spawn2.position,spawn2.rotation,0);
		anim2 = clone2.GetComponent<Animator>();	

		}
		if(PhotonNetwork.player.ID==1){
			
            btn.gameObject.SetActive(true);
			btn1.gameObject.SetActive(true);
			btn3.gameObject.SetActive(true);
			btn4.gameObject.SetActive(true);
			btn5.gameObject.SetActive(true);	
		}
		else if(PhotonNetwork.player.ID==2){
			
            btn_2.gameObject.SetActive(true);
			btn1_2.gameObject.SetActive(true);
			btn2_2.gameObject.SetActive(true);
			btn3_2.gameObject.SetActive(true);
			btn4_2.gameObject.SetActive(true);		
		}
		
		if(PhotonNetwork.playerList.Length==2){
			
			
			
			
			
			if( health1==0 || health2==0 || PhotonNetwork.playerList.Length<2 )
			{
			
			
			}
		}
	}				
	public void OnPhotonJoinRoomFailed(){
		Debug.Log("Oda Bulunamadi");
		i=i+1;
		PhotonNetwork.JoinLobby();	
	}
	void walkForw_Click(){
		Debug.Log ("walkforw");
		
		if((spawn1.position.x+(0.5f))<=(5.5f) && (spawn1.position.x+(1.0f)) < spawn2.position.x && energy1>=10 ){
			
			anim.speed = +2.0f;
			anim.Play("walkForw");	
			
			spawn1.position = spawn1.position + new Vector3(0.5f, 0.0f, 0.0f);
			clone1.transform.position = spawn1.position;
			
			energy1=energy1-10;
			player1_text.text="Health:"+(health1)+"/100"+"\n\nEnergy:"+energy1+"/100";
		}
		else
			Debug.Log("Gecemez");	
	}
	void walkBack_Click(){
		Debug.Log ("walkback");
		
		if((spawn1.position.x+(0.5f))<=(+5.5f) && energy1>=10 ){
			
			anim.speed = +2.0f;
			anim.Play("walkBack");
			
			spawn1.position =spawn1.position + new Vector3(-0.5f, 0.0f, 0.0f);
		    clone1.transform.position = spawn1.position;
			
			energy1=energy1-10;
			player1_text.text="Health:"+(health1)+"/100"+"\n\nEnergy:"+energy1+"/100";
		}
	}
	void attack1_Click(){
		if((Mathf.Abs(spawn2.position.x-spawn1.position.x))>=1.0f){
			
			Debug.Log ("ataack1");
			anim.speed = +1.0f;
			anim.Play("attack1");
			/*anim2.Play("hurt");
			anim2.speed = +1.0f;*/		
		}	
	}
	void attack2_Click(){
		if((Mathf.Abs(spawn2.position.x-spawn1.position.x))>=1.0f){
			
			Debug.Log ("attack2");
			anim.speed = +1.0f;
			anim.Play("attack2");
		}
	}
	void attack3_Click(){
		if((Mathf.Abs(spawn2.position.x-spawn1.position.x))>=1.0f){	
			
			Debug.Log ("attack3");
			anim.speed = +1.0f;
			anim.Play("attack3");
		}
	}
	void walkForw_Click2(){
		Debug.Log ("walkforw");
		
		if((spawn2.position.x-(0.5f))>=(-5.5f) && (spawn2.position.x-(1.0f)) > spawn1.position.x && energy1>=10 ){
			
			anim2.speed = +2.0f;
			anim2.Play("walkForw");	
			
			spawn2.position = spawn2.position - new Vector3(0.5f, 0.0f, 0.0f);
			clone2.transform.position = spawn2.position;
			
			energy2=energy2-10;
			player2_text.text="Health:"+(health2)+"/100"+"\n\nEnergy:"+energy2+"/100";
		}
		else
			Debug.Log("Gecemez");		
	}
	void walkBack_Click2(){
		Debug.Log ("walkback");
		
		if((spawn1.position.x-(0.5f))>=(-5.5f) && energy1>=10 ){
			
			anim2.speed = +2.0f;
			anim2.Play("walkBack");
			
			spawn2.position =spawn2.position + new Vector3(+0.5f, 0.0f, 0.0f);
		    clone2.transform.position = spawn2.position;
			
			energy2=energy2-10;
			player2_text.text="Health:"+(health2)+"/100"+"\n\nEnergy:"+energy2+"/100";
		}
	}
	void attack1_Click2(){
		if((Mathf.Abs(spawn2.position.x-spawn1.position.x))>=1.0f){
			
			Debug.Log ("ataack1");
			anim2.speed = +1.0f;
			anim2.Play("attack1");
			
		}
		
	}
	void attack2_Click2(){
		if((Mathf.Abs(spawn2.position.x-spawn1.position.x))>=1.0f){
			
			Debug.Log ("attack2");
			anim2.speed = +1.0f;
			anim2.Play("attack2");
		}
	}
	void attack3_Click2(){
		if((Mathf.Abs(spawn2.position.x-spawn1.position.x))>=1.0f){	
			
			Debug.Log ("attack3");
			anim2.speed = +1.0f;
			anim2.Play("attack3");
		}
	}
}