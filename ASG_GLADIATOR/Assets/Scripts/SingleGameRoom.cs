using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SingleGameRoom : MonoBehaviour
{
    public GameObject player, computer;
    public int check,time;
    public Camera Main_Camera;
    public Button walkforw, walkBack, attack1, attack2, attack3, sleep,btn,btn1,btn3,btn4,btn5,btn6;
    public bool temp,TurnControl;
    public float cameraZoom , cameraZoomDifference,cameraZoomSpeed,camera_x;
    public Canvas HealthAndEnergyCanvas;
    public CountdownTimer countdowntimer;
    public PlayerMovement playerMovement;
    void Start()
    {

        Main_Camera.orthographic = true;
        Main_Camera.orthographicSize = 8.0f;
        Main_Camera.transform.GetComponent<Camera>();

        Set_Button();
        Button_Deactive();

        HealthAndEnergyCanvas.enabled = false;

        countdowntimer.SetTimerToFullTime();

        check = 1;
        TurnControl = false;

        playerMovement.PrintTextbox();

    }

   
    void Update()
    {
        playerMovement.SetTransforms();
      
        // print_textbox();
        // game();
        //camera_zoom();
        //Button_Active();
        
       /* if(temp==true)
        {*/
        /*if(camera_control==false)
        {
            camera_zoom();
        }
        else if(camera_control==true)
        {

            // canvass.enabled = true;
            animation_computer.speed = +2.0f;
            animation_computer.Play("walkForw");
           // computer_transform.position= computer_transform.position - new Vector3(0.5f, 0.0f, 0.0f);
            StartCoroutine("Wait");
        }*/

        /*if(check==1)
        {
            camera_zoom();
            if(countdowntimer.time==0)
            {
                check += 1;
            }
        }
        else if (check == 2)
        {
            camera_normal();
            animation_computer.speed = +2.0f;
            animation_computer.Play("walkForw");
            StartCoroutine("Wait");   

        }*/
        Debug.Log(TurnControl);
        if(TurnControl==false)
        {
            camera_zoom();
            if (countdowntimer.time == 0)
            {
                TurnControl = true;
            }

        }
        else 
        {
            camera_normal();
           // animation_computer.speed = +2.0f;
            //animation_computer.Play("walkForw");
           // TurnControl = false;
            StartCoroutine("Wait");

        }

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        TurnControl = false;

        // check = 1;*/
    }
    public void Set_Button()
    {
       

        btn = GameObject.Find("walk_forward").GetComponent<Button>();
        btn1 = GameObject.Find("walk_back").GetComponent<Button>();
        btn3 = GameObject.Find("attack_1").GetComponent<Button>();
        btn4 = GameObject.Find("attack_2").GetComponent<Button>();
        btn5 = GameObject.Find("attack_3").GetComponent<Button>();
        btn6 = GameObject.Find("sleep").GetComponent<Button>();
      

        btn.onClick.AddListener(playerMovement.WalkLeft);
        btn1.onClick.AddListener(playerMovement.WalkRight);
        btn3.onClick.AddListener(playerMovement.QuickAttack);
        btn4.onClick.AddListener(playerMovement.NormalAttack);
        btn5.onClick.AddListener(playerMovement.HardAttack);
      //  btn6.onClick.AddListener(sleep_Click);
    }
    public void game()
    {
        
       
        

    }
    public void camera_zoom()
    {

        HealthAndEnergyCanvas.enabled = false;

        cameraZoomSpeed = 15f;
        cameraZoom = 4f;

        if (!(Mathf.Abs(player.transform.position.x - Main_Camera.transform.position.x)<0.5f))
        {
            if (player.transform.position.x < Main_Camera.transform.position.x)
            {
                Main_Camera.transform.position -= new Vector3(0.5f, 0.0f, 0.0f)*Time.deltaTime*cameraZoomSpeed;
                if (player.transform.position.y < Main_Camera.transform.position.y)
                {
                    Main_Camera.transform.position -= new Vector3(0.0f, 0.5f, 0.0f)*Time.deltaTime*cameraZoomSpeed;

                }
               
            }
            if (player.transform.position.x > Main_Camera.transform.position.x)
            {
                Main_Camera.transform.position -= new Vector3(0.5f, 0.0f, 0.0f) * Time.deltaTime * cameraZoomSpeed;
                if (player.transform.position.y < Main_Camera.transform.position.y)
                {
                    Main_Camera.transform.position -= new Vector3(0.0f, 0.5f, 0.0f) * Time.deltaTime * cameraZoomSpeed;

                }

            }
        }
  
        cameraZoomDifference = cameraZoom - Main_Camera.orthographicSize;
        Main_Camera.orthographicSize += cameraZoomDifference * cameraZoomSpeed * Time.deltaTime;

        if((Mathf.Abs(Main_Camera.transform.position.x-player.transform.position.x)<0.5 ) && (Mathf.Abs(Main_Camera.transform.position.y - player.transform.position.y) < 0.5))
        {
            Button_Active();
            HealthAndEnergyCanvas.enabled = true;
            // camera_control = true; 
        }

    } 
    public void camera_normal()
    {
        Button_Deactive();
        camera_x= (player.transform.position.x + computer.transform.position.x)/2.0f;
        Main_Camera.transform.position = new Vector3(camera_x,0.0f,-10.0f);
        Main_Camera.orthographicSize= Mathf.Abs(player.transform.position.x - computer.transform.position.x)*8/18;
       
        countdowntimer.SetTimerToFullTime();
        //camera_control = false;

    }
    public void Button_Deactive()
    {
        btn.gameObject.SetActive(false);
        btn1.gameObject.SetActive(false);
        btn3.gameObject.SetActive(false);
        btn4.gameObject.SetActive(false);
        btn5.gameObject.SetActive(false);
        btn6.gameObject.SetActive(false);

        countdowntimer.DeactiveTimer();



    }
    public void Button_Active()
    {

        btn.gameObject.SetActive(true);
        btn1.gameObject.SetActive(true);
        if(Mathf.Abs(player.transform.position.x-computer.transform.position.x)<1.0f)
        {
            btn3.gameObject.SetActive(true);
        }
        if (Mathf.Abs(player.transform.position.x - computer.transform.position.x) < 1.0f)
        {
            btn4.gameObject.SetActive(true);
        }
        if (Mathf.Abs(player.transform.position.x - computer.transform.position.x) < 1.0f)
        {
            btn5.gameObject.SetActive(true);
        }
        /*btn3.gameObject.SetActive(true);
        btn4.gameObject.SetActive(true);
        btn5.gameObject.SetActive(true);*/
        btn6.gameObject.SetActive(true);

        ActiveAndCountTimer();
        
      
    }
    public void ActiveAndCountTimer()
    {
        countdowntimer.ActiveTimer();
        countdowntimer.CountTimer();
    }



}
