using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Single_Game : MonoBehaviour
{
    public GameObject player, computer;
    public Animator animation_player, animation_computer;
    public int player_health, computer_health, player_energy, computer_energy;
    public int check,time;
    public Text player_text, computer_text;
    public Camera Main_Camera;
    public Transform computer_transform, player_transform, camera_transform, temp_transform;
    public Button walkforw, walkBack, attack1, attack2, attack3, sleep,btn,btn1,btn3,btn4,btn5,btn6;
    public bool temp,camera_control=false;
    public float cameraZoom , cameraZoomDifference,cameraZoomSpeed,camera_x;
    public Canvas HealthAndEnergyCanvas;
    public CountdownTimer countdowntimer;

    void Start()
    {
        animation_player = player.GetComponent<Animator>();
        animation_computer = computer.GetComponent<Animator>();

        Main_Camera.orthographic = true;
        Main_Camera.orthographicSize = 8.0f;
        Main_Camera.transform.GetComponent<Camera>();

        Set_Button();
        Button_Deactive();

        HealthAndEnergyCanvas.enabled = false;

        countdowntimer.SetTimerToFullTime();

        check = 1;
        
        print_textbox();

        

    }

   
    void Update()
    {
        computer_transform.position = computer.transform.position;
        player_transform.position = player.transform.position;
        camera_transform.position = Main_Camera.transform.position;

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

        if(check==1)
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

        }
        Debug.Log(check);

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
       // camera_control = false;
        check = 1;
    }
    public void Set_Button()
    {
        /*btn = walkforw.GetComponent<Button>();
         btn1 = walkBack.GetComponent<Button>();
         btn3 = attack1.GetComponent<Button>();
         btn4 = attack2.GetComponent<Button>();
         btn5 = attack3.GetComponent<Button>();
         btn6 = sleep.GetComponent<Button>();*/

        btn = GameObject.Find("walk_forward").GetComponent<Button>();
        btn1 = GameObject.Find("walk_back").GetComponent<Button>();
        btn3 = GameObject.Find("attack_1").GetComponent<Button>();
        btn4 = GameObject.Find("attack_2").GetComponent<Button>();
        btn5 = GameObject.Find("attack_3").GetComponent<Button>();
        btn6 = GameObject.Find("sleep").GetComponent<Button>();
      

        btn.onClick.AddListener(walkForw_Click);
        btn1.onClick.AddListener(walkBack_Click);
        btn3.onClick.AddListener(attack1_Click);
        btn4.onClick.AddListener(attack2_Click);
        btn5.onClick.AddListener(attack3_Click);
      //  btn6.onClick.AddListener(sleep_Click);
    }
    public void walkForw_Click()
    {
        Debug.Log("walkforw");

        /*  if ((spawn1.position.x + (0.5f)) <= (5.5f) && (spawn1.position.x + (1.0f)) < spawn2.position.x && energy1 >= 10)
          {*/
            camera_normal();

            animation_player.speed = +2.0f;
            animation_player.Play("walkForw");

            player_transform.position = player_transform.position + new Vector3(1.5f, 0.0f, 0.0f);

            player_energy = player_energy - 10;
            player_text.text = "Health:" + (player_health) + "/100" + "\n\nEnergy:" + player_energy + "/100";
            camera_control = true;
            
            check = check + 1;
        /*}
        else
            Debug.Log("Gecemez");*/
    }
    public void walkBack_Click()
    {
        Debug.Log("walkback");

       

            animation_player.speed = +2.0f;
            animation_player.Play("walkBack");

        player_transform.position = player_transform.position + new Vector3(-0.5f, 0.0f, 0.0f);

        player_energy = player_energy - 10;
        player_text.text = "Health:" + (player_health) + "/100" + "\n\nEnergy:" + player_energy + "/100";
        check = check + 1;

    }
    public void attack1_Click()
    {
       /* if ((Mathf.Abs(spawn2.position.x - spawn1.position.x)) >= 1.0f)
        {*/

            Debug.Log("ataack1");
            animation_player.speed = +1.0f;
            animation_player.Play("attack1");
            animation_computer.Play("hurt");
			animation_computer.speed = +1.0f;
        check = check + 1;

    }
    public void attack2_Click()
    {


         Debug.Log("attack2");
         animation_player.speed = +1.0f;
            animation_player.Play("attack1");
            animation_computer.Play("hurt");
			animation_computer.speed = +1.0f;
        check = check + 1;

    }
    public void attack3_Click()
 {
    /* if ((Mathf.Abs(spawn2.position.x - spawn1.position.x)) >= 1.0f)
     {*/

         Debug.Log("attack3");
        animation_player.speed = +1.0f;
        animation_player.Play("attack3");
        animation_computer.Play("hurt");
        animation_computer.speed = +1.0f;
        check = check + 1;
        /*}*/
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




        /* Button_Deactive();

         cameraZoomSpeed = 15f;
         cameraZoom = Mathf.Abs(player.transform.position.x-computer.transform.position.x);




         temp_transform.position = new Vector3(Mathf.Abs(player.transform.position.x + computer.transform.position.x)/2.0f,0,0);

         if (!(Mathf.Abs(temp_transform.position.x - Main_Camera.transform.position.x) < 0.10f))
         {
             if (temp_transform.position.x < Main_Camera.transform.position.x)
             {
                 Main_Camera.transform.position += new Vector3(0.5f, 0.0f, 0.0f) * Time.deltaTime * cameraZoomSpeed;
                 if (temp_transform.position.y < Main_Camera.transform.position.y)
                 {
                     Main_Camera.transform.position += new Vector3(0.0f, 0.5f, 0.0f) * Time.deltaTime * cameraZoomSpeed;

                 }

             }
             if (temp_transform.position.x > Main_Camera.transform.position.x)
             {
                 Main_Camera.transform.position += new Vector3(0.5f, 0.0f, 0.0f);// *Time.deltaTime* cameraZoomSpeed;
                 if (temp_transform.position.y < Main_Camera.transform.position.y)
                 {
                     Main_Camera.transform.position -= new Vector3(0.0f, 0.5f, 0.0f);//* Time.deltaTime * cameraZoomSpeed;

                 }
                 if (temp_transform.position.y > Main_Camera.transform.position.y)
                 {
                     Main_Camera.transform.position += new Vector3(0.0f, 0.5f, 0.0f);//* Time.deltaTime * cameraZoomSpeed;

                 }

             }
         }



         cameraZoomDifference = cameraZoom - Main_Camera.orthographicSize;

         if(!(Mathf.Abs(Main_Camera.orthographicSize-cameraZoom)<0.5f))
         Main_Camera.orthographicSize += cameraZoomDifference * cameraZoomSpeed * Time.deltaTime;
 */
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
        Debug.Log("Button Active");
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
       
        countdowntimer.ActiveTimer();

        countdowntimer.CountTimer();
        
      
    }
    public void print_textbox(){

         player_health = 100;
         computer_health = 100;
         player_energy = 100;
         computer_energy = 100;

         player_text = GameObject.Find("Player_Text").GetComponent<Text>();
         player_text.text = "Health:" + player_health + "/100" + "\n\nEnergy:" + player_energy + "/100";

         computer_text = GameObject.Find("Computer_Text").GetComponent<Text>();
         computer_text.text = "Health:" + computer_health + "/100" + "\n\nEnergy:" + computer_energy + "/100";
     }
   



}
